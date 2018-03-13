﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if !NET40
using SqlCommand = System.Data.Common.DbCommand;


namespace ToolGood.ReadyGo3.PetaPoco.Core
{
    partial class DatabaseProvider
    {
        public virtual Task<object> ExecuteInsertAsync(Database db, SqlCommand cmd, string PrimaryKeyName)
        {
            cmd.CommandText += ";\nSELECT @@IDENTITY AS NewID;";
            return db.ExecuteScalarHelperAsync(cmd);
        }

    }
}
#endif