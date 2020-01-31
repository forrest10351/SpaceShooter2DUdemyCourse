using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Transform> EnemyMovementPath;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] WaveConfig waveConfig;
    
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

    private void Move()
    {
        if (wayPointIndex <= EnemyMovementPath.Count - 1)
        {
            var targetPosition = EnemyMovementPath[wayPointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
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
