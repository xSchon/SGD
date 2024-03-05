using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private float levelTimer = 0.0f;
    private int levelNumber;
    void Start()
    {
        levelNumber = 1;
        LoadLevelSettings();
    }

    void Update()
    {
        levelTimer += Time.deltaTime;
    }

    public float currentLevelTime(){
        return levelTimer;
    }

    public int getLevelNumber(){
        return this.levelNumber;
    }

    private void LoadLevelSettings(){

    }
}
