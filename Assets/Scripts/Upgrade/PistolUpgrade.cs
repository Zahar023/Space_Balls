using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistolUpgrade : MonoBehaviour
{
    private int _price = 1;
    private static int _indexUpgrade = 0;
    private int[] _damage = { 1, 3, 5, 7, 10, 15, 20, 30,};
    private float[] _attackSpeed = { 0.5f, 0.4f, 0.3f, 0.25f, 0.2f, 0.15f, 0.1f, 0.05f };
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
        PlayerPrefs.SetInt("IndexPistol", ++_indexUpgrade);
        _indexUpgrade = PlayerPrefs.GetInt("IndexPistol");
        if (_indexUpgrade <= CountUpdate)
        {
            SetNewPrice();
        }
        SetProperties();
    }

    public void SetProperties()
    {
        SaveProperties();
        if (_price == 0)
        {
            _price = 1;
            PlayerPrefs.SetInt("PricePistol", _price);
        }

        UpdatePrice?.Invoke(_price);
        UpdateIndex?.Invoke(_indexUpgrade);
    }

    private void SaveProperties()
    {
        _indexUpgrade = PlayerPrefs.GetInt("IndexPistol");
        _price = PlayerPrefs.GetInt("PricePistol");
        PlayerPrefs.SetInt("DamagePistol", _damage[_indexUpgrade]);
        PlayerPrefs.SetFloat("AttackSpeedPistol", _attackSpeed[_indexUpgrade]);
    }

    private void SetNewPrice()
    {
        _price = PlayerPrefs.GetInt("PricePistol");
        _price *= 2;
        PlayerPrefs.SetInt("PricePistol", _price);
    }
}
