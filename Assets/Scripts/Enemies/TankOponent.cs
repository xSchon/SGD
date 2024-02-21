using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankOponent : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    [SerializeField] private float maxDamage = 100;
    [SerializeField] private float DPS = 1;
    public NavMeshAgent agent;
    private float damageDone = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveTowardsPlant();
        agent.SetDestination(target.transform.position);
    }
    
    public void SetTarget(GameObject Plant){
        this.target = Plant.GetComponent<Transform>();
    }
    
}
