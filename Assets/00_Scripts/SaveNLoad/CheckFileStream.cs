using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CheckFileStream : MonoBehaviour
{
    void Start()
    {
        //일반 생성
        //FileStream fs = new FileStream("testlog.log",FileMode.Create );
        //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        //sw.WriteLine(99);
        //sw.WriteLine(10.123);
        //sw.WriteLine("내용~~~");
        //double a = 1.23456;
        //sw.WriteLine(a);

        //sw.Flush();
        //sw.Close();
        //fs.Close();


        //바이너리
        //FileStream fs = new FileStream("testlog.dat", FileMode.Create);
        //BinaryWriter sw = new BinaryWriter(fs);
        //sw.Write(99);
        //sw.Write("\n");
        //sw.Write(10.123);
        //sw.Write("\n");
        //sw.Write("내용~~~");
        //sw.Write("\n");
        //double a = 1.23456;
        //sw.Write(a);

        //sw.Flush();
        //sw.Close();
        //fs.Close();

        //StartCoroutine(CorTest());

        //유니티의 경로
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
        Debug.Log("while끝");

        sw.Flush();
        sw.Close();
        fs.Close();
    }

    void PathCheck()
    {
        FileStream fs = new FileStream("C:\\Users\\user\\Desktop\\새 폴더\\testdat.dat", FileMode.Append/*, FileAccess.Write, FileShare.None*/);
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
        //    Debug.Log("testlog2.dat 파일있음");
        //    File.Delete("testlog2.dat");
        //    Debug.Log("testlog2.dat 삭제");
        //}

        //쓰기 == File.WriteAllText
        //StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.Append("내용 쓰기");
        //stringBuilder.Append("\n추가").Append("\n더 추가");
        //File.WriteAllText(Path.Combine( Application.dataPath, "FileWriteAllText.txt"), stringBuilder.ToString());

        //읽기 == File.ReadAllText 해당 파일의 모든 내용
        //Debug.Log("ReadAllText : " + File.ReadAllText(Path.Combine(Application.dataPath, "FileWriteAllText.txt")));
        ////읽기 == File.ReadAllLines 해당 파일의 모든 내용을 한줄씩 string배열로
        //string[] lines = File.ReadAllLines(Path.Combine(Application.dataPath, "FileWriteAllText.txt"));
        //for (int i = 0; i < lines.Length; i++)
        //{
        //    Debug.Log($"ReadAllLines {i+1}번째 줄 : " + lines[i]);
        //}

        string path = Path.Combine(Application.dataPath, "00_Scripts");
        string[] directories = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path, "*.cs");

        Debug.Log(path + "의 모든 폴더");
        for (int i = 0; i < directories.Length; i++)
        {
            Debug.Log($"00_Scripts 의 {i+1}번째 폴더 : " + directories[i]);
        }
        Debug.Log(path + "의 모든 파일");
        for (int i = 0; i < files.Length; i++)
        {
            Debug.Log($"00_Scripts 의 {i + 1}번째 파일 : " + files[i]);
        }
    }
    void CheckFileName()
    {
        string filename = "abc@a##f!gb%$#$/dir";
        int num = filename.IndexOfAny(Path.GetInvalidPathChars());
        if (num != -1)
        {
            Debug.Log(num + "의 위치에 경로 이름으로 적합치 않은 문자가 있음");
        }
    }
}
