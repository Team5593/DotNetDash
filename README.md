# DotNetDash
DotNetDash is RobotDotNet's SmartDashboard replacement. It is designed from the start to be easily extensible.

It is currently under heavy development, and may have breaking changes.

## Supported Operating Systems
The current implementation is based on WPF, so it is Windows only.
Between now and release, we may switch over to [Perspex](https://perspex.github.io) for multi-platform support.

## Extensibility
### XAML Plugins
You can write plugins using just XAML Markup if you only need basic data-binding capabilities.  For example, a Digital Input display can be coded as follows (which it currently is):
```xaml
<dash:XamlView
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:dash="clr-namespace:DotNetDash;assembly=DotNetDash"
            DashboardType="Digital Input">
    <StackPanel Orientation="Horizontal">
        <TextBlock Text="{Binding Name}" />
        <CheckBox IsChecked="{Binding Booleans[Value]}" IsEnabled="false" />
    </StackPanel>
</dash:XamlView>
```

You must set the `DashboardType` to the SmartDashboard type of the sendable.

The `Name` property binds to the `Name` property on the table. For all other table entries, you bind to them by `DataType[Key_Name]`. So, for a boolean Value key, you would bind to `Booleans[Value]` as above.

### C# Plugins
For anything more advanced, you need to create a C# plugin. There will be more documentation on this in the future. You can see examples of this here with the LiveWindow and CANSpeedController support.