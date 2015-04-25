// model is SchemaDefinition
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Exegete
{
	// schema = Exegete 
    public static class ExegeteContext
    {
		public static string ConnectionName
		{
			get
			{
				return "Exegete";
			}
		}

		public static Database Db
		{
			get
			{
				return Brevitee.Data.Db.For(ConnectionName);
			}
		}

﻿
	public class LanguageQueryContext
	{
			public LanguageCollection Where(WhereDelegate<LanguageColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Language.Where(where, db);
			}
		   
			public LanguageCollection Where(WhereDelegate<LanguageColumns> where, OrderBy<LanguageColumns> orderBy = null, Database db = null)
			{
				return Brevitee.Exegete.Language.Where(where, orderBy, db);
			}

			public Language OneWhere(WhereDelegate<LanguageColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Language.OneWhere(where, db);
			}
		
			public Language FirstOneWhere(WhereDelegate<LanguageColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Language.FirstOneWhere(where, db);
			}

			public LanguageCollection Top(int count, WhereDelegate<LanguageColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Language.Top(count, where, db);
			}

			public LanguageCollection Top(int count, WhereDelegate<LanguageColumns> where, OrderBy<LanguageColumns> orderBy, Database db = null)
			{
				return Brevitee.Exegete.Language.Top(count, where, orderBy, db);
			}

			public long Count(WhereDelegate<LanguageColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Language.Count(where, db);
			}
	}

	static LanguageQueryContext _languages;
	static object _languagesLock = new object();
	public static LanguageQueryContext Languages
	{
		get
		{
			return _languagesLock.DoubleCheckLock<LanguageQueryContext>(ref _languages, () => new LanguageQueryContext());
		}
	}﻿
	public class TextQueryContext
	{
			public TextCollection Where(WhereDelegate<TextColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Text.Where(where, db);
			}
		   
			public TextCollection Where(WhereDelegate<TextColumns> where, OrderBy<TextColumns> orderBy = null, Database db = null)
			{
				return Brevitee.Exegete.Text.Where(where, orderBy, db);
			}

			public Text OneWhere(WhereDelegate<TextColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Text.OneWhere(where, db);
			}
		
			public Text FirstOneWhere(WhereDelegate<TextColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Text.FirstOneWhere(where, db);
			}

			public TextCollection Top(int count, WhereDelegate<TextColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Text.Top(count, where, db);
			}

			public TextCollection Top(int count, WhereDelegate<TextColumns> where, OrderBy<TextColumns> orderBy, Database db = null)
			{
				return Brevitee.Exegete.Text.Top(count, where, orderBy, db);
			}

			public long Count(WhereDelegate<TextColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Text.Count(where, db);
			}
	}

	static TextQueryContext _texts;
	static object _textsLock = new object();
	public static TextQueryContext Texts
	{
		get
		{
			return _textsLock.DoubleCheckLock<TextQueryContext>(ref _texts, () => new TextQueryContext());
		}
	}﻿
	public class TranslationQueryContext
	{
			public TranslationCollection Where(WhereDelegate<TranslationColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Translation.Where(where, db);
			}
		   
			public TranslationCollection Where(WhereDelegate<TranslationColumns> where, OrderBy<TranslationColumns> orderBy = null, Database db = null)
			{
				return Brevitee.Exegete.Translation.Where(where, orderBy, db);
			}

			public Translation OneWhere(WhereDelegate<TranslationColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Translation.OneWhere(where, db);
			}
		
			public Translation FirstOneWhere(WhereDelegate<TranslationColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Translation.FirstOneWhere(where, db);
			}

			public TranslationCollection Top(int count, WhereDelegate<TranslationColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Translation.Top(count, where, db);
			}

			public TranslationCollection Top(int count, WhereDelegate<TranslationColumns> where, OrderBy<TranslationColumns> orderBy, Database db = null)
			{
				return Brevitee.Exegete.Translation.Top(count, where, orderBy, db);
			}

			public long Count(WhereDelegate<TranslationColumns> where, Database db = null)
			{
				return Brevitee.Exegete.Translation.Count(where, db);
			}
	}

	static TranslationQueryContext _translations;
	static object _translationsLock = new object();
	public static TranslationQueryContext Translations
	{
		get
		{
			return _translationsLock.DoubleCheckLock<TranslationQueryContext>(ref _translations, () => new TranslationQueryContext());
		}
	}    }
}																								
