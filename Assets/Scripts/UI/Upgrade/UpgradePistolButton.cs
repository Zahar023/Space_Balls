using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradePistolButton : MonoBehaviour
{
    [SerializeField] private PistolUpgrade _pistol;
    [SerializeField] private MoneyInMenu _moneyInMenu;

    public event UnityAction<int> UpdateUpgrade;

    private void Start()
    {
        UpdateUpgrade?.Invoke(_pistol.IndexUpgrade);
    }

    public void OnClick()
    {
        if(_moneyInMenu.Money >= _pistol.Price)
        {
            if(_pistol.IndexUpgrade != _pistol.CountUpdate)
            {
                _moneyInMenu.UpgradeMoney(_pistol.Price);
                _pistol.BuyUpgrade();
                UpdateUpgrade?.Invoke(_pistol.IndexUpgrade);
            }
        }
    }
}
