using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadShop : MonoBehaviour
{
    [SerializeField] private GameObject _but;
    [SerializeField] private GameObject _text;


    void Update()
    {
        if (Progress.InstanceProgress.CurrentProgressData.ReloadTime <= 1f)
        {
            Progress.InstanceProgress.CurrentProgressData.ReloadTime = 1f;
            _but.SetActive(false);
            _text.SetActive(true);
        }
    }

    public void Buying()
    {
        if (Progress.InstanceProgress.CurrentProgressData.Coins >= 15)
        {
            Progress.InstanceProgress.CurrentProgressData.Coins -= 15;
            Progress.InstanceProgress.CurrentProgressData.ReloadTime -= 0.2f;
            Progress.InstanceProgress.Save();
        }
    }
}
