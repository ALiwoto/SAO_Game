using System;
using System.Collections.Generic;
using System.Text;

namespace WotoProvider.Interfaces
{
    public interface IQStringProvider<T1, T2>
        where T1 : class
        where T2 : class
    {
        string GetValue();
        string GetString();
        T1 GetStrong();
        int IndexOf(string value);
        int IndexOf(char value);
        int IndexOf(T1 value);
        int IndexOf(T2 value);
    }
}
