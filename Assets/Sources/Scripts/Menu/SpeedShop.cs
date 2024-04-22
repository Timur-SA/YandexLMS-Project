using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedShop : MonoBehaviour
{
    [SerializeField] private GameObject _but;
    [SerializeField] private GameObject _text;

    
    void Update()
    {
        if (Progress.InstanceProgress.CurrentProgressData.Shotperiod <= 0.2f)
        {
            Progress.InstanceProgress.CurrentProgressData.Shotperiod = 0.2f;
            _but.SetActive(false);
            _text.SetActive(true);
        }
    }

    public void Buying()
    {
        if (Progress.InstanceProgress.CurrentProgressData.Coins >= 20)
        {
            Progress.InstanceProgress.CurrentProgressData.Coins -= 20;
            Progress.InstanceProgress.CurrentProgressData.Shotperiod -= 0.05f;
            Progress.InstanceProgress.Save();
        }
    }
}
