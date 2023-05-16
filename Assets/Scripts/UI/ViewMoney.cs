using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private Player _player;

    private void Start()
    {
        OnMoneyChanged(_player.Money);
    }

    private void OnEnable()
    {
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        Debug.Log(money);
        _view.text = money.ToString();
    }
}
