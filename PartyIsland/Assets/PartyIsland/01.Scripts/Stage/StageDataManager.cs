using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class StageData
{
    public int stageID;
    public string stageName;
    public int x;
    public int y;
}

[System.Serializable]
public class StageDatas
{
    public StageData[] PartyIsland_Stage;
}

public class StageDataManager : MonoBehaviour
{
    public TextAsset originData;
    private StageDatas StageDatas;

    public List<Material> randomMaterials = new List<Material>();
    public List<GameObject> randomBlocks = new List<GameObject>();

    public GameObject block;
    public Transform environment;

    private void Awake()
    {
        Debug.Log(originData.text);
        LoadJson();
    }

    private void LoadJson()
    {
        StageDatas = JsonUtility.FromJson<StageDatas>(originData.text);
    }
    
    private void Start()
    {
        int randomMapIndex = Random.Range(0, StageDatas.PartyIsland_Stage.Length);
        int x = StageDatas.PartyIsland_Stage[randomMapIndex].x;
        int y = StageDatas.PartyIsland_Stage[randomMapIndex].y;

        CreateRandomBlock(x,y);
    }

    private Material ChangeRandomMaterial()
    {
        int randomNumber = Random.Range(0, randomMaterials.Count);
        return randomMaterials[randomNumber];
    }

    private void CreateRandomBlock(int x, int y)
    {
        int innerXRange = (x - 2);
        int innerYRange = (y - 2);
        
        for (int i = -innerXRange; i <= innerXRange; i+=2)
        {
            for (int j = -innerYRange; j <= innerYRange; j+=2)
            {
                // Random Block List 사용 시,
                // int randomNumber = Random.Range(0, randomBlocks.Count);
                // GameObject block = Instantiate(randomBlocks[randomNumber], environment);
                
                Instantiate(block, environment);
                block.transform.position = new Vector3(i, 0, j);
            }
        }
    }
}
