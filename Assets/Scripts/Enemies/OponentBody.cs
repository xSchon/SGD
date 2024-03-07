using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentBody : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHP = 100;
    [SerializeField] private float currentHP = 100;
    [SerializeField] private float maxDamage = 100;
    [SerializeField] private float DPS = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit(float hitDamage){
        this.currentHP -= hitDamage;
        if (this.currentHP <= 0){
            Die();
            return;
        }
        StartCoroutine(FlashOnHit());
    }

    IEnumerator FlashOnHit()
    {
        // Change material color to flashColor
        GetComponent<Renderer>().material.color = Color.red;
        GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;

        // Wait for the specified duration
        yield return new WaitForSeconds(0.5f);

        // Reset material color to original
        GetComponent<Renderer>().material.color = Color.blue;
        GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
    }

    private void Die(){
        Destroy(gameObject);
    }
}
