using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using static Randomiser;

public class Spawner : MonoBehaviour
{

    [SerializeField] private MoverCharacter _prefab;
    [SerializeField] private Randomiser _random;
    [SerializeField] private GameObject _target;

    private ObjectPool<MoverCharacter> _poolOfEnemyes;
    
    private float _delaySpawn = 2f;

    private void Start()
    {
        StartCoroutine(SpawnCube(_delaySpawn));

        _poolOfEnemyes = new ObjectPool<MoverCharacter>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => OnGetEnemy(obj));
    }

    private IEnumerator SpawnCube(float delay)
    {
        WaitForSeconds delayBetwinSpawn = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return delayBetwinSpawn;
            _poolOfEnemyes.Get();
        }
    }

    private void OnGetEnemy(MoverCharacter enemy)
    {
        SpawnData data = _random.ChoosePosition();

        enemy.SelectTarget(data.targetOfWalk);
        enemy.gameObject.transform.position = _random.gameObject.transform.position + data.spawnPosition;
    }
}
