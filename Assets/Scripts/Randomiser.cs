using UnityEngine;

public class Randomiser : MonoBehaviour
{
    private int _rangeOfSpawn = 5;
    private int _rangeOfRotation = 90;

    public (Vector3, Vector3) ChoosePosition()
    {
        const int FirstPosition = 1;
        const int SecondPosition = 2;
        const int ThirdPosition = 3;
        const int FourthPosition = 4;

        int maxRange = 5;
        int minRange = 1;
        Vector3 finalSpawnPoint = new Vector3(0, 0, 0);
        Vector3 finalRotation = new Vector3(0, 0, 0);

        int position = UnityEngine.Random.Range(minRange, maxRange);

        switch (position)
        {
            case FirstPosition:
                finalSpawnPoint = new Vector3(_rangeOfSpawn, 0, 0);
                break;
            case SecondPosition:
                finalSpawnPoint = new Vector3(-_rangeOfSpawn, 0, 0);
                break;
            case ThirdPosition:
                finalSpawnPoint = new Vector3(0, 0, _rangeOfSpawn);
                break;
            case FourthPosition:
                finalSpawnPoint = new Vector3(0, 0, -_rangeOfSpawn);
                break;
        }

        int rotation = UnityEngine.Random.Range(minRange, maxRange);

        switch (rotation)
        {
            case FirstPosition:
                finalRotation = new Vector3(0, _rangeOfRotation, 0);
                break;
            case SecondPosition:
                finalRotation = new Vector3(0, -_rangeOfRotation, 0);
                break;
            case ThirdPosition:
                finalRotation = new Vector3(0, 0, 0);
                break;
            case FourthPosition:
                finalRotation = new Vector3(0, 2 * _rangeOfRotation, 0);
                break;
        }

        return (finalSpawnPoint, finalRotation);
    }
}
