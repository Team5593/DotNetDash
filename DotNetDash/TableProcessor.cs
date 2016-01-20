﻿using NetworkTables.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DotNetDash
{
    public abstract class TableProcessor
    {
        protected readonly ITable baseTable;
        private readonly CompositionContainer container;
        protected readonly string name;

        [ImportMany(typeof(ITableProcessorFactory))]
        private IEnumerable<Lazy<ITableProcessorFactory, IDashboardTypeMetadata>> processorFactories;

        protected ObservableCollection<TableProcessor> subTableProcessors = new ObservableCollection<TableProcessor>();

        protected Lazy<FrameworkElement> element;

        protected TableProcessor(string name, ITable table, CompositionContainer container)
        {
            this.name = name;
            baseTable = table;
            this.container = container;
            container.ComposeParts(this);
            element = new Lazy<FrameworkElement>(() => GetViewCore());
            InitProcessors();
            subTableProcessors.CollectionChanged += SubTableProcessorsChanged;
        }

        private void SubTableProcessorsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke((Action<NotifyCollectionChangedEventArgs>)HandleSubTableChange, e);
        }

        private void HandleSubTableChange(NotifyCollectionChangedEventArgs e)
        {
            var panel = GetPanelLayout();
            if (panel == null) return;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddNewItemsToPanel(e.NewItems, panel);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    AddNewItemsToPanel(e.NewItems, panel);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    panel.Children.Clear();
                    break;
                default:
                    break;
            }
        }

        private static void AddNewItemsToPanel(System.Collections.IList newItems, Panel panel)
        {
            foreach (TableProcessor item in newItems)
            {
                panel.Children.Add(item.GetBoundView());
            }
        }

        protected virtual Panel GetPanelLayout()
        {
            return null;
        }

        protected void InitProcessors()
        {
            baseTable.AddSubTableListener((table, newTableName, _, flags) => AddTableProcessor(newTableName));
        }

        private void AddTableProcessor(string subTable)
        {
            var table = baseTable.GetSubTable(subTable);
            var type = table.GetString("~TYPE~", "");
            var matchedProcessors = processorFactories.Where(factory => factory.Metadata.IsMatch(type));
            // TODO: Add support for showing multiple options when there are multiple ways to view a specific data type
            var subProcessor = (matchedProcessors.FirstOrDefault(factory => !factory.Metadata.IsWildCard()) ?? matchedProcessors.First())
                    .Value.Create(subTable, table, container);
            subTableProcessors.Add(subProcessor);
        }

        public FrameworkElement GetBoundView()
        {
            var view = element.Value;
            view.DataContext = new NetworkTableContext(name, baseTable);
            return view;
        }

        protected abstract FrameworkElement GetViewCore();
    }
}
