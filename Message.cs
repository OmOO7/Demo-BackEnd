using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDemo
{
    public static class Message
    {
        public static string APIKEY { get { return "nkQlgaUe4mQ="; } }
        public static string Errormessage { get { return ""; } }
        public static string InvalidParameters { get { return "Invalid Parameter"; } }
        public static string InvalidUserNameOrPassword { get { return "Invalid UserName or Password"; } }

        public static string DataFound { get { return "Data Found"; } }
        public static string DataNotFound { get { return "Data Not Found"; } }

        public static string AlreadyDataExits { get { return "Already Data Exits"; } }
        public static string RegistatrationSuccess { get { return "Registration Successfully"; } }
    }
    public static class Code
    {
        public static string Ok { get { return "OK"; } }
        public static string Fail { get { return "FAIL"; } }
    }
}