using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private void FixedUpdate()
    {
        if (weaponEquipped)
        {
            currentEquippedWeapon.Attack();
        }
    }

    public void OnPickup(InputAction.CallbackContext context)
    {
        // Button Pressed
        if (context.started)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, pickupRange);

            Weapon weaponToPickup = null;
            Weapon weapon;
            float closest = pickupRange;

            foreach (Collider hit in hits)
            {
                weapon = hit.gameObject.GetComponent<Weapon>();

                if (weapon != null && weapon.transform.parent == null)
                {
                    float dist = Vector3.Distance(transform.position, weapon.transform.position);
                    if (dist < closest)
                    {
                        weaponToPickup = weapon;
                        closest = dist;
                    }
                }
            }

            if (weaponToPickup == null) return;

            if (weaponEquipped)
            {
                SwapWeapons(currentEquippedWeapon, weaponToPickup);
            }
            else
            {
                PickupWeapon(weaponToPickup);
            }
        }
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
        // Button Pressed
        if (context.started)
        {
            if (weaponEquipped) DropWeapon(currentEquippedWeapon);
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        // Button Pressed
        if (context.started)
        {
            if (weaponEquipped) currentEquippedWeapon.shouldAttack = true;
        }

        // Button Released
        if (context.canceled)
        {
            if (weaponEquipped) currentEquippedWeapon.shouldAttack = false;
        }
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        // Button Pressed
        if (context.started)
        {
            if (weaponEquipped)
            {
                if (currentEquippedWeapon.data.weaponType == WeaponType.Gun)
                {
                    Debug.Log("Reloading");
                    ((Gun)currentEquippedWeapon).Reload();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }

}