using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Logging;
using System.Reflection;

namespace Brevitee.Data.Repositories
{
	public interface IRepository : ILoggable
    {
		IEnumerable<Type> StorableTypes { get; }
		void AddType(Type type);
		void AddNamespace(Assembly assembly, string ns);
		void AddTypes(IEnumerable<Type> types);
		void AddType<T>();
		T Save<T>(T toSave) where T : new();
		object Save(object toSave);
		T Create<T>(T toCreate) where T : new();
		object Create(object toCreate);
		T Retrieve<T>(int id) where T : new();
        T Retrieve<T>(long id) where T: new();
		IEnumerable<T> RetrieveAll<T>() where T : new();
		IEnumerable<object> RetrieveAll(Type type);
		IEnumerable<object> Query(string propertyName, object propertyValue);
		object Retrieve(Type objectType, long id);
		object Retrieve(Type objectType, string uuid);
		IEnumerable<T> Query<T>(dynamic query) where T : class, new();
		IEnumerable<T> Query<T>(Func<T, bool> query);
		IEnumerable<object> Query(Type type, Func<object, bool> predicate);
		T Update<T>(T toUpdate) where T : new();
		object Update(object toUpdate);
		bool Delete<T>(T toDelete) where T : new();
		bool Delete(object toDelete);
    }
}
