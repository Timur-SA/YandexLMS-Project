using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level _lvl;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private Animator _gatesOpen;
    [SerializeField] private GameObject _enSpawner;


    private int _secNow;
    private float _timeNow = 0f;
    private float _timeLeft;
    public bool IsPlaying = true;
    public bool LevelDone = false;
    public int EnemiesCount = 0;

    void Start()
    {
        _timeLeft = _lvl.TimeToLive;
        _secNow = _lvl.TimeToLive;
        _timer.text = _secNow.ToString();
    }

    void Update()
    {
        _timeLeft -= Time.deltaTime;
        _timeNow += Time.deltaTime;
        if (IsPlaying)
        { 
            if (_timeNow > 1)
            {
                _timeNow = 0f;
                _secNow--;
                if (_secNow > 59)
                {
                    _timer.text = (_secNow / 60).ToString() + ":" + (_secNow % 60).ToString();
                }
                else
                {
                    _timer.text = _secNow.ToString();
                }
            }
            if (_secNow <= 0)
            {
                IsPlaying = false;
                LevelDone = true;
                _timer.text = "";
                _enSpawner.SetActive(false);
            }
        }   
        

        if (LevelDone && EnemiesCount == 0) 
        {
            _gatesOpen.SetTrigger("Open");
            LevelDone = false;
        }
        
    }
}
