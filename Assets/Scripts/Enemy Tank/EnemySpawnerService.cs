using UnityEngine;

public class EnemySpawnerService : MonoSingletonGeneric<EnemySpawnerService>
{
    private GameObject enemytank;

    public TankScriptableObject[] tankScriptableObject;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            int randomNumber = Random.Range(0, 2);
            SpawnEnemyTank(randomNumber);
        }
    }

    private void SpawnEnemyTank(int randomNumber)
    {
        enemytank = Instantiate(tankScriptableObject[randomNumber].tankPref, Vector3.zero, Quaternion.identity);
    }
}
