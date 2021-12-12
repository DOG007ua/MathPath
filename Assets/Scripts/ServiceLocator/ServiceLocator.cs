using System;
using System.Collections.Generic;

namespace ServiceLocator
{
    public class ServiceLocator
    {
        private Dictionary<Type, object> list;

        public void Register<T>(T realization)
        {
            list.Add(typeof(T), realization);
        }

        public T GetService<T>()
        {
            return (T)list[typeof(T)];
        }
        
    }
}