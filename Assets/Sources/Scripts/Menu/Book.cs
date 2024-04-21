using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Book : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _candle;
    [SerializeField] private GameObject _light;
    [SerializeField] private Chest _chest;
    [SerializeField] private GameObject _panelMap;

    public bool OpenWindowBook = false;



    void OnMouseEnter()
    {
        if (!_chest.OpenWindowChest && !OpenWindowBook)
        {
            _anim.SetTrigger("Up");
            _candle.SetActive(true);
            _light.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        _anim.SetTrigger("Down");
        _candle.SetActive(false);
        _light.SetActive(false);
    }

    void OnMouseDown()
    {
        _panelMap.SetActive(true);
        OpenWindowBook = true;
    }

    public void ExitMenu()
    {
        OpenWindowBook = false;
        _panelMap.SetActive(false);
    }

}
