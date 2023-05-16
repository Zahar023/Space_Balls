using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeShotgunButoon : MonoBehaviour
{
    [SerializeField] private ShotgunUpgrade _shotgun;
    [SerializeField] private MoneyInMenu _moneyInMenu;

    public event UnityAction<int> UpdateUpgrade;
    public event UnityAction<int> UpdatePrice;

    private void Start()
    {
        UpdateUpgrade?.Invoke(_shotgun.IndexUpgrade);
        UpdatePrice?.Invoke(_shotgun.Price);
    }

    public void OnClick()
    {
        if (_moneyInMenu.Money >= _shotgun.Price)
        {
            if (_shotgun.IndexUpgrade != _shotgun.CountUpdate)
            {
                _moneyInMenu.UpgradeMoney(_shotgun.Price);
                _shotgun.BuyUpgrade();
                UpdateUpgrade?.Invoke(_shotgun.IndexUpgrade);
                UpdatePrice?.Invoke(_shotgun.Price);
            }
        }
    }
}
