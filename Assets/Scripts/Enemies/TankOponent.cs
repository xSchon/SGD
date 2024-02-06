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

    void MoveTowardsPlant()
    {
        Vector3 direction = target.transform.position - transform.position;
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (target != null)
        {
            if(distance < 5){
                Debug.Log("Deal"+DPS+"damage");
                damageDone += DPS;
                if (damageDone >= maxDamage){
                    Destroy(gameObject);
                }

                Color currentColor = GetComponent<Renderer>().material.color;

                // Calculate the new color with increased green component
                Color newColor = new Color(currentColor.r, Mathf.Min(currentColor.g - 1, 1.0f), Mathf.Min(currentColor.b - (1 * Time.deltaTime) , 1.0f));
                // Apply the new color to the material
                GetComponent<Renderer>().material.color = newColor;
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
