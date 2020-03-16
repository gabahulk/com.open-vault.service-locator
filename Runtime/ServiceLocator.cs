using System;
using System.Collections.Generic;

namespace OpenVault.Tools
{
    public class ServiceLocator : IServiceLocator
    {
        private static ServiceLocator instance;
        public static ServiceLocator Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                instance = new ServiceLocator();
                return instance;
            }
        }

        private Dictionary<int, object> servicesMap = new Dictionary<int, object>();

        public void RegisterService<T>(T serviceObject) 
            where T : class
        {
            servicesMap[typeof(T).GetHashCode()] = serviceObject;
        }

        public void DeregisterService<T>(T service)
            where T : class
        {
            if (servicesMap.ContainsKey(typeof(T).GetHashCode()))
            {
                servicesMap.Remove(typeof(T).GetHashCode());
            }
        }


        public object GetService<T>() where T:class
        {
            if (servicesMap.TryGetValue(typeof(T).GetHashCode(), out object value))
            {
                return value;
            }

            throw new KeyNotFoundException("Trying to get a service that is not registered.");
        }

        public void ClearAllServices()
        {
            servicesMap.Clear();
        }
    }
}

