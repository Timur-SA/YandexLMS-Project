using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulMagShop : MonoBehaviour
{
    [SerializeField] private GameObject _but;
    [SerializeField] private GameObject _text;


    void Update()
    {
        if (Progress.InstanceProgress.CurrentProgressData.BulletsInMagazine == 30)
        {
            _but.SetActive(false);
            _text.SetActive(true);
        }
    }

    public void Buying()
    {
        if (Progress.InstanceProgress.CurrentProgressData.Coins >= 10)
        {
            Progress.InstanceProgress.CurrentProgressData.Coins -= 10;
            Progress.InstanceProgress.CurrentProgressData.BulletsInMagazine++;
            Progress.InstanceProgress.Save();
        }
    }
}
