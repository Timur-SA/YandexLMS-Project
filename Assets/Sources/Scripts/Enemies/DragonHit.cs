using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHit : MonoBehaviour
{
    [SerializeField] private Collider _trigger; 
    private Dragon _dragon;

    private void Start()
    {
        _dragon = FindFirstObjectByType<Dragon>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("..");
        if (other.GetComponent<Bullet>())
        {
            Debug.Log(".!");
            _dragon.Hit();
            
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
