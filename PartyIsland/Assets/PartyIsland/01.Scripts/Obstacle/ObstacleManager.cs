using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    public GameObject log;
    public List<GameObject> tablewares;

    public Transform logSpawnPosition;
    public Transform tablewaresSpawnPosition;

    public GameObject logParent;
    public GameObject tablewaresParent;

    public GameObject tmpTablewares;

    private void Start()
    {
        StartCoroutine(OnSpawnLog());
        StartCoroutine(OnSpawnTableware());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            MouseRightButton();
        }
    }

    // 일정 시간 후 Log 장애물을 생성하고 이동 및 삭제
    IEnumerator OnSpawnLog() 
    {
        float randomTime = Random.Range(0f,5f);
        yield return new WaitForSeconds(randomTime);

        Instantiate(log, logSpawnPosition);
        
        StartCoroutine(MoveAndDestroyObstacle(logParent.transform.GetChild(0)));
    }
    
    // 일정 시간 후 식기 오브젝트들을 생성하고 이동 및 삭제
    IEnumerator OnSpawnTableware()
    {
        float randomTime = Random.Range(5f,10f);
        yield return new WaitForSeconds(randomTime);

        int randomTablewaresIndex = Random.Range(0,tablewares.Count);
        Instantiate(tablewares[randomTablewaresIndex], tablewaresSpawnPosition);

        StartCoroutine(MoveAndDestroyObstacle(tablewaresParent.transform.GetChild(0)));
    }
    
    // 장애물을 일정 거리 이동 후 삭제
    IEnumerator MoveAndDestroyObstacle(Transform obstacle)
    {
        float targetDistance = 30f;
        float moveSpeed = 5f;
        float movedDistance = 0f;
    
        while (movedDistance < targetDistance)
        {
            float step = moveSpeed * Time.deltaTime;
            obstacle.position += new Vector3(step, 0, 0);
            movedDistance += step;
            
            yield return null;
        }
    
        Destroy(obstacle.gameObject);
    }

    public void MouseRightButton()
    {
        tmpTablewares.SetActive(true);
    }
    
}
