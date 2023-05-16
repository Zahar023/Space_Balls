using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Player _player;
    [SerializeField] private List<Ball> _balls;
    [SerializeField] private PauseMenuWin _pauseMenu;

    private bool _paused = true;
    private int _ballHealth;
    private Ball _template;
    private float _timeAfterLastSpawn;
    private int _indexBall;

    private void Start()
    {
        Time.timeScale = 1;
        Debug.Log("Start");
    }

    private void FixedUpdate()
    {
        if (_balls.Count == _indexBall)
        {
            CheckBallsInScene();
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _spawnDelay)
        {
            _template = _balls[_indexBall];
            _indexBall++;
            InstantiateBall();
            _timeAfterLastSpawn = 0;
        }
    }
    public void OnSceneLoaded(LevelConfiguration argument)
    {
        _ballHealth = argument.BallHelth;
        _spawnDelay = argument.SpawnDelay;
        _balls = argument.Balls;
    }

    private void InstantiateBall()
    {
        Transform spawnPoint = _spawnPoints[Random.Range(0, 3)];
        Ball ball = Instantiate(_template, spawnPoint.position, Quaternion.identity, transform).GetComponent<Ball>();
        ball.SetHealth(_ballHealth);
        ball.Dying += OnBallDying;
    }

    private void OnBallDying(Ball ball)
    {
        ball.TryGetReproductionBall(transform, _ballHealth);
        ball.Dying -= OnBallDying;
        _player.AddMoney(ball.Reward);
    }

    private void CheckBallsInScene()
    {
        if (transform.childCount == 0 && _paused)
        {
            _pauseMenu.ActivatePauseMenu();
            _paused = false;
        }
    }
}
