using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimator : MonoBehaviour
{
    private const string isMove = nameof(isMove);

    [SerializeField] private Animator _animator;

    public void OnStartMoving(bool isWalk)
    {
        _animator.SetBool(isMove, isWalk);
    }

    public void OnStopMoving(bool isWalk)
    {
        _animator.SetBool(isMove, isWalk);
    }
}
