﻿using NetworkTables.Tables;
using System.ComponentModel.Composition.Hosting;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DotNetDash.BuiltinProcessors
{
    class DefaultProcessor : TableProcessor
    {
        public DefaultProcessor(string name, ITable table, CompositionContainer container)
            :base(name, table, container)
        {
        }

        protected override FrameworkElement GetViewCore()
        {
            var layout = new StackPanel { Orientation = Orientation.Vertical };
            foreach (var key in baseTable.GetKeys())
            {
                if (key == "~TYPE~") continue;
                var keyValueLine = new StackPanel { Orientation = Orientation.Horizontal };
                keyValueLine.Children.Add(new Label { Content = key });
                var valueBox = new TextBox();
                valueBox.SetBinding(TextBox.TextProperty, $"[{key}]");
                keyValueLine.Children.Add(valueBox);
                layout.Children.Add(keyValueLine);
            }
            return layout;
        }
    }
}