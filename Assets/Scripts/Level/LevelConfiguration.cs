using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConfig", menuName = "Config")]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private List<Ball> _balls;
    [SerializeField] private int _ballHelth;

    public int BallHelth => _ballHelth;
    public List<Ball> Balls => _balls;
    public float SpawnDelay => _spawnDelay;
}

