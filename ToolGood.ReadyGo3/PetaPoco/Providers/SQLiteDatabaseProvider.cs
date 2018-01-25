﻿using System.Data.Common;
using ToolGood.ReadyGo3.PetaPoco.Core;

namespace ToolGood.ReadyGo3.PetaPoco.Providers
{
    public class SQLiteDatabaseProvider : DatabaseProvider
    {
        public override DbProviderFactory GetFactory()
        {
            return GetFactory("System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Culture=neutral, PublicKeyToken=db937bc2d44ff139");
        }

        public override object MapParameterValue(object value)
        {
            if (value is uint)
                return (long) ((uint) value);

            return base.MapParameterValue(value);
        }

        public override object ExecuteInsert(Database db, System.Data.IDbCommand cmd, string primaryKeyName)
        {
            if (primaryKeyName != null)
            {
                cmd.CommandText += ";\nSELECT last_insert_rowid();";
                return db.ExecuteScalarHelper(cmd);
            }
            else
            {
                db.ExecuteNonQueryHelper(cmd);
                return -1;
            }
        }

        public override string GetExistsSql()
        {
            return "SELECT EXISTS (SELECT 1 FROM {0} WHERE {1})";
        }
    }
}