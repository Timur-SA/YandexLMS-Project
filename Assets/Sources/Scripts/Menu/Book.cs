using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _candle;

    void OnMouseEnter()
    {
        _anim.SetTrigger("Up");
        _candle.SetActive(true);
    }

    void OnMouseExit()
    {
        _anim.SetTrigger("Down");
        _candle.SetActive(false);
    }
}
