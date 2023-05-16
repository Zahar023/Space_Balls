using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class ViewBallHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text _health;

    private Ball _ball;
   
    private void Awake()
    {
        _ball = GetComponent<Ball>();   
    }

    private void OnEnable()
    {
        _ball.HealthUpdated += OnHealthUpdated;
    }

    private void OnDisable()
    {
        _ball.HealthUpdated -= OnHealthUpdated;
    }

    private void OnHealthUpdated(int currentHealth)
    {
        _health.text = currentHealth.ToString();
    }
}
