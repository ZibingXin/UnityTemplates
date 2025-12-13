// ServiceContainer.cs

using System;
using System.Collections.Generic;

namespace ZXTemplate.Core
{
    public static class ServiceContainer
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service) where T : class
        {
            _services[typeof(T)] = service ?? throw new ArgumentNullException(nameof(service));
        }

        public static T GetT<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var obj))
            {
                return (T)obj;
            }
            throw new InvalidOperationException($"Service not found: {typeof(T).Name}");
        }

        public static bool TryGetT<T>(out T service) where T : class
        {
            if (_services.TryGetValue(typeof(T), out var obj))
            {
                service = (T)obj;
                return true;
            }
            service = null;
            return false;
        }

        public static void Clear() => _services.Clear();

    }
}
