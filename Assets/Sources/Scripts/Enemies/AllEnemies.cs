using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Sceleton
}

public class AllEnemies : MonoBehaviour
{
    public EnemyType Type;

    public int Health;
    public int Power;
    public float Speed;

    protected LevelManager _lvlManager;
    protected Gun _gun;
    protected bool alive = true;
    protected Transform _playertransform;

    private void Start()
    {
        _playertransform = FindObjectOfType<FPSController>().transform;
        _gun = FindObjectOfType<Gun>();
        _lvlManager = FindObjectOfType<LevelManager>();
    }


    public virtual void Hit()
    {
        Health -= _gun.HitPower;
        if (Health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        alive = false;
        _lvlManager.EnemiesCount++;
    }
}
