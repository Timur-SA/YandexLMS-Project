using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMain : MonoBehaviour
{
    [SerializeField] private FPSController _player;
    [SerializeField] private GameObject _textStart;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log('.');
        if (collision.gameObject.GetComponent<FPSController>())
        {
            _player.CloseToButton = true;
            if (!GameManager.InstanceGM.GameOn) _textStart.SetActive(true);
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log('.');
        if (collision.gameObject.GetComponent<FPSController>())
        {
            _player.CloseToButton = false;
            if (!GameManager.InstanceGM.GameOn) _textStart.SetActive(false);
        }
    }

}
