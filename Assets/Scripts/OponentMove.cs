using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentMove : MonoBehaviour
{
    [SerializeField] private GameObject playerUnit;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed = 5f;

    void Start()
    {
        // Initialization code can go here
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (playerUnit != null)
        {
            // Calculate the direction from the opponent to the player
            Vector3 direction = target.transform.position - transform.position;

            float distance = Vector3.Distance(target.transform.position, transform.position);

            if(distance < 1.5){
                Debug.Log("Explode");
                Destroy(playerUnit);
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
