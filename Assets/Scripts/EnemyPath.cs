using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] WaveConfig _waveConfig;
    private List<Transform> _wayPoints;
    [SerializeField] private float _speed = 2f;
    private int _waypointIndex = 0;


    void Start()
    {
        _wayPoints = _waveConfig.GetWayPoints();
        transform.position = _wayPoints[_waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_waypointIndex <= _wayPoints.Count - 1)
        {
            var targetPosition = _wayPoints[_waypointIndex].transform.position;
            var movementThisFrame = _speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
