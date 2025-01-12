using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI tmpTimeM;
    public TextMeshProUGUI tmpTimeS;
    
    public Transform uiPanelGameclear;
    public GameObject uiPrefabGameclear;
    private bool isCleared = false;
    
    public float stageTime = 10f;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        StartCoroutine(OnRunTimer());
    }

    IEnumerator OnRunTimer()
    {

        while (stageTime > 0)
        {
            tmpTimeS.text = Mathf.FloorToInt(stageTime % 60).ToString("00");
            yield return new WaitForSeconds(1f);
            stageTime -= 1f;
        }
        
        if (!isCleared)
        {
            OnShowGameClearGUI();
            tmpTimeS.text = "00";
            isCleared = false;
        }
    }

    private void OnShowGameClearGUI()
    {
        Instantiate(uiPrefabGameclear, uiPanelGameclear);
    }

}
