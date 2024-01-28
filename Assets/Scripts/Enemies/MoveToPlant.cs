using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentMove : MonoBehaviour
{
    [SerializeField] private GameObject playerUnit;
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction from the opponent to the player
        Vector3 direction = target.transform.position - transform.position;
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (playerUnit != null)
        {
            if(distance < 5){
                Debug.Log("Explode");
                Debug.Log("Deal 5 damage");
                return;
                //Destroy(playerUnit);
            }


            Debug.Log(distance);
            // Normalize the direction vector to ensure consistent movement speed
            direction.Normalize();

            // Move the opponent in the calculated direction
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Player unit not assigned. Please assign the player unit in the Inspector.");
        }
    }
}
