using System;
using UnityEngine;

public class MoverCharacter : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Vector3 _finalRotation;

    public event Action OnMove;

    private void Start()
    {
        OnMove?.Invoke();
        transform.Rotate(_finalRotation);
    }

    private void Update()
    {
        Move();
    }

    public void Intialise(Vector3 finalRotation)
    {
        _finalRotation = finalRotation;
    }

    private void Move()
    {
        transform.Translate(0f, 0f, _speed * Time.deltaTime);
    }
}
