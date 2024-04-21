using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

[System.Serializable]
public class ProgressData
{
    public int Level = 1;
    public int Coins = 0;
    public int BulletsInMagazine = 10;
    public float Shotperiod = 0.6f;
    public float ReloadTime = 3f;
}

public class Progress : MonoBehaviour
{
    public ProgressData CurrentProgressData;
    public static Progress InstanceProgress;

    private void Awake()
    {

        if (InstanceProgress == null)
        {
            InstanceProgress = this;
            DontDestroyOnLoad(gameObject);
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [ContextMenu("Save")]
    public void Save()
    {
        string json = JsonUtility.ToJson(CurrentProgressData);

        YandexGame.savesData.DataJson = json;
        YandexGame.SaveProgress();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        YandexGame.LoadProgress();
        string json = YandexGame.savesData.DataJson;

        if (string.IsNullOrEmpty(json))
        {
            CurrentProgressData = new ProgressData();
        }
        else
        {
            CurrentProgressData = JsonUtility.FromJson<ProgressData>(json);
        }
    }
}

