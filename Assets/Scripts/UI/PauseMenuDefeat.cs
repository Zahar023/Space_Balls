using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuDefeat : MonoBehaviour
{
    public void ActivatePauseMenu()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
