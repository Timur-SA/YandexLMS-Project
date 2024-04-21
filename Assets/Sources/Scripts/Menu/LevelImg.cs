using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelImg : MonoBehaviour
{
    [SerializeField] private Sprite _imgEnabled;
    [SerializeField] private Sprite _imgLocked;
    [SerializeField] private Image _img;
    public int IdLevel;

    void Start()
    {
        if (Progress.InstanceProgress.CurrentProgressData.Level < IdLevel)
        {
            _img.sprite = _imgLocked;
        }
        else
        {
            _img.sprite = _imgEnabled;
        }
    }

    public void SetLevel()
    {
        if (Progress.InstanceProgress.CurrentProgressData.Level >= IdLevel) SceneManager.LoadScene(IdLevel);
    }

    

}
