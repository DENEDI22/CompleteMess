using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManagement : MonoBehaviour
{


    public Transform equipmentPoint;

    [HideInInspector]
    public Weapon currentEquippedWeapon;
    public bool weaponEquipped = false;


    public void PickupWeapon(Weapon weapon)
    {
        // weapon.transform.parent = equipmentPoint;
        weapon.transform.parent = equipmentPoint.transform;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
        weapon.transform.localScale = Vector3.one;
        weapon.GetComponent<Collider>().isTrigger = true;
        weapon.GetComponent<Rigidbody>().isKinematic = true;

        weaponEquipped = true;
        currentEquippedWeapon = weapon;
    }

    public void DropWeapon(Weapon weapon, float force = 5f)
    {
        if(weapon.transform.parent != null) weapon.transform.parent = null;

        // Add force (make a better implementation of this later or sumthing)
        weapon.GetComponent<Collider>().isTrigger = false;
        Rigidbody rb = weapon.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce((equipmentPoint.forward + transform.up) * force, ForceMode.Impulse);

        weaponEquipped = false;
        currentEquippedWeapon = null;
    }

    public void DropWeapon(Weapon weapon, Vector3 direction, float force = 5f)
    {
        weapon.transform.parent = null;

        // Add force (make a better implementation of this later or sumthing)
        weapon.GetComponent<Collider>().isTrigger = false;
        Rigidbody rb = weapon.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(direction * force, ForceMode.Impulse);

        weaponEquipped = false;
        currentEquippedWeapon = null;
    }

    public void SwapWeapons(Weapon equippedWeapon, Weapon targetWeapon)
    {
        DropWeapon(equippedWeapon);
        PickupWeapon(targetWeapon);
    }

}
