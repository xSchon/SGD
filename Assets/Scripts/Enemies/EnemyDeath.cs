using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    [SerializeField] SpawnEnemy enemySpawner;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void Die(){
        enemySpawner.EnemyDied();
        Destroy(gameObject);
    }
}
