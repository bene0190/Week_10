using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Collider weaponCol;
    public WeaponData weaponData;
    public GameObject weaponHolder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        anim = GetComponent<Animator>();
        weaponData.EquipWeapon(weaponHolder);
        weaponCol = weaponHolder.GetComponentInChildren<Collider>();
        weaponCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }
    }

    public void OnSwordCollider()
    {
        weaponCol.enabled = true;
    }
    public void OffSwordCollider()
    {
        weaponCol.enabled = false;
    }
}
