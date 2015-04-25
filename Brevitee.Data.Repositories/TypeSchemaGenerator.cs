using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Brevitee.Data.Schema;
using Brevitee.Logging;

namespace Brevitee.Data.Repositories
{
	public class TypeSchemaGenerator: Loggable 
	{
		private UuidSchemaManager _schemaManager;

		public TypeSchemaGenerator() 
		{
			this._schemaManager = new UuidSchemaManager();
		}

		[Verbosity(VerbosityLevel.Information, MessageFormat="SchemaName (parameter): {SchemaName}")]
		public event EventHandler CreatingSchemaStarted;

		[Verbosity(VerbosityLevel.Information, MessageFormat = "SchemaName (parameter): {SchemaName}")]
		public event EventHandler CreatingTypeSchemaStarted;

		[Verbosity(VerbosityLevel.Information, MessageFormat="SchemaName (parameter): {SchemaName}")]
		public event EventHandler CreatingTypeSchemaFinished;

		[Verbosity(VerbosityLevel.Information, MessageFormat="SchemaName (parameter || types.Md5() ): {SchemaName}")]
		public event EventHandler WritingDaoSchemaStarted;

		[Verbosity(VerbosityLevel.Information, MessageFormat="SchemaName (parameter || types.Md5() ): {SchemaName}")]
		public event EventHandler WritingDaoSchemaFinished;

		/// <summary>
		/// Holds the name of the currently generating
		/// schema
		/// </summary>
		public string SchemaName { get; set; }
		public bool AddIdField { get; set; }
		public bool AddAuditFields { get; set; }
		public bool IncludeModifiedBy { get; set; }
		public bool IncludeCreatedBy { get; set; }
		
		public SchemaDefinitionCreateResult CreateSchemaDefinition(IEnumerable<Type> types, string schemaName = null)
		{
			SchemaName = schemaName ?? "null";
			FireEvent(CreatingSchemaStarted, EventArgs.Empty);

			AddAugmentations();

			FireEvent(CreatingTypeSchemaStarted, EventArgs.Empty);
			TypeSchema typeSchema = CreateTypeSchema(types);
			FireEvent(CreatingTypeSchemaFinished, EventArgs.Empty);

			schemaName = schemaName ?? string.Format("_{0}_", typeSchema.Tables.ToArray().ToDelimited(t => t.FullName, ", ").Md5());
			SchemaName = schemaName;
			_schemaManager.SetSchema(schemaName, false);
			SchemaName = schemaName;

			FireEvent(WritingDaoSchemaStarted, EventArgs.Empty);
			List<KeyColumn> missingKeyColumns = new List<KeyColumn>();
			List<ForeignKeyColumn> missingForeignKeyColumns = new List<ForeignKeyColumn>();
			WriteDaoSchema(typeSchema, _schemaManager, missingKeyColumns, missingForeignKeyColumns);
			FireEvent(WritingDaoSchemaFinished, EventArgs.Empty);

			SchemaDefinitionCreateResult result = new SchemaDefinitionCreateResult(_schemaManager.GetCurrentSchema(), typeSchema,
				missingKeyColumns.ToArray(), missingForeignKeyColumns.ToArray());

			return result;
		}

		protected internal TypeSchema CreateTypeSchema(params Type[] types)
		{
			return CreateTypeSchema((IEnumerable<Type>)types);
		}

		protected internal TypeSchema CreateTypeSchema(IEnumerable<Type> types)
		{
			HashSet<Type> tableTypes = new HashSet<Type>();
			HashSet<TypeFk> foreignKeyTypes = new HashSet<TypeFk>();
			HashSet<TypeXref> xrefTypes = new HashSet<TypeXref>();

			foreach (Type type in types)
			{
				foreach (Type tableType in GetTableTypes(type))
				{
					tableTypes.Add(tableType);
				}
			}

			foreach (TypeFk typeFk in GetForeignKeyTypes(tableTypes))
			{
				foreignKeyTypes.Add(typeFk);
			}

			foreach (TypeXref xref in GetXrefTypes(tableTypes))
			{
				xrefTypes.Add(xref);
			}

			return new TypeSchema { Tables = tableTypes, ForeignKeys = foreignKeyTypes, Xrefs = xrefTypes };
		}

		protected internal static void WriteDaoSchema(TypeSchema typeSchema, SchemaManager schemaManager, List<KeyColumn> missingKeyColumns = null, List<ForeignKeyColumn> missingForeignKeyColumns = null)
		{
			HashSet<Type> tableTypes = typeSchema.Tables;
			HashSet<TypeFk> foreignKeyTypes = typeSchema.ForeignKeys;
			HashSet<TypeXref> xrefTypes = typeSchema.Xrefs;

			foreach (Type tableType in tableTypes)
			{
				string tableName = GetTableNameForType(tableType);
				schemaManager.AddTable(tableName);
				schemaManager.ExecutePreColumnAugmentations(tableName);
				AddPropertyColumns(tableType, schemaManager);
				schemaManager.ExecutePostColumnAugmentations(tableName);
			}

			// accounting for missing columns
			// loop primary keys and fks separately to ensure 
			// missing keys get recorded prior to trying to add the
			// fks
			foreach (TypeFk foreignKey in foreignKeyTypes)
			{
				TypeSchemaPropertyInfo keyInfo = foreignKey.PrimaryKeyProperty as TypeSchemaPropertyInfo;				
				if (keyInfo != null)
				{
					KeyColumn key = keyInfo.ToKeyColumn();
					schemaManager.AddColumn(key.TableName, key);
					schemaManager.SetKeyColumn(key.TableName, key.Name);
					if (missingKeyColumns != null)
					{
						missingKeyColumns.Add(key);
					}
				}
			}

			foreach (TypeFk foreignKey in foreignKeyTypes)
			{
				TypeSchemaPropertyInfo fkInfo = foreignKey.ForeignKeyProperty as TypeSchemaPropertyInfo;
				if (fkInfo != null)
				{
					PropertyInfo keyProperty = GetKeyProperty(foreignKey.PrimaryKeyType, missingKeyColumns);
					string referencedKeyName = keyProperty.Name;

					ForeignKeyColumn fk = fkInfo.ToForeignKeyColumn();
					fk.AllowNull = true;
					schemaManager.AddColumn(fk.TableName, fk);
					schemaManager.SetForeignKey(fk.ReferencedTable, fk.TableName, fk.Name, referencedKeyName);
					if (missingForeignKeyColumns != null)
					{
						missingForeignKeyColumns.Add(fk);
					}
				}
			}
			// /end - accounting for missing columns

			foreach (TypeFk foreignKey in foreignKeyTypes)
			{
				schemaManager.SetForeignKey(
					GetTableNameForType(foreignKey.PrimaryKeyType),
					GetTableNameForType(foreignKey.ForeignKeyType),
					foreignKey.ForeignKeyProperty.Name);
			}

			foreach (TypeXref xref in xrefTypes)
			{
				schemaManager.SetXref(GetTableNameForType(xref.Left), GetTableNameForType(xref.Right));
			}
		}

		protected internal HashSet<Type> GetTableTypes(Type type)
		{
			HashSet<Type> results = new HashSet<Type>();
			results.Add(type);
			Traverse(type, results);
			return results;
		}

		protected internal HashSet<TypeFk> GetForeignKeyTypes(Type type) 
		{
			return GetForeignKeyTypes(new Type[] {type});
		}

		protected internal HashSet<TypeFk> GetForeignKeyTypes(IEnumerable<Type> types) 
		{
			HashSet<TypeFk> results = new HashSet<TypeFk>();
			foreach (Type type in types) 
			{
				foreach (TypeFk fk in GetReferencingForeignKeyTypesFor(type)) 
				{
					results.Add(fk);
				}
			}

			return results;
		}

		protected internal HashSet<TypeXref> GetXrefTypes(Type type) 
		{
			return GetXrefTypes(new Type[] {type});
		}

		protected internal HashSet<TypeXref> GetXrefTypes(IEnumerable<Type> types) 
		{
			HashSet<TypeXref> results = new HashSet<TypeXref>();
			foreach (Type type in types) 
			{
				foreach (TypeXref xref in GetXrefTypesFor(type)) 
				{
					results.Add(xref);
				}
			}
			return results;
		}

		/// <summary>
		/// Get the properties where the type of the
		/// property is of a type that has a property that is
		/// an enumerable of the type specified
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		protected internal IEnumerable<TypeXref> GetXrefTypesFor(Type type) 
		{
			HashSet<TypeXref> xrefTypes = new HashSet<TypeXref>();
			foreach (PropertyInfo property in type.GetProperties())
			{
				if (!_daoPrimitives.Contains(property.PropertyType)) 
				{
					Type enumerableType = property.GetEnumerableType();
					if (enumerableType != null) 
					{
						PropertyInfo leftEnumerable;
						PropertyInfo righEnumerable;
						if (AreXrefs(type, enumerableType, out leftEnumerable, out righEnumerable)) 
						{
							xrefTypes.Add(new TypeXref { Left = type, Right = enumerableType, LeftCollectionProperty = leftEnumerable, RightCollectionProperty = righEnumerable });
						}
					}
				}
			}

			return xrefTypes;
		}
		protected internal static bool AreXrefs(Type left, Type right)
		{
			PropertyInfo ignoreLeft;
			PropertyInfo ignoreRight;
			return AreXrefs(left, right, out ignoreLeft, out ignoreRight);
		}

		protected internal static bool AreXrefs(Type left, Type right, out PropertyInfo leftEnumerable, out PropertyInfo rightEnumerable)
		{
			rightEnumerable = null;
			return left.HasEnumerableOfMe(right, out leftEnumerable) && right.HasEnumerableOfMe(left, out rightEnumerable);
		}

		/// <summary>
		/// A string representation of the UtcNow at the time
		/// of reference.  <see cref="Brevitee.Instant" />
		/// </summary>
		public string Instant 
		{
			get { return new Instant(DateTime.UtcNow).ToString(); }
		}

		public string Message { get; set; }

		/// <summary>
		/// The event that occurs when a Type is found in the current
		/// TypeSchema hierarchy with no Key property specified (the Type's key is determined
		/// by whether a property has the KeyAttribute custom attribute or
		/// the name of "Id")
		/// </summary>
		[Verbosity(VerbosityLevel.Warning, MessageFormat = "[{Instant}]:: KeyPropertyNotFound: {Message}\r\n")]
		public event EventHandler KeyPropertyNotFound;

		/// <summary>
		/// The event that occurs when a Type is found in the current
		/// TypeSchema hierarchy with an IEnumerable&lt;T&gt; property where the underlying type of
		/// the IEnumerable doesn't have a property referencing
		/// the current Type's key (the Type's key is determined
		/// by whether a property has the KeyAttribute custom attribute or
		/// the name of "Id")
		/// </summary>
		[Verbosity(VerbosityLevel.Warning, MessageFormat = "[{Instant}]:: ReferencingPropertyNotFound: {Message}\r\n")]
		public event EventHandler ReferencingPropertyNotFound;


		/// The event that occurs when a Type is found in the current
		/// TypeSchema hierarchy with an IEnumerable&lt;T&gt; property where the underlying type of
		/// the IEnumerable doesn't have a property of the parent Type to hold the instance of
		/// the parent.
		/// </summary>
		[Verbosity(VerbosityLevel.Warning, MessageFormat = "[{Instant}]:: ChildParentPropertyNotFound: {Message}\r\n")]
		public event EventHandler ChildParentPropertyNotFound;


		/// <summary>
		/// Get the types for each IEnumerable property of the specified type
		/// </summary>
		/// <param name="parentType"></param>
		/// <returns></returns>
		protected internal IEnumerable<TypeFk> GetReferencingForeignKeyTypesFor(Type parentType)
		{
			HashSet<TypeFk> results = new HashSet<TypeFk>();
			foreach (PropertyInfo property in parentType.GetProperties()) 
			{
				Type propertyType = property.PropertyType;
				if (propertyType != typeof(string) && property.IsEnumerable() && !AreXrefs(parentType, property.GetEnumerableType()))
				{
					PropertyInfo keyProperty = GetKeyProperty(parentType);
					Type foreignKeyType = property.GetEnumerableType();
					PropertyInfo referencingProperty = null;
					if (keyProperty == null)
					{
						Message = "KeyProperty not found for type {0}"._Format(parentType.FullName);
						FireEvent(KeyPropertyNotFound, EventArgs.Empty);
						keyProperty = new TypeSchemaPropertyInfo("Id", parentType);
					}

					string referencingPropertyName = "{0}{1}"._Format(parentType.Name, keyProperty.Name);
					referencingProperty = foreignKeyType.GetProperty(referencingPropertyName);

					if (referencingProperty == null)
					{
						Message = "Referencing property not found {0}: Parent type ({1}), ForeignKeyType ({2})"._Format(referencingPropertyName, parentType.FullName, foreignKeyType.FullName);
						FireEvent(ReferencingPropertyNotFound, EventArgs.Empty);
						referencingProperty = new TypeSchemaPropertyInfo(referencingPropertyName, parentType, foreignKeyType);
					}

					PropertyInfo childParentProperty = foreignKeyType.GetProperty(parentType.Name);
					if(childParentProperty == null)
					{
						Message = "ChildParentProperty was not found {0}.{1}: Parent type({2}), ForeignKeyType ({3})"._Format(foreignKeyType.Name, parentType.Name, parentType.FullName, foreignKeyType.FullName);
						FireEvent(ChildParentPropertyNotFound, EventArgs.Empty);
						childParentProperty = new TypeSchemaPropertyInfo(parentType.Name, foreignKeyType);
					}

					results.Add(new TypeFk
					{
						PrimaryKeyType = parentType,
						PrimaryKeyProperty = keyProperty,
						ForeignKeyType = foreignKeyType,
						ForeignKeyProperty = referencingProperty,
						ChildParentProperty = childParentProperty,
						CollectionProperty = property
					});
				}
			}

			return results;
		}

		protected internal static PropertyInfo GetKeyProperty(Type type, List<KeyColumn> keyColumnsToCheck = null) 
		{
			PropertyInfo keyProperty = type.GetFirstProperyWithAttributeOfType<KeyAttribute>();
			if (keyProperty == null) 
			{
				keyProperty = type.GetProperty("Id");
			}

			if (keyProperty == null && keyColumnsToCheck != null)
			{
				KeyColumn keyColumn = keyColumnsToCheck.FirstOrDefault(kc => kc.TableName.Equals(GetTableNameForType(type)));
				if(keyColumn != null)
				{
					keyProperty = new TypeSchemaPropertyInfo(keyColumn.Name, type);
				}
			}
			return keyProperty;
		}

		protected internal static string GetTableNameForType(Type type)
		{
			string tableName = "{0}Dao"._Format(type.Name);
			return tableName;
		}
		
		static readonly List<Type> _daoPrimitives = new List<Type> { typeof(bool), typeof(int), typeof(long), typeof(decimal), typeof(byte[]), typeof(DateTime), typeof(string) };

		protected internal static DataTypes GetColumnDataType(PropertyInfo property)
		{
			DataTypes dataType = DataTypes.String;
			Type propertyType = property.PropertyType;
			if (propertyType == typeof(bool) ||
				propertyType == typeof(bool?))
			{
				dataType = DataTypes.Boolean;
			}
			else if (propertyType == typeof(int) ||
				propertyType == typeof(int?))
			{
				dataType = DataTypes.Int;
			}
			else if (propertyType == typeof(long) ||
				propertyType == typeof(long?))
			{
				dataType = DataTypes.Long;
			}
			else if (propertyType == typeof(decimal) ||
				propertyType == typeof(decimal?))
			{
				dataType = DataTypes.Decimal;
			}
			else if (property.PropertyType == typeof(byte[]) ||
				propertyType == typeof(byte?[]))
			{
				dataType = DataTypes.Byte;
			}
			else if (property.PropertyType == typeof(DateTime) ||
				propertyType == typeof(DateTime?))
			{
				dataType = DataTypes.DateTime;
			}
			return dataType;
		}

		private static void AddPropertyColumns(Type type, SchemaManager schemaManager)
		{
			string tableName = GetTableNameForType(type);
			foreach (PropertyInfo property in type.GetProperties())
			{
				DataTypes dataType = GetColumnDataType(property);
				if (!property.IsEnumerable() || property.PropertyType == typeof(string))
				{
					Column columnToAdd = new Column(property.Name.LettersOnly(), dataType);
					schemaManager.AddColumn(tableName, columnToAdd);
					if (property.HasCustomAttributeOfType<KeyAttribute>() || property.Name.Equals("Id"))
					{
						schemaManager.SetKeyColumn(tableName, columnToAdd.Name);
					}
				}
			}
		}

		private void Traverse(Type type, HashSet<Type> results)
		{
			Queue<Type> queue = new Queue<Type>();
			queue.Enqueue(type);
			while (queue.Count > 0)
			{
				Type current = queue.Dequeue();
				results.Add(current);
				foreach (TypeFk typeFk in GetReferencingForeignKeyTypesFor(current))
				{
					if (!results.Contains(typeFk.PrimaryKeyType))
					{
						queue.Enqueue(typeFk.PrimaryKeyType);
					}
					if (!results.Contains(typeFk.ForeignKeyType))
					{
						queue.Enqueue(typeFk.ForeignKeyType);
					}
				}

				foreach (TypeXref xref in GetXrefTypesFor(current))
				{
					if (!results.Contains(xref.Left))
					{
						queue.Enqueue(xref.Left);
					}

					if (!results.Contains(xref.Right))
					{
						queue.Enqueue(xref.Right);
					}
				}
			}
		}

		private void AddAugmentations()
		{
			if (AddIdField)
			{
				_schemaManager.PreColumnAugmentations.Add(new AddIdKeyColumnAugmentation());
			}

			if (AddAuditFields)
			{
				_schemaManager.PostColumnAugmentations.Add(new AddAuditColumnsAugmentation { IncludeModifiedBy = IncludeModifiedBy, IncludeCreatedBy = IncludeCreatedBy });
			}
		}

	}
}
