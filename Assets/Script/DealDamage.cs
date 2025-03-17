using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private Player player;
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = transform.root.GetComponent<Player>();
        damage = player.weaponData.damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TestingBlocks enemy = other.GetComponent<TestingBlocks>();
            enemy.TakeDamage(damage);
        }
    }
}
