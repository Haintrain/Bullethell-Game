using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public Text weaponText;
    public int selectedWeapon;

    private List<int> availableGuns = new List<int>{0,1};
    private int listIterator;
    private GunManager equippedGun;

    void Start()
    {
        selectedWeapon = availableGuns[0];

        selectWeapon();
        equippedGun = this.GetComponentInChildren<GunManager>();
    }

    void Update()
    {
        int previouslySelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (listIterator >= availableGuns.Count - 1)
            {
                listIterator = 0;
            }
            else
            {
                listIterator++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (listIterator <= 0)
            {
                listIterator = availableGuns.Count - 1;
            }
            else
            {
                listIterator--;
            }
        }

        selectedWeapon = availableGuns[listIterator];

        if (previouslySelectedWeapon != selectedWeapon)
        {
            selectWeapon();
            equippedGun = this.GetComponentInChildren<GunManager>();
        }

        weaponText.text = equippedGun.getName() + " - Ammo : " + equippedGun.Ammo;
    }

    void selectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }   
}
