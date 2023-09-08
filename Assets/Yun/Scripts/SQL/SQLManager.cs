using MySql.Data.MySqlClient;
using System;
using UnityEngine;

public class SQLManager : SingleTon<SQLManager>
{
    // Application.persistentDataPath
    // ServerAddress.txt ÆÄÀÏ
    private static string serverInfo;
    public MySqlConnection sqlConnection;
    public MySqlDataReader reader;

    private void Start()
    {
        ConnectDataBase();
    }

    private void ConnectDataBase()
    {
        try
        {
            SQLConnect();

            Debug.Log($"SQL State : {sqlConnection.State}");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void SQLConnect()
    {
        sqlConnection = new MySqlConnection(serverInfo);
        sqlConnection.Open();
    }

    public void SQLDisconnect()
    {
        sqlConnection.Close();
        Debug.Log($"SQL State : {sqlConnection.State}");
    }

    public void SQLUpdateOrInsert(string allcmd)
    {
        SQLConnect();

        MySqlCommand dbcmd = new MySqlCommand(allcmd, sqlConnection);
        dbcmd.ExecuteNonQuery();

        Debug.Log($"SQL State : {sqlConnection.State}");

        SQLDisconnect();
    }

    private void OnApplicationQuit()
    {
        SQLDisconnect();
    }
}
