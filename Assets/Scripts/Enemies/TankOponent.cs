using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankOponent : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    [SerializeField] private float maxDamage = 100;
    [SerializeField] private float DPS = 1;
    private float damageDone = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        
    }
    
}
