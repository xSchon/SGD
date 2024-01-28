using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeOponent : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    [SerializeField] private float damage = 1;
    [SerializeField] private float secondsStunDuration = 1;
    private float damageDone = 0;

    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
