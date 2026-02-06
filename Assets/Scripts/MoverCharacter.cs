using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MoverCharacter : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        transform.Translate(0f, 0f, _speed * Time.deltaTime);
        _animator.SetBool("isMove", true);
    }
}
