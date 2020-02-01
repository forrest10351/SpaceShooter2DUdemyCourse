using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Transform> EnemyMovementPath;
    
    WaveConfig waveConfig;
    
    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
     
        EnemyMovementPath = waveConfig.GetWaypoints();
        transform.position = EnemyMovementPath[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void SetWaveConfig(WaveConfig waveConfig)
    {

        //this.waveConfig is the waveConfig from the top of the class, the other waveConfig is the local variable from this small method.
        this.waveConfig = waveConfig;
    }
    private void Move()
    {
        if (wayPointIndex <= EnemyMovementPath.Count - 1)
        {
            var targetPosition = EnemyMovementPath[wayPointIndex].transform.position;
            var movementThisFrame = waveConfig.GetmoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
