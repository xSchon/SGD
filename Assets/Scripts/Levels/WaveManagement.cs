using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class EnemyWave{
    public int orderNo;
    public int minOpAtOnce;
    public int maxOpAtOnce;
    public int minSecDelay;
    public int maxSecDelay;
    public int amtTanks;
    public int amtSmalls;
    public int amtKamikaze;
    public int secondsWaitAfter;

    public EnemyWave(int orderNo, int minOpAtOnce, int maxOpAtOnce, int minSecDelay, int maxSecDelay, int amtTanks, int amtSmalls, int amtKamikaze, int secondsWaitAfter)
    {
        this.orderNo = orderNo;
        this.minOpAtOnce = minOpAtOnce;
        this.maxOpAtOnce = maxOpAtOnce;
        this.minSecDelay = minSecDelay;
        this.maxSecDelay = maxSecDelay;
        this.amtTanks = amtTanks;
        this.amtSmalls = amtSmalls;
        this.amtKamikaze = amtKamikaze;
        this.secondsWaitAfter = secondsWaitAfter;
    }

}
public class WaveManagement : MonoBehaviour
{
    private int currentLevel;
    [SerializeField] TextAsset wavesCsv;
    [SerializeField] LevelManager levelManager;
    [SerializeField] UIManager uiManager;
    [SerializeField] SpawnEnemy enemySpawner;
    private List<EnemyWave> levelWaves = new List<EnemyWave>();

    private bool waveActive = false;
    private float waitStart = 5.0f;
    private float sinceLastSpawn;
    private float spawnAfter;
    private EnemyWave curWav;
    private List<string> enemiesPool = new List<string>();

    void Start()
    {
        currentLevel = levelManager.getLevelNumber();
        InitLoadWaves();
    }
    void Update()
    {   
        if(waveActive){
            WaveSpawner();
        } else {
            if(waitStart > 0 ){
                waitStart -= Time.deltaTime;
            } else {
                waveActive = true;
                InitWave();
            }
        }
    }

    void SpawnWave(){
        int amtEnemies = UnityEngine.Random.Range(curWav.minOpAtOnce, curWav.maxOpAtOnce+1);
        this.sinceLastSpawn = 0.0f;
        Debug.Log("AMT ENEMIES " + amtEnemies);
        
        int startCount = enemiesPool.Count;
        for(int i = 0; i < Math.Min(amtEnemies, startCount); i++){
            int enemyToSpawn = UnityEngine.Random.Range(0, enemiesPool.Count);
            enemySpawner.EnemySpawn(enemiesPool[enemyToSpawn]);
            enemiesPool.RemoveAt(enemyToSpawn);
        }

        if (enemiesPool.Count == 0){
            EndWave();
        }
    }
    void WaveSpawner(){
        this.sinceLastSpawn += Time.deltaTime;
        if(this.sinceLastSpawn > this.spawnAfter){
            SpawnWave();
            this.spawnAfter = UnityEngine.Random.Range((float)curWav.minSecDelay, curWav.maxSecDelay);
        }
    }

    void InitWave(){
        curWav = levelWaves.First();
        this.spawnAfter = UnityEngine.Random.Range((float)curWav.minSecDelay, curWav.maxSecDelay);
        
        uiManager.addTopNotification("WAVE "+curWav.orderNo+" STARTING", 5);
        for(int i = 0; i < curWav.amtTanks; i++) enemiesPool.Add("Tank");
        for(int i = 0; i < curWav.amtSmalls; i++) enemiesPool.Add("Small");
        for(int i = 0; i < curWav.amtKamikaze; i++) enemiesPool.Add("Kamikaze");

        SpawnWave();
    }

    void EndWave(){
        Debug.Log("Whole wave "+curWav.orderNo+" was spawned");
    }

    void InitLoadWaves(){
        string[] dataRows = wavesCsv.text.Split(new string[] {"\n"}, StringSplitOptions.None);
       
        foreach(string row in dataRows.Skip(1).Take(dataRows.Length-2).ToArray()){
            string [] dataInfo = row.Split(new string[] {","}, StringSplitOptions.None);
            try{
                if (int.Parse(dataInfo[0]) == currentLevel){ 
                    EnemyWave parseWave = new EnemyWave(
                        int.Parse(dataInfo[1]),
                        int.Parse(dataInfo[2]),
                        int.Parse(dataInfo[3]),
                        int.Parse(dataInfo[4]),
                        int.Parse(dataInfo[5]),
                        int.Parse(dataInfo[6]),
                        int.Parse(dataInfo[7]),
                        int.Parse(dataInfo[8]),
                        int.Parse(dataInfo[9])
                    );
                    levelWaves.Add(parseWave);
                }
            }
            catch (FormatException){
                Debug.Log("There are some issues in plants csv file!");
            }
        } 
    }
}
