using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class XMLAccess : MonoBehaviour
{
    string filepath = "";
    void Start()
    {
        filepath = Path.Combine(Application.dataPath, "xmltest.xml");

        //Save();
        Load();
    }

    void Save()
    {
        XMLTestClass test = new XMLTestClass();
        test.ShowInfo();
        XmlSerializer xml = new XmlSerializer(typeof(XMLTestClass));

        FileStream fileStream = new FileStream(filepath, FileMode.Create);
        xml.Serialize(fileStream, test);
        fileStream.Close();
    }
    void Load()
    {
        XmlSerializer xml = new XmlSerializer(typeof(XMLTestClass));
        FileStream fileStream = new FileStream(filepath, FileMode.Open);

        XMLTestClass test = xml.Deserialize(fileStream) as XMLTestClass;
        fileStream.Close();

        test.ShowInfo();
    }
}

public class XMLTestClass
{
    public int i;
    public float f;
    public double d;
    public bool b;
    public string s;
    public int[] arr;
    public List<float> list = new List<float>();
    //public Dictionary<string, bool> dic = new Dictionary<string, bool>();

    public XMLTestClass()
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
        //dic.Add("µñ¼Å³Ê¸®", true);
        //dic.Add("´õÇÔ", true);
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
        //foreach (var item in dic)
        //{
        //    Debug.Log($"dic[{item.Key}] : " + item.Value);
        //}
    }
}
