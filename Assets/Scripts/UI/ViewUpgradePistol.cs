using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewUpgradePistol : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private PistolUpgrade _pistolUpgrade;

    private void Start()
    {
        OnUpdateIndex(PlayerPrefs.GetInt("IndexPistol"));
    }

    private void OnEnable()
    {
        _pistolUpgrade.UpdateIndex += OnUpdateIndex;
    }

    private void OnDisable()
    {
        _pistolUpgrade.UpdateIndex -= OnUpdateIndex;
    }

    private void OnUpdateIndex(int indexUpgrade)
    {
        _view.text = indexUpgrade.ToString();
    }
}
