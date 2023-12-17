using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject opponentPrefab;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Check if the X key is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Spawn opponent when X is pressed
            SpawnOpponent(this.opponentPrefab);
        }
    }   

    void SpawnOpponent(GameObject enemyPrefab)
    {
        // Instantiate opponentPrefab at the spawner's position
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}