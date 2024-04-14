using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool Spawned = false;
    [SerializeField] private LevelManager _lvlManager;
    [SerializeField] private Sceleton _sceleton;

    public void Spawn()
    {
        int ran = Random.Range(0, 3);
        Sceleton scelet = Instantiate(_sceleton, transform.position, transform.rotation);
        Spawned = true;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Spawned = false;
    }

}
