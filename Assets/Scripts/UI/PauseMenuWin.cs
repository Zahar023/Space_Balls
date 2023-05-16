using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuWin : MonoBehaviour
{
    [SerializeField] private LevelProgres _levelProgres;
    public void ActivatePauseMenu()
    {
        Time.timeScale = 0;
        _levelProgres.IncreaseLevel();
        gameObject.SetActive(true);
    }
}
