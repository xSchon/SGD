using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    [SerializeField] private GameObject idle;
    [SerializeField] private GameObject walk;
    [SerializeField] private GameObject run;
    [SerializeField] private GameObject hitEnemy;
    [SerializeField] private GameObject getHit;
    [SerializeField] private GameObject holdEnemy;
    private GameObject activeObject;

    private void Reset(GameObject activeObject){
        walk.SetActive(false);
        run.SetActive(false);
        hitEnemy.SetActive(false);
        holdEnemy.SetActive(false);
        getHit.SetActive(false);
        idle.SetActive(false);

        activeObject.SetActive(true);
    }
    void Start()
    {
        Reset(idle);
    }

    public void stopActivity(){
        Reset(idle);
    }
    public void startWalk(){
        Reset(walk);
    }
    
    public void startRun(){
        Reset(run);
    }

    public void EnemyHit(){
        Reset(hitEnemy);
    }

}
