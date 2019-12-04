using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0;
    public Text WeaponName;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectedWeapon == 2)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
            selectWeapon();
        }
    }
    void selectWeapon()
    {
        int i = 0;
        foreach (Transform w in transform)
        {
            if (i == selectedWeapon)
            {
                w.gameObject.SetActive(true);
                WeaponName.text = w.gameObject.name.ToString();
            }
            else
            {
                w.gameObject.SetActive(false);
            }
            i++;
        }
    }
}


