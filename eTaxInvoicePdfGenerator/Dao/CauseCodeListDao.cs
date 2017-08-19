﻿using ETDA.Invoice.Api.Entities;
using SqliteConnector;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace eTaxInvoicePdfGenerator.Dao
{
    internal class CauseCodeListDao
    {
        private Sqlite sqlite;
        private string tableName = "cause_code_list";

        public CauseCodeListDao()
        {
            string base_folder = System.AppDomain.CurrentDomain.BaseDirectory;
            sqlite = new Sqlite(base_folder + "database.db");
        }

        internal List<CauseCodeListObj> list(string type)
        {
            string txtQuery = string.Format("SELECT * FROM {0} WHERE type = @type", this.tableName);
            try
            {
                List<CauseCodeListObj> items = new List<CauseCodeListObj>();
                using (SQLiteConnection c = new SQLiteConnection(sqlite.ConnectionString))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(txtQuery, c))
                    {
                        cmd.Parameters.AddWithValue("@type", type);
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            items.Add(new CauseCodeListObj("0", "กรุณาเลือกเหตุผล", "", ""));
                            while (dr.Read())
                            {
                                CauseCodeListObj obj = new CauseCodeListObj();
                                obj.code = dr["code"].ToString();
                                obj.description = dr["description"].ToString();
                                obj.type = dr["type"].ToString();
                                obj.cases = dr["case"].ToString();
                                items.Add(obj);
                            }
                        }
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal CauseCodeListObj select(string code)
        {
            string txtQuery = string.Format("SELECT * FROM {0} WHERE Code = @code", this.tableName);
            try
            {
                CauseCodeListObj data = new CauseCodeListObj();
                using (SQLiteConnection c = new SQLiteConnection(sqlite.ConnectionString))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(txtQuery, c))
                    {
                        cmd.Parameters.AddWithValue("@code", code);
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                data.code = dr["code"].ToString();
                                data.description = dr["description"].ToString();
                                data.type = dr["type"].ToString();
                                data.cases = dr["case"].ToString();
                            }
                        }
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}