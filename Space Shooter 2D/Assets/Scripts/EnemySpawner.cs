using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // I think a do while loop will always do the first iteration of the loop even if the while condition is false
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);//while looping = true
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemycount = 0; enemycount < waveConfig.GetnumberOfEnemies(); enemycount++)
        {
           var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyMovement>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GettimeBetweenSpawns());
        }

    }
    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex=startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));

        }
    }
}
