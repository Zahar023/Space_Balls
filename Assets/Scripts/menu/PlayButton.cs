using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private LevelProgres _selectLevel;
    private void OnClick()
    {
        _selectLevel.CurrentLevel();
    }
}
