using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timer = 0f;
    private float lastWave = 0f;

    [SerializeField]
    private float waveDelay;
    [SerializeField]
    private float waveIncreaseTime;
    [SerializeField]
    private float minSpawnDistance;
    [SerializeField]
    private GameObject[] enemies;

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;

        if (timer >= lastWave + waveDelay)
        {
            lastWave = timer;
            SpawnWave();
            //ui here for next wave
        }
    }

    private void SpawnWave()
    {
        int amount = Mathf.RoundToInt(timer / waveIncreaseTime) + 1;
        print(amount);
        var p = FindSpawnLocations(amount);

        for (int i = 0; i < amount; i++)
        {
            var e = Random.Range(0, enemies.Length);
            
            SpawnEnemy(p[i], enemies[e]);
        }
    }

    private void SpawnEnemy(Vector3 position, GameObject enemy)
    {
        Instantiate(enemy, position, Quaternion.identity);
    }

    private Vector3[] FindSpawnLocations(int amount)
    {
        List<Vector3> points = new List<Vector3> { new Vector3(0, 0, minSpawnDistance) };

        var theta = Mathf.PI / 2;
        var dTheta = 2 * (Mathf.PI / amount);

        for (int i = 0; i < amount; i++)
        {
            theta += dTheta;

            var p = new Vector3(minSpawnDistance * Mathf.Cos(theta), 0, minSpawnDistance * Mathf.Sin(theta));

            points.Add(p);
        }

        return points.ToArray();
    }
}
