using NetworkTables.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using DotNetDash;

namespace Team5593.Dashboard.Plugins
{
    public class CommandModel : NetworkTableContext
    {
        public CommandModel(string tableName, ITable table) : base(tableName, table)
        {
            table.AddTableListenerOnSynchronizationContext(SynchronizationContext.Current, (modifiedTable, key, value, _) =>
            {
                switch (key)
                {
                    //case nameof(Mode):
                    //    Mode = (ControlMode)(int)(double)value;
                    //    break;
                    //case "Value":
                    //    ShowValue((double)value);
                    //    break;
                    default:
                        break;
                }
            }, NetworkTables.NotifyFlags.NotifyImmediate | NetworkTables.NotifyFlags.NotifyUpdate | NetworkTables.NotifyFlags.NotifyNew);
        }
    }
}
