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

        InsertData("Ȱ");
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
            Debug.Log("=========��ü �˻�=========");
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "Select * from ItemInfo";

            reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log("Index : " + reader.GetInt32(0));
                Debug.Log("�̸� : " + reader.GetString(1));
                Debug.Log("���� : " + reader.GetInt32(2));
                Debug.Log("�ִ밳�� : " + reader.GetInt32(3));
                Debug.Log("������ Ÿ�� : " + (AllEnum.ItemTypeForDB)reader.GetInt32(4));
            }
        }
        else
        {
            Debug.Log("=========�Ϻ� �˻�=========");
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "Select * from ItemInfo where ItemType = " + (int)itemType;

            reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log("Index : " + reader.GetInt32(0));
                Debug.Log("�̸� : " + reader.GetString(1));
                Debug.Log("���� : " + reader.GetInt32(2));
                Debug.Log("�ִ밳�� : " + reader.GetInt32(3));
                Debug.Log("������ Ÿ�� : " + (AllEnum.ItemTypeForDB)reader.GetInt32(4));
            }
        }
    }

    void InsertData(string name)
    {
        Debug.Log("=========������ �߰�=========");
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "insert ItemInfo (Name, Price, MaxCount, ItemType) values (\"Ȱ\", 1500, 1, 2)";

        dbCommand.ExecuteReader();
    }
}
