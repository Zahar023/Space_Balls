using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private int _health;
    [SerializeField] private float _playerVelocity;
    [SerializeField] private PauseMenuDefeat _defeatMenu;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber;
    private int _currentHealth;
    private Vector3 _playerPosition;
    private float _timeAttack;
    private float _timeEnabled;

    public event UnityAction<int> MoneyChanged;
    public int Money { get; private set; }

    private void Start()
    {

        _currentWeaponNumber = PlayerPrefs.GetInt("Number");
        _currentHealth = _health;
        _playerPosition = gameObject.transform.position;
        Money = PlayerPrefs.GetInt("money");
        MoneyChanged?.Invoke(Money);

        InstalWeapon(_weapons[_currentWeaponNumber]);
    }

    private void Update()
    {
        _timeAttack += Time.deltaTime;
        _timeEnabled += Time.deltaTime;

        CheckColdownAttack();
        CheckColdownEnabled();
    }
    public void ApplyDamage(int damage)
    {
        if (_timeEnabled > 3 || _currentHealth == 5)
        {
            _currentHealth -= damage;
            _spriteRenderer.color = Color.red;
            _timeEnabled = 0;
        }

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            _defeatMenu.ActivatePauseMenu();
        }

    }

    public void AddMoney(int money)
    {
        Money += money;
        PlayerPrefs.SetInt("money", Money);
        MoneyChanged?.Invoke(Money);
    }

    private void CheckColdownAttack()
    {
        if (_timeAttack > _currentWeapon.GetDelayAttack())
        {
            Debug.Log(_currentWeapon.GetDelayAttack());
            _currentWeapon.Shoot(_shootPoint);
            _timeAttack = 0;
        }
    }

    private void InstalWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    private void CheckColdownEnabled()
    {
        if (_timeEnabled > 3)
        {
            _spriteRenderer.color = Color.white;
        }
    }
}
