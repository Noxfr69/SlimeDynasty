using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TD_Agent : MonoBehaviour
{
    NavMeshAgent agent;
    private Vector3 mDir;
    public Vector3 target = new Vector3(0,0,0);
    public Vector3 CurTarget = new Vector3(0,0,0);
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
        mDir = target - Vector3.MoveTowards(transform.position, target, agent.speed*Time.deltaTime);
        CurTarget = agent.steeringTarget - Vector3.MoveTowards(transform.position, target, agent.speed*Time.deltaTime);
        agent.SetDestination(target);
        
    }
}
