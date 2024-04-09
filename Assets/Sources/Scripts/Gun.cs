using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    Quaternion currentRotation;
    [SerializeField] private Bullet _bul;
    [SerializeField] public float Shotperiod;
    [SerializeField] public int BulletsInMagazine;
    [SerializeField] public int BulletsAtAll = 12;
    [SerializeField] private float _bulspeed;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camrot;
    [SerializeField] public TMP_Text BulText;
    [SerializeField] public bool ReloadNow = false;
    
    public int BulletsNow;
    private float _time;
    public int HitPower = 1;
    public float _reloadTime = 3f;


    private void Start()
    {
        BulletsNow = BulletsInMagazine;

    }

    void Update()
    {

        if (!Pause.Instance.IsPause)
        {
            BulText.text = (BulletsNow.ToString() + "/" + BulletsAtAll.ToString());
            if (BulletsNow > BulletsInMagazine)
            {
                BulletsAtAll += (BulletsNow - BulletsInMagazine);
                BulletsNow = BulletsInMagazine;
            }
            if (Input.GetKey("r"))
            {
                if (ReloadNow == false && BulletsNow < BulletsInMagazine)
                {
                    ReloadCheck(1);
                }
            }
            if (BulletsNow > 0)
            {

                _time += Time.deltaTime;
                if (Input.GetMouseButton(0))
                {
                    if (_time > Shotperiod && !ReloadNow)
                    {
                        currentRotation.eulerAngles = new Vector3(90f + _camrot.eulerAngles.x, 0, 0) + _player.eulerAngles;
                        Bullet newBul = Instantiate(_bul, _spawn.position, currentRotation);
                        newBul.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulspeed;
                        _time = 0;
                        BulletsNow--;
                    }
                }
            }
            else
            {
                ReloadCheck(0);
            }
        }
    }
    private void ReloadCheck(int ind)
    {
        if (ind == 0) //вызывается автоматически
        {
            if (ReloadNow == false)
            {
                if (BulletsAtAll > BulletsInMagazine)
                {
                    ReloadNow = true;
                    StartReload(BulletsInMagazine);
                }
                else
                {
                    if (BulletsAtAll <= BulletsInMagazine && BulletsAtAll > 0)
                    {
                        ReloadNow = true;
                        StartReload(BulletsAtAll);
                    }
                }
            }
        }
        else // вызывается игроком
        {
            if (ReloadNow == false)
            {
                if (BulletsAtAll > (BulletsInMagazine - BulletsNow))
                {
                    ReloadNow = true;
                    StartReload(BulletsInMagazine - BulletsNow);
                }
                else
                {
                    if (BulletsAtAll <= (BulletsInMagazine - BulletsNow) && BulletsAtAll > 0)
                    {
                        ReloadNow = true;
                        StartReload(BulletsAtAll);
                    }
                }
            }
        }
    }

    private void StartReload(int index)
    {
        StartCoroutine(Reload(index));
    }

    private IEnumerator Reload(int index)
    {
        yield return new WaitForSeconds(_reloadTime);
        BulletsNow += index;
        BulletsAtAll -= index;
        ReloadNow = false;
    }
}
