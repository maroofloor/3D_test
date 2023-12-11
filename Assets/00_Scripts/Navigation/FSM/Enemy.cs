using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //public AllEnum.StateEnum ExState;
    public AllEnum.StateEnum NowState = AllEnum.StateEnum.End;
    AnimationComponent anim;
    NavMeshAgent agent;

    [SerializeField]
    LayerMask targetMask;

    public Collider target;

    public StateMachine statemachine { get; private set; }

    void Start()
    {
        anim = GetComponent<AnimationComponent>();
        agent = GetComponent<NavMeshAgent>();
        statemachine = GetComponent<StateMachine>();

        statemachine.SetInIt();
    }

    //public void SetState()
    //{

    //}

    public void Idle()
    {
        anim.Idle();
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }
    public void Move(Vector3 vec)
    {
        agent.isStopped = false;
        agent.SetDestination(vec);
        anim.Walk(agent.velocity.x, agent.velocity.z);
    }
    public void SetMoveAnim()
    {
        anim.Walk(agent.velocity.x, agent.velocity.z);
    }

    public bool CheckSight()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 5f, targetMask);
        if (cols.Length > 0)
        {
            Vector3 targetDir = (cols[0].transform.position - transform.position).normalized;
            float targetAngle = Mathf.Acos(Vector3.Dot(transform.forward, targetDir)) * Mathf.Rad2Deg;
            if (targetAngle <= 60f)
            {
                target = cols[0];
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }
}
