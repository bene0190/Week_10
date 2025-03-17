using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity;
public class UEnemy_Spawner : MonoBehaviour
{
    public List<GameObject> Shapes;
    public GameObject Spawner;
    public void SpawnEnemy(string type)
    {
        if (type == "Sphere")
        {
            Sphere _sphere = new Sphere();
            _sphere.Attack();

        }
        else if (type == "Cube")
        {
            Cube _cube = new Cube();
            _cube.Attack();
        }
        else if (type == "Cylinder")
        {
            Cylinder _cylinder = new Cylinder();
            _cylinder.Attack();
        }
        else
        {
            Debug.Log("Ërror Name");
        }
    }
}
public class Sphere
{
    public void Attack() => Debug.Log("Sphere attacks!");
}

public class Cube
{
    public void Attack() => Debug.Log("Cube attacks!");
}

public class Cylinder
{
    public void Attack() => Debug.Log("Cylinder smashes!");
}
