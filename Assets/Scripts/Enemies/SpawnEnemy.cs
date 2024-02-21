using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject opponentPrefab;  
    [SerializeField] private GameObject tankOponent;  
    [SerializeField] private PlantsManager plantsManager;
    [SerializeField] private GameObject spawnArea; 
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

        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Spawn opponent when X is pressed
            SpawnOpponent(this.tankOponent);
        }
    }   

    void SpawnOpponent(GameObject enemyPrefab)
    {
        Transform spawnerTransform = spawnArea.GetComponent<Transform>();
        Vector3 scale = spawnerTransform.localScale;
        Vector3 position = spawnerTransform.position;
        
        Vector3 randomSpawnPosition = new Vector3(
            Random.Range(position.x - scale.x / 2, position.x + scale.x / 2), 
            transform.position.y, 
            Random.Range(position.z - scale.z / 2, position.z + scale.z / 2));

        GameObject newEnemy = Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
        newEnemy.GetComponent<TankOponent>().SetTarget(plantsManager.SelectRandomAlivePlant());
    }
}