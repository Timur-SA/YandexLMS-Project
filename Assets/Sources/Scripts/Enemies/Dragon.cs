using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Dragon : AllEnemies
{
    [SerializeField] private Collider _colliderFlore;
    [SerializeField] private Collider _explodeZone;
    [SerializeField] private Animator _animation;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _explosionEffect;

    private Transform _playerpos;
    private FPSController _player;
    private Vector3 _explodePosition;

    private float _timeMove = 0.5f;
    private float _timeNow = 0f;


    void Start()
    {
        _player = FindFirstObjectByType<FPSController>();
        _playerpos = _player.transform;
    }

    void Update()
    {
        if (alive)
        {
            transform.LookAt(_playerpos);
            _timeNow += Time.deltaTime;
            if (_timeNow > _timeMove)
            {
                _timeNow = 0;
                Move();
            }
        }
    }

    private void Move()
    {
        _rigidbody.velocity = transform.forward  * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerModelHitBox>() && alive)
        {
            Debug.Log("??");
            Explode();
        }
    }

    public override void Hit()
    {
        base.Hit();
    }

    public override void Die()
    {
        base.Die();
        transform.eulerAngles = new Vector3(0, 0, 0);
        _rigidbody.useGravity = true;
        _colliderFlore.enabled = true;
        _animation.SetTrigger("Die");
        StartCoroutine(Disapiar());
    }

    public void Explode()
    {
        alive = false;
        _lvlManager.EnemiesCount++;
        Destroy(gameObject);
        _player.Damage(Power);
        _explodePosition = transform.position + new Vector3(0, 2, 0);
        Instantiate(_explosionEffect, _explodePosition, Quaternion.identity);
    }

    public IEnumerator Disapiar()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
