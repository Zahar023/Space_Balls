using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPistol : MonoBehaviour
{
    [SerializeField] private Pistol _pistol;
    [SerializeField] private SetShotgun _shotgun;
    [SerializeField] private Button _button;

    private int _enabled;

    private void Start()
    {
        _enabled = PlayerPrefs.GetInt("Number");
        if (_enabled == 1)
            _button.interactable = true;
        else if(_enabled == 0)
            _button.interactable = false;
    }

    public void OnClick()
    {
        PlayerPrefs.SetInt("Number", _pistol.GetNumberWeapon());
        _shotgun.SetActiveShotgun();
        _button.interactable = false;
    }

    public void SetActivePistol()
    {
        _button.interactable = true;
    }
}
