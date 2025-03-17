using UnityEngine;

public static class EnemyFactory
{
    public static IEnemy CreateEnemy(string type)
    {
        switch (type)
        {
            case "Goblin": return new Goblin();
            case "Orc": return new Orc();
            case "Troll": return new Troll();
            default: throw new System.ArgumentException("Invalid enemy type");
        }
    }
}
