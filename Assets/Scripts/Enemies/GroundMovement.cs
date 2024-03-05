using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent agent;
    private Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);        
    }
    
    public void SetTarget(GameObject newTarget){
        this.target = newTarget.GetComponent<Transform>();
    }
    
}
