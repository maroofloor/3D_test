using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TestThread : MonoBehaviour
{
    void Start()
    {
        DoTest();
        //Run();
    }

    void DoTest()
    {
        int randomsec
            ;
        Thread t1 = new Thread(new ThreadStart(Run));
        t1.IsBackground = true;
        t1.Start();

        randomsec = Random.Range(10, 20) * 100;
        Thread t2 = new Thread(Run2);
        //t2.IsBackground = true;
        t2.Start(randomsec);

        Thread t3 = new Thread(delegate () { Run(); });
        t3.Start();

        Thread t4 = new Thread(() => Run());
        t4.Start();

        new Thread(() => Run()).Start();
    }
    void Run2(object val)
    {
        int randomsec = (int)val;
        Debug.Log($"Thread ID : {Thread.CurrentThread.ManagedThreadId} 시작");
        Debug.Log($"Thread ID : {Thread.CurrentThread.ManagedThreadId}가 기다려야할 시간 {randomsec}");
        Thread.Sleep(randomsec);
        Debug.Log($"Thread ID : {Thread.CurrentThread.ManagedThreadId} 끝..");
    }
    void Run()
    {
        Debug.Log($"Thread ID : {Thread.CurrentThread.ManagedThreadId} 시작");
        Debug.Log($"Thread ID : {Thread.CurrentThread.ManagedThreadId}가 기다려야할 시간 2000");
        Thread.Sleep(2000);
        Debug.Log($"Thread ID : {Thread.CurrentThread.ManagedThreadId} 끝..");
    }
}
