using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : AllEnemies
{
    [SerializeField] public UnityEngine.AI.NavMeshAgent Agent;
    private float timedestroy = 0f;
    [SerializeField] private Collider _collider;

    private void Start()
    {
        Agent.speed = Speed;
    }


    void Update()
    {
        if (alive)
        {
            Agent.SetDestination(_playertransform.position);
        }
        else
        {
            timedestroy += Time.deltaTime;
            if (timedestroy > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.GetComponent<Bullet>())
        {
            Destroy(collision.gameObject);
            Hit();
        }
    }

    public override void Hit()
    {
        base.Hit();
    }

    public override void Die()
    {
        base.Die();
        _collider.enabled = false;
        Agent.enabled = false;
    }
}
