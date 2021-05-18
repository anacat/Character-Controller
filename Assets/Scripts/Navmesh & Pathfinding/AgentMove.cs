using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{
    public Camera mainCamera;

    public Transform currentTarget;

    public float minDistanceToChangeTarget;

    private NavMeshAgent agent;
    private int targetIndex;

    private PathManager pathManager;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        pathManager = GameObject.Find("Path").GetComponent<PathManager>();

        targetIndex = 0;
        currentTarget = pathManager.pathPointList[0];

        agent.SetDestination(currentTarget.position);
    }

    private void Update()
    {
        //FollowMouseClick();
        //FollowTarget();
        FollowPath();
    }

    private void FollowMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void FollowTarget()
    {
        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.position);
        }
    }

    private void FollowPath()
    {
        if(Vector3.Distance(transform.position, currentTarget.position) < minDistanceToChangeTarget)
        {
            if(targetIndex + 1 < pathManager.pathPointList.Count)
            {
                targetIndex++;
                currentTarget = pathManager.pathPointList[targetIndex];

                agent.SetDestination(currentTarget.position);
            }
            else
            {
                Destroy(gameObject);
            }
            //else
            //{
            //    targetIndex = 0;
            //    currentTarget = pathManager.pathPointList[targetIndex];

            //    agent.SetDestination(currentTarget.position);
            //}
        }
    }
}
