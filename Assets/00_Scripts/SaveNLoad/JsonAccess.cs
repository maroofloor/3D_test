using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonAccess : MonoBehaviour
{
    string filepath;

    void Start()
    {
        Load();
    }

    void Load()
    {
        filepath = Path.Combine(Application.dataPath, "jsontest4.json");
        FileStream fileStream = new FileStream(filepath, FileMode.Open);
        StreamReader streamReader = new StreamReader(fileStream);

        string jsondata = streamReader.ReadToEnd();

        JsonTestClass test = JsonConvert.DeserializeObject<JsonTestClass>(jsondata);
        test.ShowInfo();
    }
    void Save()
    {
        filepath = Path.Combine(Application.dataPath, "jsontest4.json");
        JsonTestClass test = new JsonTestClass();
        string jsondata = JsonConvert.SerializeObject(test, Formatting.Indented);


        //File.WriteAllText(filepath, jsondata);
        FileStream fileStream = new FileStream(filepath, FileMode.Create);
        StreamWriter streamWriter = new StreamWriter(fileStream);

        streamWriter.WriteLine(jsondata);

        streamWriter.Flush();
        streamWriter.Close();

        fileStream.Close();
    }
}

public class JsonTestClass
{
    public int i;
    public float f;
    public double d;
    public bool b;
    public string s;
    public int[] arr;
    public List<float> list = new List<float>();
    public Dictionary<string, bool> dic = new Dictionary<string, bool>();

    public JsonTestClass()
    {
        i = Random.Range(1, 10);
        f = Random.Range(10f, 15f);
        d = Random.Range(15f, 20f);
        b = i % 2 == 0;
        s = ((char)Random.Range((int)'a', (int)'z')).ToString();
        arr = new int[i];
        for (int j = 0; j < i; j++)
        {
            arr[j] = j;
            list.Add(j * 0.1f);
        }
        dic.Add("µñ¼Å³Ê¸®", true);
        dic.Add("´õÇÔ", true);
    }

    public void ShowInfo()
    {
        Debug.Log("i : " + i);
        Debug.Log("f : " + f);
        Debug.Log("d : " + d);
        Debug.Log("b : " + b);
        Debug.Log("s : " + s);
        
        for (int j = 0; j < arr.Length; j++)
        {
            Debug.Log($"arr[{j}] : " + arr[j]);
        }
        for (int j = 0; j < list.Count; j++)
        {
            Debug.Log($"list[{j}] : " + list[j]);
        }
        foreach (var item in dic)
        {
            Debug.Log($"dic[{item.Key}] : " + item.Value);
        }
    }
}
