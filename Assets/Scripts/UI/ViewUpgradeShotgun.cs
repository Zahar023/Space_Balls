using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewUpgradeShotgun : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private ShotgunUpgrade _shotgunUpgrade;

    private void Start()
    {
        OnUpdateIndex(PlayerPrefs.GetInt("IndexShotgun"));
    }

    private void OnEnable()
    {
        _shotgunUpgrade.UpdateIndex += OnUpdateIndex;
    }

    private void OnDisable()
    {
        _shotgunUpgrade.UpdateIndex -= OnUpdateIndex;

    }

    private void OnUpdateIndex(int indexUpdate)
    {
        _view.text = indexUpdate.ToString();
    }
}
