using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    private float timer = 20f;
    private float lastWave = 0f;
    private int wave = 0;

    [SerializeField]
    private float waveDelay;
    [SerializeField]
    private float waveIncreaseTime;
    [SerializeField]
    private float minSpawnDistance;
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private TextMeshProUGUI timerUI;
    [SerializeField]
    private TextMeshProUGUI waveUI;

    private void Start()
    {
        waveUI.text = "Wave " + wave.ToString();
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;

        var countdown = System.Math.Round((waveDelay - (timer - lastWave)), 2);

        timerUI.text = "0:" + countdown.ToString() + "s";

        if (timer >= lastWave + waveDelay)
        {
            lastWave = timer;
            SpawnWave();
            wave += 1;
            waveUI.text = "Wave " + wave.ToString();
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
