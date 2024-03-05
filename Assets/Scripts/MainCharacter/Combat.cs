using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    //[SerializeField] private GameObject animationsManager;
    [SerializeField] private AnimationsManager animationsManager;
    void Start()
    {
        //animationsManager.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }   
    }

    void Attack(){
        //walkMove.SetActive(false);
        //attackMove.SetActive(true);
    }
}
