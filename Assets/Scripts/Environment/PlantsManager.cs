using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using static PlantCSV;

public class PlantInfo{
    public GameObject plantInstance;
    public PlantInstance plantScript;
    public PlantInfo(int newMaxHP, Vector3 newPosition, int newRegenStrength, GameObject prefabInstance){
        this.plantInstance = prefabInstance;
        this.plantScript = this.plantInstance.GetComponent<PlantInstance>();        
        this.plantScript.setStats(newMaxHP, newPosition, newRegenStrength);
    }
}

public class PlantsManager : MonoBehaviour
{
    [SerializeField] GameObject PlantPrefab;
    [SerializeField] TextAsset textAssetData;
    public List<PlantInfo> levelPlants = new List<PlantInfo>();
    
    private int currentLevel = 1;
    private System.Random rnd = new System.Random();
    void Start()
    {
        LoadPlants();
    }

    void Update()
    {
        CheckHP();
    }

    void CheckHP(){
        int currHP = 0;
        int maxHP = 0;
        for(int i = 0; i < levelPlants.Count; i++){
            maxHP += levelPlants[i].plantScript.getMaxHP();
            currHP += levelPlants[i].plantScript.getCurrentHP();
        }
    }

    void LoadPlants(){
        string[] dataRows = textAssetData.text.Split(new string[] {"\n"}, StringSplitOptions.None);
        foreach(string row in dataRows.Skip(1).Take(dataRows.Length-2).ToArray()){
            string [] dataInfo = row.Split(new string[] {","}, StringSplitOptions.None);
            try{
                if (int.Parse(dataInfo[0]) == currentLevel){   // this level plants apply
                    int maxHP = int.Parse(dataInfo[1]);
                    int X = int.Parse(dataInfo[2]);
                    int Y = int.Parse(dataInfo[3]);
                    int Z = int.Parse(dataInfo[4]);
                    int regenHP = int.Parse(dataInfo[5]);
                    Vector3 pos = new Vector3(X,Y,Z);

                    GameObject newObject = Instantiate(PlantPrefab, pos, Quaternion.identity);
                    PlantInfo newPlantInfo = new PlantInfo(maxHP, pos, regenHP, newObject);
                    levelPlants.Add(newPlantInfo);
                }
            }
            catch (FormatException){
                Debug.Log("There are some issues in plants csv file!");
            }
        } 
    }

    public GameObject SelectRandomAlivePlant(){
        int randomPlant = rnd.Next(levelPlants.Count);
        int fallback = 0;
        while(!levelPlants[randomPlant].plantScript.isAlive() && fallback < 1000){
            randomPlant = rnd.Next(levelPlants.Count - 1);
            fallback += 1;
        }
        if (fallback == 1000){
            Debug.Log("HAD TO USE FALLBACK");
        }
        return levelPlants[randomPlant].plantInstance;
    }
}




