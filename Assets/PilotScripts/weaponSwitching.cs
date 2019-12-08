using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0;
    public Text WeaponName;

    public Image ammo;
    public Text ammoTxt;

    private assaultRifle ar;
    private sniperRifle sr;
    private shotgun sg;
    private RocketLauncher rl;

    private GameObject Choices;
    private GameObject Weapons;
    private bool isSnipper;
    private bool isAssault;
    private bool isGun;
    private bool isRocket;
    private bool isGrenade;
    // Start is called before the first frame update
    void Start()
    {
        this.Choices = GameObject.Find("ChoosenWeapons");
        this.Weapons = GameObject.Find("Weapons");
        this.isSnipper = Choices.GetComponent<WeaponChoose>().getData()[0];
        this.isAssault = Choices.GetComponent<WeaponChoose>().getData()[1];
        this.isGun = Choices.GetComponent<WeaponChoose>().getData()[2];
        this.isRocket = Choices.GetComponent<WeaponChoose>().getData()[3];
        this.isGrenade = Choices.GetComponent<WeaponChoose>().getData()[4];

        if (isSnipper)
        {
            Debug.Log("Setting snipper");
            sr = Weapons.GetComponent<sniperRifle>();

        }
        else
        {
            DestroyImmediate(Weapons.GetComponent<sniperRifle>().gameObject);
        }
        //assult riffel
        if (isAssault)
        {
            ar = Weapons.GetComponent<assaultRifle>();

        }
        else
        {
            DestroyImmediate(Weapons.GetComponent<assaultRifle>().gameObject);
        }
        //shot gun
        if (isGun)
        {
            sg = Weapons.GetComponent<shotgun>();
        }
        else
        {
            Debug.Log("Destroying the shootgun");
            DestroyImmediate(Weapons.GetComponent<shotgun>().gameObject);
        }
        //RocketLauncher
        if (isRocket)
        {
            rl = Weapons.GetComponent<RocketLauncher>();
        }
        //else
        {
            DestroyImmediate(Weapons.GetComponent<RocketLauncher>().gameObject);
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectedWeapon == 4)
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
                WeaponName.text = w.gameObject.name;
                if (isSnipper)
                {
                    sr.setAmmo();
                }
                if (isAssault)
                {
                    ar.setAmmo();
                }
                if (isGun)
                {
                    sg.setAmmo();
                }
                if (isRocket)
                {
                    rl.setAmmo();
                }

            }
            else
            {
                w.gameObject.SetActive(false);
            }
            i++;
        }
    }
}


