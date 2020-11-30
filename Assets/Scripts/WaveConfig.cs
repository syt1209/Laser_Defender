using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _pathPrefab;
    [SerializeField] private float _timeBtwSpawns = 0.5f;
    [SerializeField] private float _spawnRandomFactor = 0.3f;
    [SerializeField] private int _numOfEnemies = 5;
    [SerializeField] private float _moveSpeed = 2f;

    // Create public function for other scripts to get access to the configuration

    public GameObject GetEnemyPrefab() {   return _enemyPrefab;}
    public List<Transform> GetWayPoints() 
    {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in _pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints; 
    }
    public float GetTimeBtwSpawns() { return _timeBtwSpawns; }
    public float GetSpawnRandomFactor() { return _spawnRandomFactor; }
    public int GetNumOfEnemies() { return _numOfEnemies; }
    public float GetMoveSpeed() { return _moveSpeed; }
}
