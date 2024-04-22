using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sceleton : AllEnemies
{
    [SerializeField] public UnityEngine.AI.NavMeshAgent Agent;
    [SerializeField] private Animator _anim;



    private float timedestroy = 0f;
    [SerializeField] private Collider _collider;

    private void Start()
    {
        Agent.speed = Speed;
    }

    private void Update()
    {
        if (!Pause.Instance.IsPause)
        {
            if (alive)
            {
                Agent.SetDestination(_playertransform.position);
            }
            else
            {
                timedestroy += Time.deltaTime;
                if (timedestroy > 2)
                {
                    Destroy(gameObject);
                }
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
        _anim.SetTrigger("Death");
    }
    
}
