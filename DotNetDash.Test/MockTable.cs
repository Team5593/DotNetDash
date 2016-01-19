﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkTables;
using NetworkTables.Native;
using NetworkTables.Tables;

namespace DotNetDash.Test
{
    class MockTable : ITable
    {
        public void AddSubTableListener(Action<ITable, string, object, NotifyFlags> listenerDelegate)
        {
            throw new NotImplementedException();
        }

        public void AddSubTableListener(ITableListener listener)
        {
            throw new NotImplementedException();
        }

        public void AddSubTableListener(Action<ITable, string, object, NotifyFlags> listenerDelegate, bool localNotify)
        {
            throw new NotImplementedException();
        }

        public void AddSubTableListener(ITableListener listener, bool localNotify)
        {
            throw new NotImplementedException();
        }

        public void AddTableListener(Action<ITable, string, object, NotifyFlags> listenerDelegate, bool immediateNotify = false)
        {
            throw new NotImplementedException();
        }

        public void AddTableListener(ITableListener listener, bool immediateNotify = false)
        {
            throw new NotImplementedException();
        }

        public void AddTableListener(string key, Action<ITable, string, object, NotifyFlags> listenerDelegate, bool immediateNotify)
        {
            throw new NotImplementedException();
        }

        public void AddTableListener(string key, ITableListener listener, bool immediateNotify)
        {
            throw new NotImplementedException();
        }

        public void AddTableListenerEx(Action<ITable, string, object, NotifyFlags> listenerDelegate, NotifyFlags flags)
        {
            throw new NotImplementedException();
        }

        public void AddTableListenerEx(ITableListener listener, NotifyFlags flags)
        {
            throw new NotImplementedException();
        }

        public void AddTableListenerEx(string key, Action<ITable, string, object, NotifyFlags> listenerDelegate, NotifyFlags flags)
        {
            throw new NotImplementedException();
        }

        public void AddTableListenerEx(string key, ITableListener listener, NotifyFlags flags)
        {
            throw new NotImplementedException();
        }

        public void ClearFlags(string key, EntryFlags flags)
        {
            throw new NotImplementedException();
        }

        public void ClearPersistent(string key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsSubTable(string key)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(string key)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(string key, bool defaultValue)
        {
            throw new NotImplementedException();
        }

        public bool[] GetBooleanArray(string key)
        {
            throw new NotImplementedException();
        }

        public bool[] GetBooleanArray(string key, bool[] defaultValue)
        {
            throw new NotImplementedException();
        }

        public EntryFlags GetFlags(string key)
        {
            throw new NotImplementedException();
        }

        public HashSet<string> GetKeys()
        {
            throw new NotImplementedException();
        }

        public HashSet<string> GetKeys(NtType types)
        {
            throw new NotImplementedException();
        }

        public double GetNumber(string key)
        {
            throw new NotImplementedException();
        }

        public double GetNumber(string key, double defaultValue)
        {
            throw new NotImplementedException();
        }

        public double[] GetNumberArray(string key)
        {
            throw new NotImplementedException();
        }

        public double[] GetNumberArray(string key, double[] defaultValue)
        {
            throw new NotImplementedException();
        }

        public byte[] GetRaw(string key)
        {
            throw new NotImplementedException();
        }

        public byte[] GetRaw(string key, byte[] defaultValue)
        {
            throw new NotImplementedException();
        }

        public string GetString(string key)
        {
            throw new NotImplementedException();
        }

        public string GetString(string key, string defaultValue)
        {
            throw new NotImplementedException();
        }

        public string[] GetStringArray(string key)
        {
            throw new NotImplementedException();
        }

        public string[] GetStringArray(string key, string[] defaultValue)
        {
            throw new NotImplementedException();
        }

        public ITable GetSubTable(string key)
        {
            throw new NotImplementedException();
        }

        public HashSet<string> GetSubTables()
        {
            throw new NotImplementedException();
        }

        public object GetValue(string key)
        {
            throw new NotImplementedException();
        }

        public object GetValue(string key, object defaultValue)
        {
            throw new NotImplementedException();
        }

        public bool IsPersistent(string key)
        {
            throw new NotImplementedException();
        }

        public bool PutBoolean(string key, bool value)
        {
            throw new NotImplementedException();
        }

        public bool PutBooleanArray(string key, bool[] value)
        {
            throw new NotImplementedException();
        }

        public bool PutNumber(string key, double value)
        {
            throw new NotImplementedException();
        }

        public bool PutNumberArray(string key, double[] value)
        {
            throw new NotImplementedException();
        }

        public bool PutRaw(string key, byte[] value)
        {
            throw new NotImplementedException();
        }

        public bool PutString(string key, string value)
        {
            throw new NotImplementedException();
        }

        public bool PutStringArray(string key, string[] value)
        {
            throw new NotImplementedException();
        }

        public bool PutValue(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveTableListener(Action<ITable, string, object, NotifyFlags> listenerDelegate)
        {
            throw new NotImplementedException();
        }

        public void RemoveTableListener(ITableListener listener)
        {
            throw new NotImplementedException();
        }

        public void SetFlags(string key, EntryFlags flags)
        {
            throw new NotImplementedException();
        }

        public void SetPersistent(string key)
        {
            throw new NotImplementedException();
        }
    }
}
