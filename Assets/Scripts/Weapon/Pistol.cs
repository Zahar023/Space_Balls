using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Pistol : Weapon
{
    private float _delayAttack;
    private int _number = 0;

    private void Start()
    {
        _delayAttack = PlayerPrefs.GetFloat("AttackSpeedPistol");
    }

    public override void Shoot(Transform shootPoint)
    {
        _delayAttack = PlayerPrefs.GetFloat("AttackSpeedPistol");
        Instantiate(Bullet, shootPoint.position, quaternion.identity);
    }

    public override float GetDelayAttack()
    {
        return _delayAttack;
    }

    public override int GetNumberWeapon()
    {
        return _number;
    }
}
