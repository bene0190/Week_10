using UnityEngine;

public interface IEnemy 
{
   void Attack();
}

// Enemy classes implementing IEnemy
public class Goblin : MonoBehaviour, IEnemy 
{
    public void Attack() => Debug.Log("Goblin attacks!");
}

public class Orc : IEnemy
{
    public void Attack() => Debug.Log("Orc attacks!");
}

public class Troll : IEnemy
{
    public void Attack() => Debug.Log("Troll smashes!");
}




