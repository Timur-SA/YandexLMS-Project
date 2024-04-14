using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _Jumpspeed = 5.0f;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private float sens = 3.0f;
    [SerializeField] private Transform _camtrans;
    [SerializeField] private GameObject _textStart;
    [SerializeField] private GameObject _levelManager;
    [SerializeField] private GameObject _enemiesSpawner;
    [SerializeField] private TMP_Text _textHealth;



    public int MultiJump = 1;
    public int Health = 10;
    public float Uskorenie = 1;
    public bool SafeTime = false;

    private int _currentMultiJump;
    private float _respeed;
    private Rigidbody _rigidbody;
    private float xAngle;
    private bool grounded;
    private bool _isJumping = false;
    private int _damage = 0;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _respeed = _speed;
        _currentMultiJump = MultiJump;
        Cursor.lockState = CursorLockMode.Locked;
        MinusHP();
    }

    void Update()
    {
        if (true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _speed *= Uskorenie;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grounded)
                {
                    _rigidbody.velocity += Vector3.up * _Jumpspeed;
                    _currentMultiJump--;
                    _isJumping = true;
                }
                else
                {
                    if (_currentMultiJump > 0)
                    {
                        _rigidbody.velocity += Vector3.up * _Jumpspeed;
                        _currentMultiJump--;
                        _isJumping = true;
                    }
                }
            } //система мульти прыжка. задается публичной переменной MultiJump.

            float turnx = Input.GetAxis("Horizontal");
            float turny = Input.GetAxis("Vertical");
            Vector3 inVect = new Vector3(turnx, 0, turny);
            Vector3 worldveloc = _playerPos.TransformVector(inVect) * _speed;
            _rigidbody.velocity = new Vector3(worldveloc.x, _rigidbody.velocity.y, worldveloc.z);

            float mousex = Input.GetAxis("Mouse X");
            float mousey = Input.GetAxis("Mouse Y");
            _playerPos.localEulerAngles += new Vector3(0f, mousex * sens, 0f);

            xAngle += mousey * sens;
            xAngle = Mathf.Clamp(xAngle, -90, 90);
            _camtrans.localEulerAngles = new Vector3(-xAngle, 0f, 0f);
            _speed = _respeed;
            
        } //передвижение + прыжок + ускорение + камера

    }


    private void OnCollisionStay(Collision collision)
    {
        if (Vector3.Angle(collision.contacts[0].normal, Vector3.up) < 15f)
        {
            grounded = true;
            if (!_isJumping) _currentMultiJump = MultiJump;
            _isJumping = false;
        }

        if (collision.gameObject.GetComponent<AllEnemies>() is AllEnemies enemy)
        {
            _damage = enemy.Power;
            if (!SafeTime) Damage();
        }
    }

    public void Damage()
    {
        SafeTime = true;
        Health -= _damage;
        Debug.Log("!");
        MinusHP();
        if (Health == 0)
        {
            //
        }
        StartCoroutine(Safe());
    }

    private IEnumerator Safe()
    {
        yield return new WaitForSeconds(3f);
        SafeTime = false;
    }

    public void MinusHP()
    {
        _textHealth.text = Health.ToString();
    }


    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }


}
