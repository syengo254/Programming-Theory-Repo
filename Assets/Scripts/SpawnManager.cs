using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePrefabs = new List<GameObject>();
    float spawnInterval = 4.0f;

    float startZpos = 10.0f;
    
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", 0.5f, spawnInterval);
    }

    void SpawnRandomObstacle()
    {
        if(GameManager.Instance != null && GameManager.Instance.GameOver) return;

        int randomIndex = Random.Range(0, obstaclePrefabs.Count);
        GameObject prefab = obstaclePrefabs[randomIndex];

        Instantiate(prefab, new Vector3(prefab.transform.position.x, prefab.transform.position.y, startZpos), prefab.transform.rotation);
    }
    
    void Update()
    {
        
    }

    private void OnDestroy() {
        CancelInvoke();
    }
}
