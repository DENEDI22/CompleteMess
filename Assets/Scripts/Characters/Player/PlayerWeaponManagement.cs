using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerWeaponManagement : EquipmentManagement
{

    public float pickupRange;


    private void Start()
    {
        Weapon startWeapon = equipmentPoint.GetComponentInChildren<Weapon>();

        if (startWeapon != null)
        {
            PickupWeapon(startWeapon);
        }
    }

    public void OnPickup(InputAction.CallbackContext _context)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, pickupRange);

        Weapon weaponToPickup;

        foreach (Collider hit in hits)
        {
            weaponToPickup = hit.gameObject.GetComponent<Weapon>();

            if (weaponToPickup != null)
            {
                if (weaponEquipped)
                {
                    SwapWeapons(currentEquippedWeapon, weaponToPickup);
                }
                else
                {
                    PickupWeapon(weaponToPickup);
                }

                break;
            }
        }
    }

    public void OnDrop(InputAction.CallbackContext _context)
    {
        if (weaponEquipped) DropWeapon(currentEquippedWeapon);
    }

    public void OnFire(InputAction.CallbackContext _context)
    {
        Debug.Log("FIRE");

        // Button Pressed
        if (weaponEquipped) currentEquippedWeapon.shouldAttack = true;

        // Button Hold
        if (weaponEquipped) currentEquippedWeapon.Attack();

        // Button Released
        if (weaponEquipped) currentEquippedWeapon.shouldAttack = false;

    }

    public void OnAim(InputAction.CallbackContext _context)
    {
        Debug.Log("AIM");
    }

    public void OnReload(InputAction.CallbackContext _context)
    {
        // Button Pressed
        if (weaponEquipped)
        {
            if (currentEquippedWeapon.data.weaponType == WeaponType.Gun)
            {
                ((Gun)currentEquippedWeapon).Reload();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }

}