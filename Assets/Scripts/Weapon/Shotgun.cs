using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private float _delayAttack;
    private int _number = 1;

    private void Start()
    {
        _delayAttack = PlayerPrefs.GetFloat("AttackSpeedShotgun");
    }

    public override void Shoot(Transform shootPoint)
    {
        _delayAttack = PlayerPrefs.GetFloat("AttackSpeedShotgun");
        Instantiate(Bullet, GetPosition(shootPoint, 1), Quaternion.identity);
        Instantiate(Bullet, GetPosition(shootPoint, -1), Quaternion.identity);
    }

    private Vector3 GetPosition(Transform shootPoint, float argument)
    {
        return new Vector3(shootPoint.position.x + 0.2f * argument, shootPoint.position.y);
    }

    public override float GetDelayAttack()
    {
        return PlayerPrefs.GetFloat("AttackSpeedShotgun");
    }

    public override int GetNumberWeapon()
    {
        return _number;
    }
}
