using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Brevitee
{
    public static class ReflectionExtensions
    {
		/// <summary>
		/// Invoke the specified static method of the 
		/// specified (extension method "current") type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type"></param>
		/// <param name="methodName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static T InvokeStatic<T>(this Type type, string methodName, params object[] args)
		{
			Args.ThrowIfNull(type);
			Args.ThrowIfNull(methodName);
			return (T)type.GetMethod(methodName).Invoke(null, args);
		}
		public static T Invoke<T>(this object instance, string methodName, params object[] args)
		{
			Args.ThrowIfNull(instance, "instance");
			Args.ThrowIfNull(methodName, "methodName");
			return (T)instance.GetType().GetMethod(methodName).Invoke(instance, args);
		}

		public static void Invoke(this object instance, string methodName, params object[] args)
		{
			Args.ThrowIfNull(instance, "instance");
			Args.ThrowIfNull(methodName, "methodName");
			instance.GetType().GetMethod(methodName).Invoke(instance, args);
		}

		public static bool HasProperty(this object instance, string propertyName)
		{
			Args.ThrowIfNull(instance, "instance");
			PropertyInfo ignore;
			return HasProperty(instance, propertyName, out ignore);
		}

		public static bool HasProperty(this object instance, string propertyName, out PropertyInfo prop)
		{
			Args.ThrowIfNull(instance, "instance");
			Type type = instance.GetType();
			prop = type.GetProperty(propertyName);
			return prop != null;
		}

		/// <summary>
        /// Get the property of the current instance with the specified name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="propertyName">The name of the property value to retrieve</param>
        /// <returns></returns>
        public static T Property<T>(this object instance, string propertyName)
        {
			return (T)Property(instance, propertyName);
        }

		public static object Property(this object instance, string propertyName)
		{
			Args.ThrowIfNull(instance, "instance");
			Type type = instance.GetType();
			PropertyInfo property = type.GetProperty(propertyName);
			if (property == null)
			{
				PropertyNotFound(propertyName, type);
			}
			return property.GetValue(instance);
		}

        /// <summary>
        /// Set the property with the specified name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object Property(this object instance, string propertyName, object value, bool throwIfPropertyNotFound = true)
        {
			Args.ThrowIfNull(instance, "instance");
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(propertyName);
			if (property == null && throwIfPropertyNotFound)
			{
				PropertyNotFound(propertyName, type);
			}

			if (property != null)
			{
				if (value == DBNull.Value)
				{
					value = null;
				}
				property.SetValue(instance, value, null);				
			}

			return instance;
        }

        public static void EachPropertyInfo(this object instance, Action<PropertyInfo> action)
        {
            Type type = instance.GetType();
            PropertyInfo[] properties = type.GetProperties();
            properties.Each(action);
        }

        public static void EachPropertyInfo(this object instance, Action<PropertyInfo, int> action)
        {
            Type type = instance.GetType();
            PropertyInfo[] properties = type.GetProperties();
            properties.Each(action);
        }

        public static void EachPropertyValue(this object instance, Action<PropertyInfo, object> action)
        {
            instance.EachPropertyInfo(pi =>
            {
                object value = pi.GetValue(instance, null);
                action(pi, value);
            });
        }

        public static void EachPropertyValue(this object instance, Action<PropertyInfo, object, int> action)
        {
            instance.EachPropertyInfo((pi, i) =>
            {
                object value = pi.GetValue(instance, null);
                action(pi, value, i);
            });
        }
		
		private static void PropertyNotFound(string propertyName, Type type)
		{
			Args.Throw<InvalidOperationException>("Specified property ({0}) was not found on object of type ({1})", propertyName, type.Name);
		}

    }
}
