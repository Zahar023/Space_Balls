using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShotgunUpgrade : MonoBehaviour
{
    private int _price = 4;
    private static int _indexUpgrade = 0;
    private int[] _damage = { 5, 7, 10, 12, 15, 20, 25, 30 };
    private float[] _attackSpeed = { 0.5f, 0.4f, 0.3f, 0.25f, 0.2f, 0.15f, 0.1f, 0.05f};

    public int Price => _price;
    public int IndexUpgrade => _indexUpgrade;
    public int CountUpdate => _damage.Length;

    public event UnityAction<int> UpdatePrice;
    public event UnityAction<int> UpdateIndex;

    private void Start()
    {
        SetProperties();
    }

    public void BuyUpgrade()
    {
        PlayerPrefs.SetInt("IndexShotgun", ++_indexUpgrade);
        _indexUpgrade = PlayerPrefs.GetInt("IndexShotgun");
        if (_indexUpgrade <= CountUpdate)
        {
            SetNewPrice();
        }
        SetProperties();
    }

    public void SetProperties()
    {
        SaveProperties();
        if(_price == 0)
        {
            _price = 4;
            PlayerPrefs.SetInt("PriceShotgun", _price);   
        }    

        UpdatePrice?.Invoke(_price);
        UpdateIndex?.Invoke(_indexUpgrade);
    }

    private void SaveProperties()
    {
        _indexUpgrade = PlayerPrefs.GetInt("IndexShotgun");
        _price = PlayerPrefs.GetInt("PriceShotgun");
        PlayerPrefs.SetInt("DamageShotgun", _damage[_indexUpgrade]);
        PlayerPrefs.SetFloat("AttackSpeedShotgun", _attackSpeed[_indexUpgrade]);
    }

    private void SetNewPrice()
    {
        _price = PlayerPrefs.GetInt("PriceShotgun");
        _price *= 2;
        PlayerPrefs.SetInt("PriceShotgun", _price);
    }
}
