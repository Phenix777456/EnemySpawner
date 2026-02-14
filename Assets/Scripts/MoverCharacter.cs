using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoverCharacter : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private GameObject _target;

    private bool isWalk = true;

    private void Start()
    {
        RotateToTarget();
        _enemyAnimator.OnStartMoving(isWalk);
    }

    private void Update()
    {  
        Move();
    }

    public void SelectTarget(GameObject target)
    {
        _target = target;
    }

    private void Move()
    {
        Vector3 targetPos = _target.transform.position + new Vector3(0, 2, 0);

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, Time.deltaTime * _speed);

        if (targetPos == gameObject.transform.position)
        {
            isWalk = false;
            _enemyAnimator.OnStopMoving(isWalk);
        }
    }

    private void RotateToTarget()
    {
        transform.LookAt(_target.transform.position);
    }


}
