using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyInMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    private int _money;

    public int Money => _money;
    private void Start()
    {
        _money = PlayerPrefs.GetInt("money");
        ViewMoney(_money);
    }

    private void ViewMoney(int money)
    {
        _view.text = money.ToString();
    }

    public void UpgradeMoney(int price)
    {
        _money -= price;
        PlayerPrefs.SetInt("money",_money );
        ViewMoney(_money);
    }
}
