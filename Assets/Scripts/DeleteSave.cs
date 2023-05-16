using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSave : MonoBehaviour
{
    public void OnCick()
    {
        PlayerPrefs.DeleteAll();
        Menu.Load();
    }
}
