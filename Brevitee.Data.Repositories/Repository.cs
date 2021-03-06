using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Brevitee.Logging;

namespace Brevitee.Data.Repositories
{
	public abstract class Repository : Loggable, IRepository
	{
		public Repository()
		{
			this._canStoreTypes = new HashSet<Type>();
		}

		#region IRepository Members

		HashSet<Type> _canStoreTypes;

		public IEnumerable<Type> StorableTypes
		{
			get
			{
				return _canStoreTypes;
			}
		}

		public virtual void AddType<T>()
		{
			AddType(typeof(T));
		}

		public void AddTypes(IEnumerable<Type> types)
		{
			types.Each(type =>
			{
				AddType(type);
			});
		}

		public virtual void AddType(Type type)
		{
			_canStoreTypes.Add(type);
		}

		public void AddNamespace(Assembly assembly, string ns)
		{
			AddTypes(assembly.GetTypes().Where(t => t.Namespace.Equals(ns)).ToArray());
		}

		public T Save<T>(T toSave) where T : new()
		{
			return (T)Save((object)toSave);
		}

		/// <summary>
		/// Calls update for the specified object toSave if
		/// it has Id greater than 0 otherwise calls Create
		/// </summary>
		/// <param name="toSave"></param>
		/// <returns></returns>
		public object Save(object toSave)
		{
			long id = GetIdValue(toSave);
			object result = null;
			if (id > 0)
			{
				result = Update(toSave);
			}
			else
			{
				result = Create(toSave);
			}

			return result;
		}

		public abstract T Create<T>(T toCreate) where T : new();

		public abstract object Create(object toCreate);

		public abstract T Retrieve<T>(int id) where T : new();
		
		public abstract T Retrieve<T>(long id) where T : new();
		public abstract IEnumerable<T> RetrieveAll<T>() where T : new();
		public abstract IEnumerable<object> RetrieveAll(Type type);
		public abstract object Retrieve(Type objectType, long id);
		public abstract object Retrieve(Type objectType, string uuid);
		public abstract IEnumerable<object> Query(string propertyName, object propertyValue);
		public abstract IEnumerable<object> Query(dynamic query);
		public abstract IEnumerable<T> Query<T>(Func<T, bool> query);
		public abstract IEnumerable<object> Query(Type type, Func<object, bool> predicate);
		public abstract IEnumerable<T> Query<T>(dynamic query) where T : class, new();
		public abstract T Update<T>(T toUpdate) where T : new();
		public abstract object Update(object toUpdate);
		public abstract bool Delete<T>(T toDelete) where T : new();
		public abstract bool Delete(object toDelete);
		#endregion

		public Exception LastException { get; protected set; }

		[Verbosity(VerbosityLevel.Error)]
		public event EventHandler CreateFailed;

		protected void OnCreateFailed(EventArgs args)
		{
			FireEvent(CreateFailed, args);
		}

		[Verbosity(VerbosityLevel.Error)]
		public event EventHandler RetrieveFailed;

		protected void OnRetrieveFailed(EventArgs args)
		{
			FireEvent(RetrieveFailed, args);
		}

		[Verbosity(VerbosityLevel.Error)]
		public event EventHandler UpdateFailed;

		protected void OnUpdateFailed(EventArgs args)
		{
			FireEvent(UpdateFailed, args);
		}

		[Verbosity(VerbosityLevel.Error)]
		public event EventHandler DeleteFailed;
		protected void OnDeleteFailed(EventArgs args)
		{
			FireEvent(DeleteFailed, args);
		}

		public void AddNamespace(Type type)
		{
			AddNamespace(type.Namespace, type.Assembly);
		}

		public void AddNamespace(string nameSpace, Assembly assembly)
		{
			foreach (Type type in assembly.GetTypes().Where(t => t.Namespace == nameSpace))
			{
				AddType(type);
			}
		}

		protected internal static PropertyInfo GetKeyProperty(Type type)
		{
			return Meta.GetKeyProperty(type);
		}

		protected internal static PropertyInfo GetKeyProperty<T>()
		{
			return GetKeyProperty(typeof(T));
		}

		protected internal static long GetIdValue(object value)
		{
			return Meta.GetId(value);
		}
			
	}
}
