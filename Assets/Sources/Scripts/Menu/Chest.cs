using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator _anim;


    void OnMouseEnter()
    {
        _anim.SetTrigger("Open");
        Debug.Log("/");
        
    }

    void OnMouseExit()
    {
        _anim.SetTrigger("Close");
        Debug.Log(".");
    }
}
