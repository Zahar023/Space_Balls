using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotgun : Bullet
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLive;

    private int _damage;

    private void Start()
    {
        SetProperty();
        Destroy(gameObject, _timeLive);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime, Space.World);
    }

    public override int GetDamage()
    {
        Destroy(gameObject);
        return (_damage);
    }

    public void SetProperty()
    {
        _damage = PlayerPrefs.GetInt("DamageShotgun");
    }
}
