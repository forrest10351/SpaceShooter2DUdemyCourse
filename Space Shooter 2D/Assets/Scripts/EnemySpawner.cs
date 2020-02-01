using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        Debug.Log(currentWave.name);
        Debug.Log(currentWave.pathPrefab.name);
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
}
