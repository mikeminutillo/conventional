using System;
using System.Collections.Generic;
using System.Linq;

namespace Conventional
{
    public static class ReflectionExtensions
    {
        public static bool IsA<T>(this Type t)
        {
            return typeof (T).IsAssignableFrom(t);
        }

        public static IEnumerable<Type> GetClosedInterfacesOf(this Type type, Type openGeneric)
        {
            return from i in type.GetInterfaces()
                   where i.IsGenericType
                   let defn = i.GetGenericTypeDefinition()
                   where defn == openGeneric
                   select i;
        }

        public static bool ClosesInterface(this Type t, Type openGeneric)
        {
            return t.GetClosedInterfacesOf(openGeneric).Any();
        }

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Type t) where TAttribute : Attribute
        {
            return t.GetCustomAttributes(true).OfType<TAttribute>();
        }

        public static bool HasAttribute<TAttribute>(this Type t) where TAttribute : Attribute
        {
            return t.GetAttributes<TAttribute>().Any();
        }

        public static bool HasInterfaces(this Type t)
        {
            return t.GetInterfaces().Any();
        }
    }
}
