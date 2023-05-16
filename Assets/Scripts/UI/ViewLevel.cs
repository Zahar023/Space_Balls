using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private LevelProgres _level;

    private void Start()
    {
        OnChangeLevel(PlayerPrefs.GetInt("Level") + 1);
    }

    private void OnEnable()
    {
        _level.ChangeLevel += OnChangeLevel;
    }

    private void OnDisable()
    {
        _level.ChangeLevel -= OnChangeLevel;
    }

    private void OnChangeLevel(int index)
    {
        _view.text = index.ToString();
    }
}
