using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameOn = false;

    public static GameManager InstanceGM;
    
    private void Awake()
    {
        if (InstanceGM == null)
        {
            InstanceGM = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
