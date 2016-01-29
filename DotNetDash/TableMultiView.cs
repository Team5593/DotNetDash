﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace DotNetDash
{
    [TemplatePart(Name = "PART_Presenter", Type = typeof(ContentPresenter))]
    public class TableMultiView : Selector
    {
        public TableMultiView()
        {
            AllowDrop = true;
        }

        private ContentPresenter presenter;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            presenter = (ContentPresenter)Template.FindName("PART_Presenter", this);
            TrySetNewContent(SelectedItem);
        }

        protected override void OnItemTemplateChanged(DataTemplate oldItemTemplate, DataTemplate newItemTemplate)
        {
            base.OnItemTemplateChanged(oldItemTemplate, newItemTemplate);
            TrySetNewContent(SelectedItem);
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            if(newValue.OfType<object>().Any())
            {
                SelectedItem = newValue.OfType<object>().ElementAt(0);
            }
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            var dragDropBehavior = new DragDropBehavior();
            dragDropBehavior.Attach(VisualParent);
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            if (e.AddedItems.Count > 0)
            {
                var newPresenter = e.AddedItems[0];
                TrySetNewContent(newPresenter);
            }
        }

        private void TrySetNewContent(object newPresenter)
        {
            if (ItemTemplate == null || presenter == null) return;
            var newContent = (FrameworkElement)ItemTemplate.LoadContent();
            newContent.DataContext = newPresenter;
            presenter.Content = newContent;
        }
    }
}
