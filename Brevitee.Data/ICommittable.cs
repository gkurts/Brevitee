using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brevitee.Data
{
    public interface ICommittable: IDeleteable
    {
        void Commit(Database db = null);
        void WriteCommit(SqlStringBuilder sql, Database db = null);
    }
}
