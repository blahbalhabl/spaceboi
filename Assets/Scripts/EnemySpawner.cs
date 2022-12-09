using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{   
    public GameObject fallingBlockPrefab;
    public Vector2 spawnSizeMinMax;
    public Vector2 spawnIntervalsMinMax;
    public float spawnAngleMax;
    float nextSpawnTime;

    Vector2 screenHalfSize;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime) {
            float spawnInterval = Mathf.Lerp(spawnIntervalsMinMax.y, spawnIntervalsMinMax.x, Difficulty.GetDifficulty());
            nextSpawnTime = Time.time + spawnInterval;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x),screenHalfSize.y + spawnSize);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
                
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
