using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private Level _lvl;
    [SerializeField] private GameObject _enSpawner;


    public bool IsPlaying = true;
    public bool LevelDone = false;
    public int EnemiesCount = 0;
    public int EnemiesOnTheField = 0;

    private void Start()
    {
        _lvl = FindFirstObjectByType<Level>();
    }

    void Update()
    {
        if (IsPlaying)
        { 
            
            if (EnemiesOnTheField >= _lvl.EnemiesAtAll)
            {
                IsPlaying = false;
                LevelDone = true;
                _enSpawner.SetActive(false);
            }
        }   
        
        
    }
}
