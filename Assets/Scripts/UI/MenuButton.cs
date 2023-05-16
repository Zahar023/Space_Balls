using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Player _player;
    public void OnClick()
    {
        Menu.Load();
        _player.AddMoney(0);
    }
}
