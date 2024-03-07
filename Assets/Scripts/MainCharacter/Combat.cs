using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    bool inAttack = false;
    float attackTime = 0.0f;
    [SerializeField] private AnimationsManager animationsManager;
    [SerializeField] private LayerMask enemyLayer;
    public float attackRange = 1f;
    float attackAngle = 180f; 

    void Update(){
        if(!inAttack){
            if (Input.GetKeyDown(KeyCode.Space)){
                Attack();
                inAttack = true;
            }   
        } else {
            if(attackTime < 0.8f){
                attackTime += Time.deltaTime;
            } else {
                inAttack = false;
                attackTime = 0.0f;
                animationsManager.stopActivity();
                DealDamage();
            }
        }
    }

    void Attack(){
        animationsManager.EnemyHit();
    }


    void DealDamage()
    {
        Vector3 attackDirection = transform.forward;

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, attackRange, attackDirection, 0f, enemyLayer);

        foreach (RaycastHit hit in hits)
        {
            // Check if the hit point is within the specified angle
            Vector3 directionToEnemy = (hit.collider.transform.position - transform.position).normalized;
            float angleToEnemy = Vector3.Angle(attackDirection, directionToEnemy);

            if (angleToEnemy <= attackAngle / 2f)
            {
                hit.collider.GetComponent<OponentBody>().GetHit(50);
            }
        }
    }
    public bool Attacking(){
        return this.inAttack;
    }
}
