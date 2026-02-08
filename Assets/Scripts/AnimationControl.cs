using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private MoverCharacter _moverCharacter;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _moverCharacter.OnMove += OnStartMoving;
    }

    private void OnDisable()
    {
        _moverCharacter.OnMove -= OnStartMoving;
    }

    private void OnStartMoving()
    {
        _animator.SetBool("isMove", true);
    }
}
