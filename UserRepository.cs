using APIDemo.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static APIDemo.DataContest;

namespace APIDemo
{
    public class UserRepository
    {
        static Logger Logger;
        public UserRepository()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }
        public static DataTable UserLogin(UserLogin userlogin)
        {
            try
            {
                SqlParameter[] AllParameter = {
                        new SqlParameter ("@UserName", userlogin.UserName),
                        //new SqlParameter ("@Pwd",GeneralFunction.Encrypt(userlogin.Password)),
                        new SqlParameter ("@Pwd",userlogin.Password),
                };
                return DataContext.ExcecuteSP("USP_Login", AllParameter);
            }

            catch (SqlException ex)
            {
                Logger.Error(ex, "SQLError!");
                return null;
            }

            catch (Exception ex)
            {
                Logger.Error(ex, "Error!");
                return null;
            }
        }

//#region UserRegistration
//        public static int UserRegistration(UserRegistration userRegistration)
//        {
//            try
//            {
//                SqlParameter[] AllParameter = {
//                    new SqlParameter("@AsType","C"),
//                    new SqlParameter ("@IsBlock",0),
//                    new SqlParameter ("@AgtName", userRegistration.AgtName),
//                    new SqlParameter ("@Email", userRegistration.Email),
//                    new SqlParameter ("@Currency", userRegistration.Currency),
//                    new SqlParameter ("@Nationality",userRegistration.Nationality),
//                    new SqlParameter ("@Title", userRegistration.Title),
//                    new SqlParameter ("@FirstName",userRegistration.FirstName),
//                    new SqlParameter ("@LastName", userRegistration.LastName),
//                    new SqlParameter ("@MobileNo",userRegistration.MobileNo),
//                    //new SqlParameter ("@EmailId",userRegistration.EmailId),
//                    new SqlParameter ("@Address", userRegistration.Address),
//                    new SqlParameter ("@CityId", userRegistration.CityId),
//                    new SqlParameter ("@UserName", userRegistration.UserName),
//                    new SqlParameter ("@Pwd",GeneralFunction.Encrypt(userRegistration.Pwd)),
//                    new SqlParameter ("@OutParam",0),
                        
//                        //new SqlParameter ("@SalesEmpId",0),

//                };
//                AllParameter[14].Direction = ParameterDirection.Output;
//                DataContext.ExcecuteNonQuery("usp_Registration", AllParameter);
//                return Convert.ToInt32(AllParameter[14].Value);
//            }

//            catch (SqlException ex)
//            {
//                //Logger.Error(ex, "SQLError!");
//                return 0;
//            }

//            catch (Exception ex)
//            {
//                //Logger.Error(ex, "Error!");
//                return 0;
//            }
//        }
//        #endregion

        #region GetCountry
        public static DataTable GetCountry()
        {
            try
            {
                SqlParameter[] AllParameter = {
                        new SqlParameter ("@column", " CountryCode,	CountryName"),
                        new SqlParameter ("@TableName", "Mst_Country"),
                        new SqlParameter ("@wherecondition", "IsActive=1")
                };
                return DataContext.ExcecuteSP("GetTableWhere", AllParameter);
            }

            catch (SqlException ex)
            {
                //Logger.Error(ex, "SQLError!");
                return null;
            }

            catch (Exception ex)
            {
                //Logger.Error(ex, "Error!");
                return null;
            }
        }
        #endregion

        #region GetCityByCountryId
        //public static DataTable GetCityByCountryId(ListCityAndCountry oListCityAndCountry)
        //{
        //    try
        //    {
        //        SqlParameter[] AllParameter = {
        //                new SqlParameter ("@column", " CityId,CityName,CountryCode,CountryName,Currency"),
        //                new SqlParameter ("@TableName", "vw_get_giatacity"),
        //                new SqlParameter ("@wherecondition", "IsActive=1 AND CountryCode='"+oListCityAndCountry.CountryCode+"'")
        //        };
        //        return DataContext.ExcecuteSP("GetTableWhere", AllParameter);
        //    }

        //    catch (SqlException ex)
        //    {
        //        Logger.Error(ex, "SQLError!");
        //        return null;
        //    }

        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Error!");
        //        return null;
        //    }
        //}
        #endregion

        #region GetCityByCityName
        //public static DataTable GetCityByCityName(ListCityAndCountry oListCityAndCountry)
        //{
        //    try
        //    {
        //        SqlParameter[] AllParameter = {
        //                new SqlParameter ("@column", "CityCode as CityId,CityName +', ' + DestinationName+'-'+ CountryName as CityName,CountryCode,CountryName"),
        //                new SqlParameter ("@TableName", "Mst_GiataCityMaster"),
        //                new SqlParameter ("@wherecondition", "supplierid=52 AND cityName Like  '"+oListCityAndCountry.CityName+"%'")
        //        };
        //        return DataContext.ExcecuteSP("GetTableWhere", AllParameter);
        //    }

        //    catch (SqlException ex)
        //    {
        //        Logger.Error(ex, "SQLError!");
        //        return null;
        //    }

        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Error!");
        //        return null;
        //    }
        //}
        //#endregion
        //#region GetCityByCityName
        //public static DataTable GetCityForSearch(ListCityAndCountry oListCityAndCountry)
        //{
        //    try
        //    {
        //        SqlParameter[] AllParameter = {
        //                new SqlParameter ("@column", "SupplierId,GiataCityId,CityCode,CityName,CountryCode,CountryName"),
        //                new SqlParameter ("@TableName", "Mst_GiataCityMaster"),
        //                new SqlParameter ("@wherecondition", " SupplierId=52 and  GiataCityId='"+oListCityAndCountry.CityId+"'")
        //        };
        //        return DataContext.ExcecuteSP("GetTableWhere", AllParameter);
        //    }

        //    catch (SqlException ex)
        //    {
        //        Logger.Error(ex, "SQLError!");
        //        return null;
        //    }

        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Error!");
        //        return null;
        //    }
        //}
        //#endregion


        //#region GetCurrency
        //public static DataTable GetCurrency()
        //{
        //    try
        //    {
        //        SqlParameter[] AllParameter = {
        //                new SqlParameter ("@column", " CurrencyCode,CurrencyName+ ' - '+ CurrencyCode as CurrencyName"),
        //                new SqlParameter ("@TableName", "Mst_Currency "),
        //                new SqlParameter ("@wherecondition", "IsActive=1 and AllowBook=1")
        //        };
        //        return DataContext.ExcecuteSP("GetTableWhere", AllParameter);
        //    }

        //    catch (SqlException ex)
        //    {
        //        Logger.Error(ex, "SQLError!");
        //        return null;
        //    }

        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Error!");
        //        return null;
        //    }
        //}
        #endregion

    }
}