using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelProgres : MonoBehaviour
{
    [SerializeField] private List<LevelConfiguration> _configsList;

    private int _index = 0;

    public event UnityAction<int> ChangeLevel;

    public void IncreaseLevel()
    {
        _index = PlayerPrefs.GetInt("Level");
        PlayerPrefs.SetInt("Level", ++_index);       
    }

    public void NextLevel()
    {
        _index = PlayerPrefs.GetInt("Level");
        GameLevel.Load(_configsList[_index]);
        ChangeLevel?.Invoke(++_index);
    }

    public void CurrentLevel()
    {
        _index = PlayerPrefs.GetInt("Level");
        GameLevel.Load(_configsList[_index]);
        ChangeLevel?.Invoke(++_index);
    }
}
