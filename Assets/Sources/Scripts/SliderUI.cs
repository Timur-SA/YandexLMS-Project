using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SliderUI : MonoBehaviour
{
    [SerializeField] private LevelManager _lvlManager;
    [SerializeField] private Level _lvl;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject enemiesSpawner;

    private float _timenow;

    public float val = 0;

    void Update()
    {
        _timenow += Time.deltaTime;
        if (_timenow < 3)
        {
            _text.text = Mathf.Ceil(3 - _timenow).ToString();
        }
        else
        {
            if (!GameManager.InstanceGM.GameOn)
            {
                GameManager.InstanceGM.GameOn = true;
                enemiesSpawner.SetActive(true);
            }

            val = (_lvlManager.EnemiesCount * 1.0f) / (_lvl.EnemiesAtAll * 1.0f);
            _slider.value = val;
            _text.text = "Осталось врагов: " + (_lvl.EnemiesAtAll - _lvlManager.EnemiesCount);
        }
    }
}
