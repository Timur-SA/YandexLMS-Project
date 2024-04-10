using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMain : MonoBehaviour
{
    [SerializeField] private FPSController _player;
    [SerializeField] private Transform _playerpos;
    [SerializeField] private GameObject _textStart;
    [SerializeField] private Transform _this;

    private void Update()
    {
        float rast = Vector3.Distance(_this.position, _playerpos.position);
        if (rast < 3)
        {
            _player.CloseToButton = true;
            if (!GameManager.InstanceGM.GameOn) _textStart.SetActive(true);
        }
        else
        {
            _player.CloseToButton = false;
            if (!GameManager.InstanceGM.GameOn) _textStart.SetActive(false);
        }
    }
}
