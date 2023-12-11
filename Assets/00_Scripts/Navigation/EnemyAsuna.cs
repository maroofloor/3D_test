using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAsuna : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    float distance; // 이 개체와 플레이어의 거리

    [SerializeField]
    Transform player;
    [SerializeField]
    public Transform pos1, pos2;
    [SerializeField]
    Transform rayTr;

    float speed;
    float[] speedSteps = new float[] { 2.5f, 5f };
    bool isWait = true;
    bool isDetected;

    Vector3 dir;

    [Range(0, 360)]
    [SerializeField]
    float ViewAngle = 0;

    [SerializeField]
    float ViewDistance = 0;

    [SerializeField]
    LayerMask obstacleMask;

    [SerializeField]
    LayerMask targetMask;

    List<Collider> targetList = new List<Collider>();

    float goalDis;
    Vector3 goalPos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        isDetected = false;
        speed = 0;
        agent.SetDestination(pos1.position);
        goalPos = pos1.position;
        StartCoroutine(WaitPatrol());
    }

    void Update()
    {
        if (CheckSight())
        {
            isDetected = true;
            agent.isStopped = false;
        }

        goalDis = (goalPos - transform.position).sqrMagnitude;

        if (isDetected == false)
        {
            if ((goalDis <= 1) && isWait == false)
                StartCoroutine(WaitPatrol());
        }
        else
        {
            distance = (player.position - transform.position).sqrMagnitude;
            if (distance > 10f)
            {
                speed = 2.5f;
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
            }
            else
            {
                speed = 0f;
                agent.isStopped = true;
            }
            agent.speed = speed;
            anim.SetFloat("Speed", speed);
            //anim.SetFloat("PosX", agent.velocity.x);
            //anim.SetFloat("PosZ", agent.velocity.z);
        }

        #region 플레이어 추적
        //distance = Vector3.Distance(player.position, transform.position);
        //if (distance > 10f)
        //{
        //    if (agent.isStopped == true)
        //        agent.isStopped = false;
        //    agent.SetDestination(player.position);
        //    speed = 5f;
        //}
        //else if (distance > 5f)
        //{
        //    if (agent.isStopped == true)
        //        agent.isStopped = false;
        //    agent.SetDestination(player.position);
        //    speed = 2.5f;
        //}
        //else
        //{
        //    agent.isStopped = true;
        //    speed = 0f;
        //}
        //agent.speed = speed;
        //anim.SetFloat("Speed", speed);
        //anim.SetFloat("PosX", agent.velocity.x);
        //anim.SetFloat("PosZ", agent.velocity.z);
        #endregion
    }

    public bool CheckSight()
    {
        targetList.Clear();
        Collider[] cols = Physics.OverlapSphere(transform.position, ViewDistance, targetMask);
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                Vector3 targetDir = (cols[i].transform.position - transform.position).normalized;
                float targetAngle = Mathf.Acos(Vector3.Dot(transform.forward, targetDir)) * Mathf.Rad2Deg;
                if (targetAngle <= ViewAngle * 0.5f && Physics.Raycast(transform.position, targetDir, ViewDistance, obstacleMask) == false)
                    targetList.Add(cols[i]);
            }
            if (targetList.Count > 0)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    IEnumerator WaitPatrol()
    {
        isWait = true;
        agent.isStopped = true;
        anim.SetFloat("Speed", 0);

        yield return new WaitForSeconds(Random.Range(2, 3));

        agent.speed = speedSteps[Random.Range(0, speedSteps.Length)];
        if (goalPos == pos1.position)
        {
            agent.SetDestination(pos2.position);
            goalPos = pos2.position;
        }
        else
        {
            agent.SetDestination(pos1.position);
            goalPos = pos1.position;
        }
        anim.SetFloat("Speed", agent.speed);
        agent.isStopped = false;

        yield return new WaitForSeconds(3f);
        isWait = false;
    }
}
