﻿using NetworkTables;
using NetworkTables.Tables;
using System;
using System.Threading;

namespace DotNetDash
{
    public static class NetworkTablesExtensions
    {
        public static void AddSubTableListenerOnSynchronizationContext(this ITable table, SynchronizationContext context, Action<ITable, string, NotifyFlags> callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }
            table.AddSubTableListener((tbl, name, _, flags) =>
            {
                if (context != null)
                {
                    context.Post(state => callback(tbl, name, flags), null);
                }
                else
                {
                    ThreadPool.QueueUserWorkItem(state => callback(tbl, name, flags), null);
                }
            });
        }

        public static void AddTableListenerOnSynchronizationContext(this ITable table, SynchronizationContext context, Action<ITable, string, object, NotifyFlags> callback, bool immediateNotify = false)
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }
            table.AddTableListener((tbl, name, value, flags) =>
            {
                if (context != null)
                {
                    context.Post(state => callback(tbl, name, value, flags), null);
                }
                else
                {
                    ThreadPool.QueueUserWorkItem(state => callback(tbl, name, value, flags), null);
                }
            }, immediateNotify);
        }

        public static void AddTableListenerOnSynchronizationContext(this ITable table, SynchronizationContext context, Action<ITable, string, object, NotifyFlags> callback, NotifyFlags flags)
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }
            table.AddTableListenerEx((tbl, name, value, _flags) =>
            {
                if (context != null)
                {
                    context.Post(state => callback(tbl, name, value, _flags), null);
                }
                else
                {
                    ThreadPool.QueueUserWorkItem(state => callback(tbl, name, value, _flags), null);
                }
            }, flags);
        }
    }
}
