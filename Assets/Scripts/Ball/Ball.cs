using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private int _reward;
    [SerializeField] private int _coefficientHealth;

    private int _health;
    private int _damage = 1;
    private int _currentHealth;
    private int _rangeForce;
    private Rigidbody2D _rigidbody2D;
    public int Reward => _reward;

    public event UnityAction<int> HealthUpdated;
    public event UnityAction<Ball> Dying;

    private void Start()
    {
        _rangeForce = Random.Range(300, 420);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentHealth = _health;
        HealthUpdated?.Invoke(_currentHealth);

        Move();
    }

    public void TryGetReproductionBall(Transform newParent, int health)
    {
        if (TryGetComponent<ReproductionBall>(out ReproductionBall ball))
        {
            Debug.Log("Reproduction");
            ball.InstantiateBall(newParent, health);
        }
    }

    public void SetHealth(int health)
    {
        _health = health * _coefficientHealth;
    }

    private void Move()
    {
        _rigidbody2D.AddForce(new Vector2(150, _rangeForce));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(_damage);
        }
        else if (collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            _currentHealth -= bullet.GetDamage();
            HealthUpdated?.Invoke(_currentHealth);
            if (_currentHealth <= 0)
            {
                Dying?.Invoke(this);
                Destroy(gameObject);
            }
        }
    }
}
