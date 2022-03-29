using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DataLibrary.DB
{
    public interface IConnectionStringData
    {
        string ActiveConnection { get; set; }
        string TestConnection { get; set; }
        string AuthConnection { get; set; }
        string EncryptedConnection();
    }
    public class ConnectionStringData
    {
        public static string ActiveConnection { get; set; } = "SQLDB";
        public static string TestConnection { get; set; }
        public static string AuthConnection { get; set; }

    }
 }

