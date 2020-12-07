using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    private WaveConfig _waveConfig;
    private List<Transform> _wayPoints;
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

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this._waveConfig = waveConfig;
    }

    private void Move()
    {
        float speed = _waveConfig.GetMoveSpeed();
        if (_waypointIndex <= _wayPoints.Count - 1)
        {
            var targetPosition = _wayPoints[_waypointIndex].transform.position;
            var movementThisFrame = speed * Time.deltaTime;
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
