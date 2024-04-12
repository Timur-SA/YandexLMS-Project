using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _enemiesNumber;
    public bool Spawned = false;

    public void Spawn()
    {
        int ran = Random.Range(0, _enemiesNumber);
        Debug.Log(".");
        Spawned = true;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Spawned = false;
    }

}
