using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    NavMeshAgent agent;
    private Vector3 mDir;
    public Vector3 target;
    public Vector3 CurTarget;
    // Start is called before the first frame update

    private void Awake() {

    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerSlime.PlayPos;
        mDir = target - Vector3.MoveTowards(transform.position, target, agent.speed*Time.deltaTime);
        CurTarget = agent.steeringTarget - Vector3.MoveTowards(transform.position, target, agent.speed*Time.deltaTime);
        agent.SetDestination(target);
        
    }
}
