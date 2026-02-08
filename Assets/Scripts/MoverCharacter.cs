using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoverCharacter : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private Vector3 _finalRotation;

    private bool isWalk = true;

    public Vector3 finalRotation
    {
        private get { return _finalRotation; }

        set { _finalRotation = value; }
    }

    public event Action OnMove;

    private void Start()
    {
        OnMove?.Invoke();
        _enemyAnimator.OnStartMoving(isWalk);
        transform.Rotate(finalRotation);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0f, 0f, _speed * Time.deltaTime);
    }
}
