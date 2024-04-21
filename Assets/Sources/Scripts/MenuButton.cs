using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MenuButton : MonoBehaviour
{
    public void GoMenu()
    {
        Pause.Instance.IsPause = false;
        SceneManager.LoadScene(0);
        Debug.Log("Memu");
    }
}
