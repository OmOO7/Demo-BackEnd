using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIDemo
{
    public class DataContest
    {
        internal class DataContext
        {
            private const byte Connectiontimeout = 30;
            private static string Connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


            #region GetData
            public static DataTable ExcecuteSP(string spName, params SqlParameter[] parameters)
            {
                using (SqlConnection connection = new SqlConnection(Connectionstring))
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand(spName, connection);
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Connectiontimeout;
                        SqlDataAdapter sqldataadapter = new SqlDataAdapter(cmd);
                        sqldataadapter.Fill(dt);

                        if (dt == null)
                            return null;
                        else
                            if (dt.Rows.Count > 0)
                            return dt;
                        else
                            return null;
                    }

                    catch (SqlException sqlex)
                    {
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            public static DataSet DSExcecuteSP(String spName, params SqlParameter[] parameters)
            {
                using (SqlConnection con = new SqlConnection(Connectionstring))
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand(spName, con);
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Connectiontimeout;
                        SqlDataAdapter sqldataadapter = new SqlDataAdapter(cmd);
                        sqldataadapter.Fill(ds);

                        if (ds.Tables.Count > 0)
                            return ds.Tables[0].Rows.Count > 0 ? ds : null;
                        else
                            return null;

                    }
                    catch (SqlException sqlex)
                    {
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }

            #endregion

            #region AddUpdateRemove
            public static int ExcecuteNonQuery(String spName, params SqlParameter[] parameters)
            {

                var dataview = new System.Data.DataView();
                using (SqlConnection con = new SqlConnection(Connectionstring))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(spName, con))
                        {
                            int ReturnParam = byte.MinValue;
                            con.Open();
                            if (parameters != null && parameters.Length > 0)
                            {
                                cmd.Parameters.AddRange(parameters);

                            }
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Connectiontimeout;
                            ReturnParam = cmd.ExecuteNonQuery();
                            return ReturnParam;
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            #endregion

        }
    }
}