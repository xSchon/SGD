using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagement : MonoBehaviour
{
    private int levelNumber;
    [SerializeField] TextAsset wavesCsv;
    [SerializeField] LevelManager levelManager;
    [SerializeField] UIManager uiManager;
    void Start()
    {
        levelNumber = levelManager.getLevelNumber();
    }
    void Update()
    {   
        uiManager.addTopNotification("WAVE 1 INC", 5);
    }
}
