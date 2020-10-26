using UnityEngine;

public class EnemySpawnerService : MonoSingletonGeneric<EnemySpawnerService>
{
    private GameObject enemytank;

    public Transform enemyTransform;
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
        Quaternion rotation = enemyTransform.rotation;
        rotation.y = 180;
        enemytank = Instantiate(tankScriptableObject[randomNumber].tankPref, enemyTransform.position, rotation);
    }
}
