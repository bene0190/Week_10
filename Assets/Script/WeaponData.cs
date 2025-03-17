using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab;
    public int damage;

    public void EquipWeapon(GameObject playerHand)
    {
        if (weaponPrefab != null)
        {
            GameObject weaponInstance = Instantiate(weaponPrefab, playerHand.transform);
            weaponInstance.transform.localPosition = Vector3.zero;
            weaponInstance.transform.localRotation = Quaternion.identity;
        }
    }
}
