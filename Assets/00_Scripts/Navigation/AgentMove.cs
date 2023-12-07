using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{
    //public Camera cam;
    //public Transform goal;

    NavMeshAgent agent;

    public Player player;
    int offMesh_Jump = 2;
    float jumpSpeed = 0.5f;
    Coroutine jumpCor = null;

    float dis;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //cam = Camera.main;
        //agent.stoppingDistance = 5f;
    }

    void Update()
    {
        #region
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && goal != null)
        //    {
        //        goal.position = hit.point;
        //        agent.SetDestination(goal.position);
        //    }
        //}
        #endregion

        if (player != null)
        {
            dis = Vector3.Distance(player.transform.position, transform.position);
            if (dis > 5f)
            {
                if (agent.isStopped == true)
                    agent.isStopped = false;
                agent.SetDestination(player.transform.position);
            }
            else
                agent.isStopped = true;

            //if (agent.isOnOffMeshLink)
            //{
            //    OffMeshLinkData linkData = agent.currentOffMeshLinkData;
            //    if (linkData.offMeshLink != null && linkData.offMeshLink.area == offMesh_Jump)
            //    {
            //        if (jumpCor == null)
            //        {

            //        }
            //    }
            //}
        }
    }
    //IEnumerator JumpCor(OffMeshLinkData linkData)
    //{
    //    agent.isStopped = true;
    //    agent.updateRotation = false;

    //    Vector3 start = linkData.startPos;
    //    Vector3 end = linkData.endPos;
    //    Vector3 LookPos = end;

    //    float jumpTime = Mathf.Abs(end.y - start.y) / jumpSpeed;
    //    float currentTime = 0f;
    //    float percent = 0f;

    //    while (percent < 1)
    //    {
    //        currentTime += 
    //    }
    //}
}
