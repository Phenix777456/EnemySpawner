using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoverCharacter : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private Vector3 _spawnVector;
    private bool isWalk = true;


    private void Start()
    {
        _enemyAnimator.OnStartMoving(isWalk);
    }

    private void Update()
    {
        Move();
    }

    public void Initialise(Vector3 spawnVector)
    {
        _spawnVector = spawnVector * Time.deltaTime * _speed;
    }

    private void Move()
    {
        transform.Translate(_spawnVector);
    }
}
