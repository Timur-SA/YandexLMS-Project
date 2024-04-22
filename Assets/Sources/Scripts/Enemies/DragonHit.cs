using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHit : MonoBehaviour
{
    [SerializeField] private Collider _trigger;
    [SerializeField] private Dragon _dragon;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            _dragon.Hit();
            Destroy(other.gameObject);
        }
    }

    private IEnumerator Check()
    {
        yield return new WaitForSeconds(0.01f);
        if (!_dragon.alive)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
