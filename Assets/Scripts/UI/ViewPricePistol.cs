using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewPricePistol : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private PistolUpgrade _pistolUpgrade;

    private void Start()
    {
        OnUpdatePrice(PlayerPrefs.GetInt("PricePistol"));
    }

    private void OnEnable()
    {
        _pistolUpgrade.UpdatePrice += OnUpdatePrice;   
    }

    private void OnDisable()
    {
        _pistolUpgrade.UpdatePrice -= OnUpdatePrice;
    }

    private void OnUpdatePrice(int price)
    {
        _view.text = price.ToString();
    }
}
