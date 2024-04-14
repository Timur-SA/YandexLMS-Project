using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    [SerializeField] private LevelManager _lvlManager;
    [SerializeField] private Level _lvl;
    [SerializeField] private Slider _slider;

    public float val = 0;


    void Update()
    {
        val = (_lvlManager.EnemiesCount * 1.0f) / (_lvl.EnemiesAtAll * 1.0f);
        _slider.value = val;
    }
}
