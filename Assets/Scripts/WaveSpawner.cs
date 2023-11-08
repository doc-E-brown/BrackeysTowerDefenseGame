using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive;
    public GameManager Manager;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 0.5f;
    public TextMeshProUGUI waveCountDownText;
    public Wave[] waves;

    public float wavePeriod = 20f;
    private float _countDown = 2f;
    private int _waveIndex = 1;
    

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (_waveIndex == waves.Length)
        {
            Manager.WinLevel();
            this.enabled = false;
        }
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = wavePeriod;
            return;
        }

        _countDown -= Time.deltaTime;
        _countDown = Math.Clamp(_countDown, 0, Mathf.Infinity);
        waveCountDownText.text = $"{_countDown:00.00}";

    }

    IEnumerator SpawnWave()
    {

        PlayerStats.SurvivedRound();
        if (_waveIndex < waves.Length)
        {
            Wave wave = waves[_waveIndex];
            EnemiesAlive = wave.Count;
            
            for (int i = 0; i < wave.Count; i++)
            {
                SpawnEnemy(wave.Enemy);
                yield return new WaitForSeconds(1f / wave.Rate);
            }
            _waveIndex++;
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
