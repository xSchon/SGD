using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallOponent : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    [SerializeField] private float maxDamage = 50;
    [SerializeField] private float DPS = 1;
    private float damageDone = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        GoTowardsPlant();
    }
    public void SetTarget(GameObject Plant){
        this.target = Plant.GetComponent<Transform>();
    }
    void GoTowardsPlant()
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
                Color newColor = new Color(currentColor.r, Mathf.Min(currentColor.g - 1, 1.0f), Mathf.Max(currentColor.b + (1 * Time.deltaTime) , 255.0f));
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
