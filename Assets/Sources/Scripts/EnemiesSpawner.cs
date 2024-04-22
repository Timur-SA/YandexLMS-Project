using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawnerList;
    private Level _lvl;

    private float _timeNow = 0f;
    private int nextArrayIndex;
    private bool flag = true;

    void Start()
    {
        _lvl = FindFirstObjectByType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeNow += Time.deltaTime;
        if (_timeNow > _lvl.SpawnDelay)
        {
            for (int i = 0; i < _lvl.SpawnCount; i++)
            {
                flag = true;
                while (flag)
                {
                    nextArrayIndex = Random.Range(0, _spawnerList.Length);
                    if (_spawnerList[nextArrayIndex].Spawned == false) flag = false;
                }
                _spawnerList[nextArrayIndex].Spawn();
            }
            _timeNow= 0f;
        }
    }
}
