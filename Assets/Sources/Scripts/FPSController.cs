using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _Jumpspeed = 5.0f;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private float sens = 3.0f;
    [SerializeField] private Transform _camtrans;
    [SerializeField] private GameObject _textStart;



    public int MultiJump = 1;
    public float Uskorenie = 1;
    public bool CloseToButton = false;

    private int _currentMultiJump;
    private float _respeed;
    private Rigidbody _rigidbody;
    private float xAngle;
    private bool grounded;
    private bool _isJumping = false;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _respeed = _speed;
        _currentMultiJump = MultiJump;
        Cursor.lockState = CursorLockMode.Locked;
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

        if (CloseToButton)
        {
            if (Input.GetKey("e") && !GameManager.InstanceGM.GameOn)
            {
                GameManager.InstanceGM.GameOn = true;
                _textStart.SetActive(false);
            }
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (Vector3.Angle(collision.contacts[0].normal, Vector3.up) < 15f)
        {
            grounded = true;
            if (!_isJumping) _currentMultiJump = MultiJump;
            _isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }


}
