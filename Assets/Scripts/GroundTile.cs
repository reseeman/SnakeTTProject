using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> spikesSpawnPoints = new List<GameObject>();
    public List<GameObject> painterPoints = new List<GameObject>();
    public List<GameObject> foodList = new List<GameObject>();
    public List<GameObject> painterList = new List<GameObject>();

    public GameObject obstaclePrefab;
    public GameObject gemPrefab;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnGems();
        SpawnFood();
        SpawnPainter();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    //---Начало Препятствия---
    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(0, spikesSpawnPoints.Count);   //Выбираем точку по рандому
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        //Спавним на выбранной точке
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    //---Конец Препятствия---

    //---Начало Гемы---
    /*void SpawnGems()
    {
        int gemsToSpawn = 1;
        for (int i = 0; i < gemsToSpawn; i++)
        {
            GameObject temp = Instantiate(gemPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
        }
    */
    void SpawnGems()
    {
        int gemSpawnIndex = Random.Range(0, spawnPoints.Count);     //Выбираем точку по рандому
        Transform spawnPoint = transform.GetChild(gemSpawnIndex);

        //Спавним на выбранной точке
        if(Random.Range(0, 100) < 20) //Шанс спавна на тайле
        {
            Instantiate(gemPrefab, spawnPoint.position, Quaternion.identity, transform);
        }
    }
    //---Конец Гемы---

    //---Начало Еды---
    void SpawnFood()
    {
        //Выбираем точку по рандому
        int foodSpawnIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = transform.GetChild(foodSpawnIndex);

        //Спавним на выбранной точке
        if (Random.Range(0, 100) < 40) //Шанс спавна на тайле
        {
            int foodListIndex = Random.Range(0, foodList.Count);
            Instantiate(foodList[foodListIndex], spawnPoint.position, Quaternion.identity, transform);
        }
    }
    //---Конец Еды---

    //---Начало Окрашивателя---
    void SpawnPainter()
    {
        Transform spawnPoint = gameObject.transform.Find("SpawnMddleEnd");  //Выбираем точку

        //Спавним на выбранной точке
        if (Random.Range(0, 100) < 10) //Шанс спавна на тайле
        {
            int painterListIndex = Random.Range(0, painterList.Count);
            Instantiate(painterList[painterListIndex], spawnPoint.position, Quaternion.Euler(new Vector3(0,90,0)), transform);
        }
    }
    //---Конец Окрашивателя---
}
