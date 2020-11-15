using UnityEngine;

public class EnemySpawnerService : MonoSingletonGeneric<EnemySpawnerService>
{
    private GameObject enemytank;

    [SerializeField]
    private Transform[] enemyTransform;
    [SerializeField]
    private TankScriptableObject[] tankScriptableObject;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            for(int i = 0; i < enemyTransform.Length; i++)
            {
                SpawnEnemyTank(i);
            }
            
        }
    }

    private void SpawnEnemyTank(int index)
    {
        Quaternion rotation = enemyTransform[index].rotation;
        rotation.y = 180;
        enemytank = Instantiate(tankScriptableObject[index].tankPref, enemyTransform[index].position, rotation);
        enemytank.GetComponent<EnemyController>().InitializeValues(tankScriptableObject[index]);
    }
    
}
