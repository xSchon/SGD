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
    public List<PlantInfo> plants;
    
    private int currentLevel = 1;
    void Start()
    {
      //  GameObject prefab1 = Instantiate(PlantPrefab);
      //  PlantInstance pp = prefab1.GetComponent<PlantInstance>();
        LoadPlants();
    }

    void Update()
    {
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
                }
            }
            catch (FormatException){
                Debug.Log("There are some issues in plants csv file!");
            }
            //string[] dataInfo = row.text.Split()
        } 

        /*Debug.Log(data);
        Debug.Log(textAssetData);
        Debug.Log(data.Length);
        */
        /*int columnsAmount = 6;
        int tableSize = data.Length / columnsAmount - 1;

        for(int i = 0; i < tableSize; i++){
   
        }
        */
    }
}




