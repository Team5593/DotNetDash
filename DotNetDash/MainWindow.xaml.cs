﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using NetworkTables;

namespace DotNetDash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCustomControls();
            if(Properties.Settings.Default.TeamNumber == 0 && new RoboRioConnectionWindow().ShowDialog() != true)
            {
                Close();
            }
            else
            {
                NetworkTable.Shutdown();
                NetworkTable.SetIPAddress($"roborio-{Properties.Settings.Default.TeamNumber}-frc.local");
                NetworkTable.SetClientMode();
                NetworkTable.AddGlobalConnectionListener(SetConnectivityMarker, true);
                NetworkTable.Initialize();

               InitializeDashboard();
            }
        }

        private void LoadCustomControls()
        {
            var factories = (Application.Current as App).Container.GetExports<IViewProcessorFactory, ICustomViewFactoryMetadata>();
            foreach (var factory in factories)
            {
                InsertMenu.Items.Add(new MenuItem {
                    Header = factory.Metadata.Name,
                    Command = new Command(() => AddViewToCurrentRootView(factory.Metadata.Name, factory.Value.Create()))
                });
            }
        }

        private void AddViewToCurrentRootView(string name, IViewProcessor viewProcessor)
        {
            var currentRootProcessor = (TableProcessor)Tabs.SelectedContent;
            currentRootProcessor.AddViewProcessorToView($"{name}_{Guid.NewGuid()}", viewProcessor);
        }

        protected override void OnClosed(EventArgs e)
        {
            NetworkTables.NetworkTable.Shutdown();
            base.OnClosed(e);
        }

        private void OpenRoboRioConnectionWindow(object sender, RoutedEventArgs e)
        {
            new RoboRioConnectionWindow().ShowDialog();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            InitializeTabs();
            //InitializeConnectivityMarker();
            SetConnectivityMarker(null, new ConnectionInfo(), false);
        }

        private void SetConnectivityMarker(NetworkTables.Tables.IRemote remote, ConnectionInfo conn, bool connected)
        {
            this.Dispatcher.Invoke(
              delegate
              {
                  if (NetworkTables.NetworkTable.Connections().Any())
                  {
                      ConnectionIndicator.Fill = Brushes.Green;
                  }
                  else
                  {
                      ConnectionIndicator.Fill = Brushes.Red;
                  }
              }, System.Windows.Threading.DispatcherPriority.Normal);
        }

        private void InitializeTabs()
        {
            Tabs.Items.Clear();
            var rootViews = (Application.Current as App).Container.GetExports<IRootTableProcessorFactory, IDashboardTypeMetadata>();
            foreach (var rootTable in Properties.Settings.Default.RootTables)
            {
                Tabs.Items.Add(new TabItem
                {
                    Content = CreateRootTableProcessor(rootViews, rootTable),
                    Header = rootTable
                });
            }
        }

        private void OpenServerConnectionWindow(object sender, RoutedEventArgs e)
        {
            new ServerConnectionWindow().ShowDialog();
            InitializeDashboard();
        }

        private static TableProcessor CreateRootTableProcessor(IEnumerable<Lazy<IRootTableProcessorFactory, IDashboardTypeMetadata>> factories, string tableName)
        {
            var matchedProcessors = factories.Where(factory => factory.Metadata.IsMatch(tableName));
            var processor = (matchedProcessors.FirstOrDefault(factory => !factory.Metadata.IsWildCard()) ?? matchedProcessors.First())
                                  .Value.Create(tableName, NetworkTables.NetworkTable.GetTable(tableName));
            return processor;
        }
    }
}
