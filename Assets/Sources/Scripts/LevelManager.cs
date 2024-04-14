using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level _lvl;
    [SerializeField] private GameObject _enSpawner;


    public bool IsPlaying = true;
    public bool LevelDone = false;
    public int EnemiesCount = 0;

    void Update()
    {
        if (IsPlaying)
        { 
            
            if (EnemiesCount >= _lvl.EnemiesAtAll)
            {
                IsPlaying = false;
                LevelDone = true;
                _enSpawner.SetActive(false);
            }
        }   
        
        
    }
}
