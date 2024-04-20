using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _timedestoy;
    // Update is called once per frame
    void Update()
    {
        _timedestoy += Time.deltaTime;
        if (_timedestoy > 10)
        {
            Destroy(gameObject);
        }
    }

}
