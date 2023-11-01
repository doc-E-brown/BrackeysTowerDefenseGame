using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 0.5f;
    public TextMeshProUGUI waveCountDownText;

    public float wavePeriod = 20f;
    private float _countDown = 2f;
    private int _waveIndex = 1;
    

    private void Update()
    {
        if (_countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countDown = wavePeriod;
        }

        _countDown -= Time.deltaTime;

        _countDown = Math.Clamp(_countDown, 0, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", _countDown);

    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        } 
        _waveIndex++;

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
