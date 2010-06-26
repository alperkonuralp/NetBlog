using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace NetBlog.Model.Common
{
    public abstract class DataManagerBase : IDisposable
    {
        #region IDisposable Members
        private bool _isDisposed = false;

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }

        #endregion

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(
                "Data Source=.; Initial Catalog=NetBlogDB;" +
                "User ID=NetBlogDBUser; Password=U53r;"
                );
        }

        /// <summary>
        /// Executes to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="del">The del.</param>
        /// <param name="pars">The pars.</param>
        /// <returns></returns>
        protected List<T> ExecuteToList<T>(
            string sql,
            GetEntityFromDataReaderDelegate<T> del,
            params SqlParameter[] pars)
            where T : EntityBase
        {
            using (SqlConnection sc = GetConnection())
            {
                var scom = sc.CreateCommand();
                scom.CommandText = sql;

                if (pars != null && pars.Length > 0)
                {
                    scom.Parameters.AddRange(pars);
                }

                sc.Open();

                var sdr = scom.ExecuteReader();
                List<T> list = new List<T>();
                while (sdr.Read())
                {
                    list.Add(del(sdr));
                }

                sdr.Close();
                return list;
            }
        }

        /// <summary>
        /// Executes to single row.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="del">The del.</param>
        /// <param name="pars">The pars.</param>
        /// <returns></returns>
        protected T ExecuteToSingleRow<T>(
            string sql,
            GetEntityFromDataReaderDelegate<T> del,
            params SqlParameter[] pars)
            where T : EntityBase
        {
            using (SqlConnection sc = GetConnection())
            {
                var scom = sc.CreateCommand();
                scom.CommandText = sql;
                
                if (pars != null && pars.Length > 0)
                {
                    scom.Parameters.AddRange(pars);
                }

                sc.Open();

                var sdr = scom.ExecuteReader();

                if (sdr.Read())
                {
                    return del(sdr);
                }

                sdr.Close();
                return null;
            }
        }


        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="pars">The pars.</param>
        /// <returns></returns>
        protected int ExecuteNonQuery(
            string sql,
            params SqlParameter[] pars)
        {
            using (SqlConnection sc = GetConnection())
            {
                var scom = sc.CreateCommand();
                scom.CommandText = sql;

                if (pars != null && pars.Length > 0)
                {
                    scom.Parameters.AddRange(pars);
                }

                sc.Open();

                return scom.ExecuteNonQuery();
            }
        }



        protected int ExecuteInsertQueryReturnID(
            string table,
            Dictionary<string, object> columns)
        {
            string sql = string.Format(
                "INSERT INTO {0}({1}) VALUES ({2}); SELECT @@IDENTITY;",
                table,
                string.Join(", ", columns.Keys.ToArray()),
                "@" + string.Join(", @", columns.Keys.ToArray())
                );

            using (SqlConnection sc = GetConnection())
            {
                var scom = sc.CreateCommand();
                scom.CommandText = sql;

                scom.Parameters.AddRange(
                    columns.Select(
                        x => new SqlParameter("@" + x.Key, x.Value))
                    .ToArray());

                sc.Open();

                return (int)scom.ExecuteScalar();
            }
        }









        public static string GetStringFromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetString(i);
        }

        public static int? GetInt32FromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetInt32(i);
        }

        public static short? GetInt16FromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetInt16(i);
        }
        public static long? GetInt64FromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetInt64(i);
        }

        public static float? GetFloatFromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetFloat(i);
        }
        public static double? GetDoubleFromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetDouble(i);
        }

        public static decimal? GetDecimalFromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetDecimal(i);
        }

        public static DateTime? GetDateTimeFromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetDateTime(i);
        }

        public static Guid? GetGuidFromDataReader(
            SqlDataReader sdr, string col)
        {
            int i = sdr.GetOrdinal(col);
            if (sdr.IsDBNull(i))
            {
                return null;
            }

            return sdr.GetGuid(i);
        }
    }

    public delegate T GetEntityFromDataReaderDelegate<T>
        (SqlDataReader sdr) where T : EntityBase;
}
