using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInstance : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxHP;
    private int currentHP;
    private Vector3 spawnPosition;
    private int regenStrength;

    public void setStats(int newMaxHP, Vector3 newSpawnPosition, int newRegenStrength){
        this.maxHP = newMaxHP;
        this.spawnPosition = newSpawnPosition;
        this.regenStrength = newRegenStrength;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void dealDamage(int hpLost){
        this.currentHP -= hpLost;
    }

    public int getCurrentHP(){
        return this.currentHP;
    }

    public int getMaxHP(){
        return this.maxHP;
    }

    public bool isAlive(){
        return this.currentHP == 0;
    }
}
