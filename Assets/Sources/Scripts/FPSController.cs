using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using YG;
using UnityEngine.UIElements;

public class FPSController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _Jumpspeed = 5.0f;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private float sens = 3.0f;
    [SerializeField] private Transform _camtrans;
    [SerializeField] private GameObject _textStart;
    [SerializeField] private GameObject _levelManagerGO;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private GameObject _enemiesSpawner;
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;
    [SerializeField] private GameObject _heartImg;
    [SerializeField] private TMP_Text _textHealth;
    [SerializeField] private TMP_Text _textReward;
    [SerializeField] private TMP_Text _textRewardL;
    [SerializeField] private TMP_Text _textMenu;
    [SerializeField] private SliderUI _sliderUI;



    public int MultiJump = 1;
    public int Health = 10;
    public float Uskorenie = 1;
    public bool SafeTime = false;

    private int _currentMultiJump;
    private float _respeed;
    private float _timeNow = 0;
    private Rigidbody _rigidbody;
    private Level _lvl;
    private float xAngle;
    private bool grounded;
    private bool _isJumping = false;
    private int _damage = 0;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _respeed = _speed;
        _currentMultiJump = MultiJump;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        MinusHP();
        _lvl = FindFirstObjectByType<Level>();
    }

    void Update()
    {
        if (!Pause.Instance.IsPause)
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
            if (UnityEngine.Cursor.lockState != CursorLockMode.Locked) UnityEngine.Cursor.lockState = CursorLockMode.Locked;

            if (_lvl.EnemiesAtAll == _levelManager.EnemiesCount || _sliderUI.aaa == 0)
            {
                Win();
            }

            

        } //передвижение + прыжок + ускорение + камера

        else
        {
            _timeNow += Time.deltaTime;
            _textMenu.text = "В меню через " + (3 - Mathf.Floor(_timeNow)).ToString();
            if (_timeNow >= 3)
            {
                SceneManager.LoadScene(0);
                YandexGame.FullscreenShow();
                Pause.Instance.IsPause = false;
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

        if (collision.gameObject.GetComponent<AllEnemies>() is AllEnemies enemy)
        {
            _damage = enemy.Power;
            if (!SafeTime) Damage(_damage);
        }
    }

    public void Damage(int _damage)
    {
        if (!Pause.Instance.IsPause)
        {
            SafeTime = true;
            Health -= _damage;
            Debug.Log("!");
            MinusHP();
            _heartImg.SetActive(false);
            if (Health <= 0)
            {
                Die();
            }
            else
            {
                _heartImg.SetActive(true);
            }
            StartCoroutine(Safe());
        }
    }

    private IEnumerator Safe()
    {
        yield return new WaitForSeconds(3f);
        SafeTime = false;
    }

    public void MinusHP()
    {
        _textHealth.text = Mathf.Clamp(Health, 0, 1000).ToString();
    }


    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    private void Die()
    {
        Pause.Instance.IsPause = true;
        _loseWindow.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        _textRewardL.text = "+10";
        Progress.InstanceProgress.CurrentProgressData.Coins += 10;
        Progress.InstanceProgress.Save();
        _timeNow = 0f;

    }

    private void Win()
    {
        Pause.Instance.IsPause = true;
        _winWindow.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        _textReward.text = "+" + _lvl.Reward.ToString();
        Progress.InstanceProgress.CurrentProgressData.Coins += _lvl.Reward;
        if (Progress.InstanceProgress.CurrentProgressData.Level == SceneManager.GetActiveScene().buildIndex)
        {
            if (Progress.InstanceProgress.CurrentProgressData.Level < 3) 
            { 
                Progress.InstanceProgress.CurrentProgressData.Level++;
            }
        }
        Progress.InstanceProgress.Save();
        
        _timeNow = 0f;
    }
}
