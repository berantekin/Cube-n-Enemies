using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float perSeconds = 5f;

    public GameObject[] spawnerObjects;
    public Transform[] spawnPositions;
    private float nextSpawnTime = 0f;
    private TimeManager timeManager;

    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }


    void Update()
    {

        if (Time.timeSinceLevelLoad > nextSpawnTime && timeManager.gameOver == false && timeManager.gameFinished == false)
        {
            nextSpawnTime += perSeconds;
            SpawnObj(spawnerObjects[RandomizePrefab()], spawnPositions[RandomizeSpawnNumber()]);
        }


    }

    private void SpawnObj(GameObject objecTospawn, Transform newTransform)
    {
        Instantiate(objecTospawn, newTransform.position, newTransform.rotation);

    }

    private int RandomizeSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);

    }
    private int RandomizePrefab()
    {
        return Random.Range(0, spawnerObjects.Length);

    }

}
