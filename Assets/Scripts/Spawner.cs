using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _target;
    [SerializeField] private Randomiser _random;

    private ObjectPool<GameObject> _poolOfEnemyes;

    private Vector3 _finalSpawnPoint;
    private Vector3 _finalRotation;
    private float _delaySpawn = 2f;

    private void Awake()
    {
        InvokeRepeating(nameof(SpawnCube), 0, _delaySpawn);
    }

    private void Start()
    {
        _poolOfEnemyes = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => OnGetEnemy(obj));
    }

    private void SpawnCube()
    {
        _poolOfEnemyes.Get();
    }

    private void OnGetEnemy(GameObject Enemy)
    {
        (_finalSpawnPoint, _finalRotation) =_random.ChoosePosition();
        Enemy.transform.Rotate(_finalRotation);
        Enemy.transform.position = _target.transform.position + _finalSpawnPoint;
    }
}
