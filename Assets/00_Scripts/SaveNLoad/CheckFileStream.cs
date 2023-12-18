using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CheckFileStream : MonoBehaviour
{
    void Start()
    {
        //�Ϲ� ����
        //FileStream fs = new FileStream("testlog.log",FileMode.Create );
        //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        //sw.WriteLine(99);
        //sw.WriteLine(10.123);
        //sw.WriteLine("����~~~");
        //double a = 1.23456;
        //sw.WriteLine(a);

        //sw.Flush();
        //sw.Close();
        //fs.Close();


        //���̳ʸ�
        //FileStream fs = new FileStream("testlog.dat", FileMode.Create);
        //BinaryWriter sw = new BinaryWriter(fs);
        //sw.Write(99);
        //sw.Write("\n");
        //sw.Write(10.123);
        //sw.Write("\n");
        //sw.Write("����~~~");
        //sw.Write("\n");
        //double a = 1.23456;
        //sw.Write(a);

        //sw.Flush();
        //sw.Close();
        //fs.Close();

        //StartCoroutine(CorTest());

        //����Ƽ�� ���
        //PathCheck();
        //PathFuncCheck();
        CheckFileName();
    }

    IEnumerator CorTest()
    {
        FileStream fs = new FileStream("C:testdat.dat", FileMode.Append/*, FileAccess.Write, FileShare.None*/);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

        int i = 1;
        while (i < 10)
        {
            Debug.Log(i);
            sw.WriteLine(i * 2);
            yield return new WaitForSeconds(0.2f);
            i++;
        }
        Debug.Log("while��");

        sw.Flush();
        sw.Close();
        fs.Close();
    }

    void PathCheck()
    {
        FileStream fs = new FileStream("C:\\Users\\user\\Desktop\\�� ����\\testdat.dat", FileMode.Append/*, FileAccess.Write, FileShare.None*/);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

        Debug.Log("" + Application.dataPath);
        sw.WriteLine("datapath :" + Application.dataPath);
        sw.WriteLine("persistentDataPath :" + Application.persistentDataPath);
        sw.WriteLine("streamingAssetsPath :" + Application.streamingAssetsPath);

        sw.Flush();
        sw.Close();
        fs.Close();
    }

    void PathFuncCheck()
    {
        //if (File.Exists("testlog2.dat"))
        //{
        //    Debug.Log("testlog2.dat ��������");
        //    File.Delete("testlog2.dat");
        //    Debug.Log("testlog2.dat ����");
        //}

        //���� == File.WriteAllText
        //StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.Append("���� ����");
        //stringBuilder.Append("\n�߰�").Append("\n�� �߰�");
        //File.WriteAllText(Path.Combine( Application.dataPath, "FileWriteAllText.txt"), stringBuilder.ToString());

        //�б� == File.ReadAllText �ش� ������ ��� ����
        //Debug.Log("ReadAllText : " + File.ReadAllText(Path.Combine(Application.dataPath, "FileWriteAllText.txt")));
        ////�б� == File.ReadAllLines �ش� ������ ��� ������ ���پ� string�迭��
        //string[] lines = File.ReadAllLines(Path.Combine(Application.dataPath, "FileWriteAllText.txt"));
        //for (int i = 0; i < lines.Length; i++)
        //{
        //    Debug.Log($"ReadAllLines {i+1}��° �� : " + lines[i]);
        //}

        string path = Path.Combine(Application.dataPath, "00_Scripts");
        string[] directories = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path, "*.cs");

        Debug.Log(path + "�� ��� ����");
        for (int i = 0; i < directories.Length; i++)
        {
            Debug.Log($"00_Scripts �� {i+1}��° ���� : " + directories[i]);
        }
        Debug.Log(path + "�� ��� ����");
        for (int i = 0; i < files.Length; i++)
        {
            Debug.Log($"00_Scripts �� {i + 1}��° ���� : " + files[i]);
        }
    }
    void CheckFileName()
    {
        string filename = "abc@a##f!gb%$#$/dir";
        int num = filename.IndexOfAny(Path.GetInvalidPathChars());
        if (num != -1)
        {
            Debug.Log(num + "�� ��ġ�� ��� �̸����� ����ġ ���� ���ڰ� ����");
        }
    }
}
