using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;

public class DBAccess : MonoBehaviour
{
    string filepath = "";
    IDbConnection dbConnection = null;
    IDbCommand dbCommand = null;
    IDataReader reader = null;

    void Start()
    {
        filepath = Application.dataPath + Path.DirectorySeparatorChar + "GameData.db";
        if (File.Exists(filepath) == false)
        {
            File.Copy(Application.streamingAssetsPath + Path.DirectorySeparatorChar + "GameData.db", filepath);
        }

        string file = "URI=file:" + Application.dataPath + Path.DirectorySeparatorChar + "GameData.db";

        dbConnection = new SqliteConnection(file);
        dbConnection.Open();

        InsertData("활");
        PrintData(true);

        reader.Dispose();
        reader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }

    void PrintData(bool all, AllEnum.ItemTypeForDB itemType = AllEnum.ItemTypeForDB.Sword)
    {
        if (all)
        {
            Debug.Log("=========전체 검색=========");
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "Select * from ItemInfo";

            reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log("Index : " + reader.GetInt32(0));
                Debug.Log("이름 : " + reader.GetString(1));
                Debug.Log("가격 : " + reader.GetInt32(2));
                Debug.Log("최대개수 : " + reader.GetInt32(3));
                Debug.Log("아이템 타입 : " + (AllEnum.ItemTypeForDB)reader.GetInt32(4));
            }
        }
        else
        {
            Debug.Log("=========일부 검색=========");
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "Select * from ItemInfo where ItemType = " + (int)itemType;

            reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log("Index : " + reader.GetInt32(0));
                Debug.Log("이름 : " + reader.GetString(1));
                Debug.Log("가격 : " + reader.GetInt32(2));
                Debug.Log("최대개수 : " + reader.GetInt32(3));
                Debug.Log("아이템 타입 : " + (AllEnum.ItemTypeForDB)reader.GetInt32(4));
            }
        }
    }

    void InsertData(string name)
    {
        Debug.Log("=========아이템 추가=========");
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "insert ItemInfo (Name, Price, MaxCount, ItemType) values (\"활\", 1500, 1, 2)";

        dbCommand.ExecuteReader();
    }
}
