using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetShotgun : MonoBehaviour
{
    [SerializeField] private Shotgun _shotgun;
    [SerializeField] private SetPistol _pistol;
    [SerializeField] private Button _button;

    private int _enabled;

    private void Start()
    {
        _enabled = PlayerPrefs.GetInt("Number");
        if (_enabled == 1)
            _button.interactable = false;
        else if (_enabled == 0)
            _button.interactable = true;
    }

    public void OnClick()
    {
        PlayerPrefs.SetInt("Number", _shotgun.GetNumberWeapon());
        _pistol.SetActivePistol();
        _button.interactable = false;
    }

    public void SetActiveShotgun()
    {
        _button.interactable = true;
    }
}
