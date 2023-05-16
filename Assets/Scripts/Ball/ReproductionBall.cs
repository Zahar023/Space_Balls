using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]

public class ReproductionBall : MonoBehaviour
{
    [SerializeField] private List<Ball> _balls;
    private void Awake()
    {
        Ball ball = GetComponent<Ball>();   
    }

    public void InstantiateBall(Transform newParent, int health)
    {
        for (int i = 0; i < _balls.Count; i++)
        {
            Debug.Log("instantiate");
            Ball _template = _balls[i];
            Ball ball = Instantiate(_template, transform.position, Quaternion.identity).GetComponent<Ball>();
            ball.SetHealth(health);
            ball.transform.SetParent(newParent);
            ball.Dying += OnBallDying;
        } 
    }

    private void OnBallDying(Ball ball)
    {
        ball.Dying -= OnBallDying;
    }
}
