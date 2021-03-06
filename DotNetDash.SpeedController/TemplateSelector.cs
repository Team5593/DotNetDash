﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DotNetDash.SpeedController
{
    public sealed class TemplateSelector : IMultiValueConverter
    {
        public FrameworkElement ResourceHost { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var model = (ControllerModel)values[0];
            var mode = (ControlMode)values[1];
            return SelectTemplate(mode).LoadContent();
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public DataTemplate SelectTemplate(ControlMode mode)
        {
            var resources = ResourceHost.Resources;
            if (resources.Contains(mode.ToString()))
                return (DataTemplate)resources[mode.ToString()];
            return (DataTemplate)resources["PID"];
        }
    }
}
