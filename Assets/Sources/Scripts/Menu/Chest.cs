using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _candle;
    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _panelShop;
    [SerializeField] private TMP_Text _coinsNumb;
    [SerializeField] private Book _book;

    [SerializeField] private TMP_Text _speed;
    [SerializeField] private TMP_Text _bulMag;
    [SerializeField] private TMP_Text _reload;

    public bool OpenWindowChest = false;

    public void CloseShop()
    {
        _panelShop.SetActive(false);
        OpenWindowChest = false;
    }

    void OnMouseEnter()
    {
        if (!OpenWindowChest && !_book.OpenWindowBook)
        {
            _anim.SetTrigger("Open");
            _candle.SetActive(true);
            _light.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        _anim.SetTrigger("Close");
        _candle.SetActive(false);
        _light.SetActive(false);
    }

    void OnMouseDown()
    {
        _panelShop.SetActive(true);
        OpenWindowChest = true;
    }

    private void Update()
    {
        _coinsNumb.text = Progress.InstanceProgress.CurrentProgressData.Coins.ToString();
        _speed.text = Progress.InstanceProgress.CurrentProgressData.Shotperiod.ToString();
        _reload.text = Progress.InstanceProgress.CurrentProgressData.ReloadTime.ToString();
        _bulMag.text = Progress.InstanceProgress.CurrentProgressData.BulletsInMagazine.ToString();
    }
}
