using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Schema; 
using Brevitee.Data.Qi;
using Alsdobo.Models;

namespace Alsdobo.Controllers
{
    [Proxy("email")]
    public partial class Email
    {
        
        public object Create(Alsdobo.Models.Email email)
        {
            return Update(email);
        }

        public object Retrieve(long id)
        {
            return Alsdobo.Models.Email.OneWhere(c => c.KeyColumn == id).ToJsonSafe();
        }

        public object Update(Alsdobo.Models.Email email)
        {
            email.Save();
            return email.ToJsonSafe();
        }
        
        public void Delete(Alsdobo.Models.Email email)
        {
            email.Delete();            
        }

        public object[] Search(QiQuery query)
        {
            return new Alsdobo.Models.Qi.Email().Where(query);
        }

        [Exclude]
        public static Type GetModelType()
        {
            return typeof(Alsdobo.Models.Email);          
        }

    }
}