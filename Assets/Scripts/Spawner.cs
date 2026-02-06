using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private MoverCharacter _prefab;
    [SerializeField] private Randomiser _random;

    private ObjectPool<MoverCharacter> _poolOfEnemyes;

    private Vector3 _finalSpawnPoint;
    private Vector3 _finalRotation;
    private float _delaySpawn = 2f;

    private void Update()
    {
        StartCoroutine(SpawnCube(_delaySpawn));
    }

    private void Start()
    {
        _poolOfEnemyes = new ObjectPool<MoverCharacter>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => OnGetEnemy(obj));
    }

    private IEnumerator SpawnCube(float delay)
    {
        yield return new WaitForSeconds(delay);
        _poolOfEnemyes.Get();
        StopAllCoroutines();
    }

    private void OnGetEnemy(MoverCharacter enemy)
    {
        (_finalSpawnPoint, _finalRotation) =_random.ChoosePosition();
        enemy.gameObject.transform.Rotate(_finalRotation);
        enemy.gameObject.transform.position = _random.gameObject.transform.position + _finalSpawnPoint;
    }
}
