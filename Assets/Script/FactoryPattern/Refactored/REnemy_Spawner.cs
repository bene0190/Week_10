using UnityEngine;

public class REnemy_Spawner : MonoBehaviour
{
    public void SpawnEnemy(string type)
    {
        IEnemy enemy = EnemyFactory.CreateEnemy(type);
        enemy.Attack();
    }
}
