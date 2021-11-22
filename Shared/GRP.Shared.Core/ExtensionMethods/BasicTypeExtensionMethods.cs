
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace GRP.Shared.Core.ExtensionMethods
{
    public static class BasicTypeExtensionMethods
    {
        public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        public static bool IsNull(this object obj) => obj is null;
        public static bool IsNotNull(this object obj) => !(obj is null);
        public static int Int(this float num) => (int)num;
        public static T Cast<T>(this object obj) => (T)obj;
        public static bool IsTrue(this bool con) => con;
        public static bool IsFalse(this bool con) => !con;

        public static dynamic ObjectToList<T>(this object src)
        {
            dynamic obj = new ExpandoObject();
            List<T> list = new List<T>();
            src.GetType().GetProperties().ToList().ForEach(x =>
            {
                if (x.PropertyType != typeof(T))
                {
                    var key = char.ToLowerInvariant(x.Name[0]) + x.Name.Substring(1);
                    ((IDictionary<string, object>)obj)[key] = x.GetValue(src);
                    return;
                };
                var module = x.GetValue(src).Cast<T>();
                if (module == null) return;
                list.Add(module);

            });
            obj.items = list;
            return obj;
        }
    }
}
