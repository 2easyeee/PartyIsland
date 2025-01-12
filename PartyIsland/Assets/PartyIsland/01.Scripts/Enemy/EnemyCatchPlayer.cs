using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatchPlayer : MonoBehaviour
{
    private bool isCatched = false;
    
    public Transform uiPanelGameover;
    public GameObject uiPrefabGameover;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Debug | Player | Player Catched");
            
            isCatched = true;

            if (isCatched && !PlayerPrefs.GetString("GameState").Equals("over"))
            {
                PlayerPrefs.SetString("GameState", "over");
                Instantiate(uiPrefabGameover, uiPanelGameover);
            }
            
        }
    }
}
