using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Randomiser : MonoBehaviour
{
    private int _rangeOfSpawn =  5;
    private int _valueOfDirection = 1;

    public struct SpawnData
    {
        public Vector3 spawnPosition;
        public Vector3 spawnDirection;
    }

    public SpawnData ChoosePosition()
    {
        List<Vector3> SpawnPositions = new List<Vector3> {
            new Vector3(_rangeOfSpawn, 0, 0), new Vector3(-_rangeOfSpawn, 0, 0),
            new Vector3(0, 0, _rangeOfSpawn), new Vector3(0, 0, -_rangeOfSpawn)
        };

        List<Vector3> SpawnVector = new List<Vector3> {
            new Vector3(_valueOfDirection, 0, 0), new Vector3(-_valueOfDirection, 0, 0),
            new Vector3(0, 0, _valueOfDirection),  new Vector3(0, 0, 2 * -_valueOfDirection)
        };

        int maxRange = 4;
        int minRange = 0;

        Vector3 finalSpawnPoint = new Vector3(0, 0, 0);
        Vector3 finalRotation = new Vector3(0, 0, 0);

        int position = UnityEngine.Random.Range(minRange, maxRange);

        int rotation = UnityEngine.Random.Range(minRange, maxRange);
    
        Vector3 spawnPosition = SpawnPositions[position];
        Vector3 spawnRotation = SpawnVector[rotation];

        return new SpawnData
        {
            spawnPosition = spawnPosition,
            spawnDirection = spawnRotation
        };
    }
}
