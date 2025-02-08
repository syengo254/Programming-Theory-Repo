using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePrefabs = new List<GameObject>();

    float spawnInterval = 5.0f;
    float startZpos = 15.0f;
    float nextSpawn = 0;
    int oldDifficulty;

    void Start()
    {
        oldDifficulty = MainManager.Current.Difficulty;
        Invoke("StartSpawning", 0.5f);
    }

    private void Update() {
        if(MainManager.Current.Difficulty != oldDifficulty && !GameManager.Instance.GameOver)
        {
            // difficulty has just changed
            oldDifficulty = MainManager.Current.Difficulty;
            StopCoroutine(UpdateTickAndSpawn());
            StartSpawning();
        }
        else
        {
            StopCoroutine(UpdateTickAndSpawn());
            return;
        }
    }

    void StartSpawning()
    {
        StartCoroutine(UpdateTickAndSpawn());
    }

    void SpawnRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Count);
        GameObject prefab = obstaclePrefabs[randomIndex];

        Instantiate(prefab, new Vector3(prefab.transform.position.x, prefab.transform.position.y, startZpos), prefab.transform.rotation);
        
        if(startZpos < 45)
        {
            startZpos += 15f;
        }
    }

    IEnumerator UpdateTickAndSpawn()
    {
        yield return new WaitForSeconds(nextSpawn);

        SpawnRandomObstacle();
        nextSpawn = spawnInterval / MainManager.Current.Difficulty;
        StartCoroutine(UpdateTickAndSpawn());
    }

    private void OnDestroy() {
        StopAllCoroutines();
    }
}
