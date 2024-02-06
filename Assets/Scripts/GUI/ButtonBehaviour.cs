using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject levelSelection;
    // Start is called before the first frame update
    void Start()
    {
        levelSelection.SetActive(false);
    }

    void ClickButton(){
        levelSelection.SetActive(true);
        gameObject.SetActive(false);
    }
}
