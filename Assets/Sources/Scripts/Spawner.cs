using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool Spawned = false;
    [SerializeField] private LevelManager _lvlManager;
    [SerializeField] private Sceleton _sceleton;
    [SerializeField] private Dragon _dragon;

    public void Spawn()
    {
        int ran = Random.Range(0, 3);
        if ( ran < 2)
        {
            Sceleton scelet = Instantiate(_sceleton, transform.position, transform.rotation);
        }
        else
        {
            Dragon dragon = Instantiate(_dragon, transform.position, transform.rotation);
        }
        Spawned = true;
        StartCoroutine(Wait());
        _lvlManager.EnemiesOnTheField++;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        Spawned = false;
    }

}
