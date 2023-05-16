using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewShotgunPrice : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private ShotgunUpgrade _shotgunUpgrade;

    private void Start()
    {
        OnUpdatePrice(PlayerPrefs.GetInt("PriceShotgun"));
    }

    private void OnEnable()
    {
        _shotgunUpgrade.UpdatePrice += OnUpdatePrice;
    }

    private void OnDisable()
    {
        _shotgunUpgrade.UpdatePrice -= OnUpdatePrice;
    }

    private void OnUpdatePrice(int price)
    {
        _view.text = price.ToString();
    }
}
