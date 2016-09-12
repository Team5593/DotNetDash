using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using DotNetDash;
using NetworkTables.Tables;

namespace Team5593.Dashboard.Plugins
{
    class CommandProcessor : TableProcessor
    {
        public CommandProcessor(string name, ITable table, IEnumerable<Lazy<ITableProcessorFactory, IDashboardTypeMetadata>> processorFactories)
            : base(name, table, processorFactories)
        {
        }

        protected override FrameworkElement GetViewCore()
        {
            return new CommandView();
        }

        protected override NetworkTableContext GetTableContext(string name, ITable table) => new CommandModel(name, table);

        public override string Name => "Robot Command View";
    }

    [DashboardType(typeof(ITableProcessorFactory), "Command")]
    public sealed class CommandProcessorFactory : ITableProcessorFactory
    {
        private readonly IEnumerable<Lazy<ITableProcessorFactory, IDashboardTypeMetadata>> processorFactories;

        [ImportingConstructor]
        public CommandProcessorFactory([ImportMany] IEnumerable<Lazy<ITableProcessorFactory, IDashboardTypeMetadata>> processorFactories)
        {
            this.processorFactories = processorFactories;
        }

        public TableProcessor Create(string subTable, ITable table)
        {
            return new CommandProcessor(subTable, table, processorFactories);
        }
    }
}
