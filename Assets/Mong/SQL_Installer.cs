//using MySql.Data.MySqlClient;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class USerInfo
//{ 
//    public string U_Name { get; private set; }
//    public string U_Password { get; private set; }
//    public string U_Birthday { get; private set; }

//    public USerInfo(string name,string password, string birthday)
//    {
//        U_Name = name;
//        U_Password = password;
//        U_Birthday = birthday;
//    }

//}
//public class SQL_Installer : MonoBehaviour
//{
//    #region MYSQL
//    public MySqlConnection con;
//    public MySqlDataReader reader;
//    #endregion

//    private void Awake()
//    {
//        try 
//        {
//            DB_Path = Application.dataPath + "/DataBase";
//            string serverinfo = Server_set(DB_Path);
//            if (serverinfo == string.Empty) 
//            {
//                Debug.Log("SQL_Server Null! not connected");
//                return;
//            }
//        }
//        con = new MySqlConnection(serverinfo);
//        con.Open();
//        Debug.Log("SQL OPEN Compelete");
//    }
//}
