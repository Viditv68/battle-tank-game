using UnityEngine;

public class EnemySpawnerService : MonoSingletonGeneric<EnemySpawnerService>
{
    private GameObject enemytank;

    [SerializeField]
    private Transform enemyTransform;
    [SerializeField]
    private TankScriptableObject[] tankScriptableObject;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            int randomNumber = Random.Range(0, tankScriptableObject.Length);
            SpawnEnemyTank(randomNumber);
        }
    }

    private void SpawnEnemyTank(int randomNumber)
    {
        Quaternion rotation = enemyTransform.rotation;
        rotation.y = 180;
        enemytank = Instantiate(tankScriptableObject[randomNumber].tankPref, enemyTransform.position, rotation);
        enemytank.GetComponent<EnemyController>().InitializeValues(tankScriptableObject[randomNumber]);
    }
    
}
