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
        orderNo = orderNo;
        minOpAtOnce = minOpAtOnce;
        maxOpAtOnce = maxOpAtOnce;
        minSecDelay = minSecDelay;
        maxSecDelay = maxSecDelay;
        amtTanks = amtTanks;
        amtSmalls = amtSmalls;
        amtKamikaze = amtKamikaze;
        secondsWaitAfter = secondsWaitAfter;
    }

}
public class WaveManagement : MonoBehaviour
{
    private int currentLevel;
    [SerializeField] TextAsset wavesCsv;
    [SerializeField] LevelManager levelManager;
    [SerializeField] UIManager uiManager;
    private List<EnemyWave> levelWaves = new List<EnemyWave>();
    void Start()
    {
        currentLevel = levelManager.getLevelNumber();
        InitLoadWaves();
    }
    void Update()
    {   
        Debug.Log(levelWaves.Count);
        uiManager.addTopNotification("LULE", 5);
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
