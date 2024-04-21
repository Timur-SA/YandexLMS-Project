using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool IsPause = false;

    public static Pause Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PauseOn()
    {
        IsPause = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
    public void PauseOf()
    {
        IsPause = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        
    }
}