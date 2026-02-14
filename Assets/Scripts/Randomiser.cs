using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Randomiser : MonoBehaviour
{
    [SerializeField] private GameObject _target1;
    [SerializeField] private GameObject _target2;
    [SerializeField] private GameObject _target3;
    [SerializeField] private GameObject _target4;

    private int _rangeOfSpawn =  5;
    private int _valueOfDirection = 1;

    public struct SpawnData
    {
        public Vector3 spawnPosition;
        //public Quaternion spawnDirection;
        public GameObject targetOfWalk;
    }

    public SpawnData ChoosePosition()
    {
        List<Vector3> SpawnPositions = new List<Vector3> {
            new Vector3(_rangeOfSpawn, 0, 0), new Vector3(-_rangeOfSpawn, 0, 0),
            new Vector3(0, 0, _rangeOfSpawn), new Vector3(0, 0, -_rangeOfSpawn)
        };

        //List<Quaternion> SpawnVector = new List<Quaternion> {
        //    new , new Vector3(-_valueOfDirection, 0, 0),
        //    new Vector3(0, 0, _valueOfDirection),  new Vector3(0, 0, 2 * -_valueOfDirection)
        //};

        List<GameObject> Targets = new List<GameObject> {
            _target1, _target2,
            _target3, _target4
        };

        int maxRange = 4;
        int minRange = 0;

        Vector3 finalSpawnPoint = new Vector3(0, 0, 0);
        Vector3 finalRotation = new Vector3(0, 0, 0);
        GameObject ChousenTarget = null;

        int position = UnityEngine.Random.Range(minRange, maxRange);

        int rotation = UnityEngine.Random.Range(minRange, maxRange);

        int target = UnityEngine.Random.Range(minRange, maxRange);

        Vector3 spawnPosition = SpawnPositions[position];
        //Vector3 spawnRotation = SpawnVector[rotation];
        ChousenTarget = Targets[target];

        return new SpawnData
        {
            spawnPosition = spawnPosition,
            //spawnDirection = spawnRotation,
            targetOfWalk = ChousenTarget
        };
    }
}
