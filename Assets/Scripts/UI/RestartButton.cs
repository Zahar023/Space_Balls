using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private LevelProgres _selectLevel;
    public void OnClick()
    {
        _selectLevel.CurrentLevel();  
    }
}
