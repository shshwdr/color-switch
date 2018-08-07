using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class SQLiteDatabaseManager : Singleton<SQLiteDatabaseManager> {
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    // Use this for initialization
    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/Plugins/db.s3db"; //Path to database.
        //Deletvalue(6);
        //insertvalue("ahmedm", "ahmedm@gmail.com", "sss"); 
        //Updatevalue("a", "w@gamil.com", "1st", 1);
        readers();
    }

    private void insertvalue(string name, string email, string address)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into Usersinfo (Name, Email, Address) values (\"{0}\",\"{1}\",\"{2}\")", name, email, address);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    private void Deletevalue(int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("Delete from Usersinfo WHERE ID=\"{0}\"", id);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    public void Updatevalue(string id, int amount)
    {
        using (dbconn = new SqliteConnection(conn))
        {

            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE currency set amount=\"{0}\" WHERE identifier=\"{1}\" ", amount, id);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    
    private void readers()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * FROM currency";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                int amount = reader.GetInt32(1);

                CSUtil.LOG("identifier = " + id + "  amount =" + amount);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }

    public int AmountOfCurrency(string currencyId)
    {
        int amount = 0;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * FROM currency where identifier = 'gold'";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            
            while (reader.Read())
            {
                string id = reader.GetString(0);
                amount = reader.GetInt32(1);
                break;
                CSUtil.LOG("id = " + id + "  amount =" + amount);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
        return amount;
    }
}
