using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject opponentPrefab;  
    [SerializeField] private GameObject tankOponent;  
    [SerializeField] private PlantsManager plantsManager;
    [SerializeField] private GameObject spawnArea; 
    
    private int aliveEnemies = 0;
    void Update()
    {
        // Check if the X key is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Spawn opponent when X is pressed
            SpawnInstance(this.opponentPrefab);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Spawn opponent when X is pressed
            SpawnInstance(this.tankOponent);
        }
    }   

    public void EnemySpawn(string enemyType){
        if(enemyType == "Tank"){
            SpawnInstance(this.tankOponent);
        }
        if(enemyType == "Small"){
            Debug.Log("There will be small enemy spawned");
        }
        if(enemyType == "Kamikaze"){
            Debug.Log("There will be kamikadze enemy spawned");
        }

    }

    void SpawnInstance(GameObject enemyPrefab)
    {
        this.aliveEnemies += 1;

        Transform spawnerTransform = spawnArea.GetComponent<Transform>();
        Vector3 scale = spawnerTransform.localScale;
        Vector3 position = spawnerTransform.position;
        
        Vector3 randomSpawnPosition = new Vector3(
            Random.Range(position.x - scale.x / 2, position.x + scale.x / 2), 
            transform.position.y, 
            Random.Range(position.z - scale.z / 2, position.z + scale.z / 2));

        GameObject newEnemy = Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
        newEnemy.GetComponent<GroundMovement>().SetTarget(plantsManager.SelectRandomAlivePlant());
    }

    public void EnemyDied(){
        this.aliveEnemies -= 1;
    }

    public int EnemiesAlive(){
        return this.aliveEnemies;
    }

}