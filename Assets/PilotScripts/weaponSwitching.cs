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
    private GrenadeLauncher gl;

    private GameObject Choices;
    private GameObject Weapons;
    private GameObject snipper;
    private GameObject assault;
    private GameObject rocket;
    private GameObject grenade;
    private GameObject gun;
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
        this.snipper = Weapons.transform.Find("SnipperRiffel").gameObject;
        this.assault = Weapons.transform.Find("AssultRiffel").gameObject;
        this.gun = Weapons.transform.Find("ShotGun").gameObject;
        this.rocket = Weapons.transform.Find("RPG7").gameObject;
        this.grenade = Weapons.transform.Find("TGL").gameObject;

        this.isSnipper = Choices.GetComponent<WeaponChoose>().getData()[0];
        this.isAssault = Choices.GetComponent<WeaponChoose>().getData()[1];
        this.isGun = Choices.GetComponent<WeaponChoose>().getData()[2];
        this.isRocket = Choices.GetComponent<WeaponChoose>().getData()[3];
        this.isGrenade = Choices.GetComponent<WeaponChoose>().getData()[4];

        //Snipper riffel
        if (isSnipper)
        {
            sr = this.snipper.GetComponent<sniperRifle>();
        }
        else
        {
            Destroy(this.snipper);
            this.assault.SetActive(true);
        }
        //assult riffel
        if (isAssault)
        {
            ar = this.assault.GetComponent<assaultRifle>();

        }
        else
        {
            Destroy(this.assault);
            this.gun.SetActive(true);
        }
        //shot gun
        if (isGun)
        {

            sg = this.gun.GetComponent<shotgun>();
        }
        else
        {
            Debug.Log("Destroying the shootgun");
            Destroy(this.gun);
        }
        //RocketLauncher
        if (isRocket)
        {
            rl = this.rocket.GetComponent<RocketLauncher>();
        }
        else
        {
            Destroy(this.rocket);
        }
        //GrenadeLauncher
        if (isGrenade)
        {
            gl = this.grenade.GetComponent<GrenadeLauncher>();
        }
        else
        {
            Destroy(this.grenade);
        }
        /*if (isSnipper)
        {
            Debug.Log("Setting snipper");
            sr = Weapons.GetComponent<sniperRifle>();
            GameObject test = Weapons.transform.Find("SnipperRiffel").gameObject;
            sr = (sniperRifle)test;

        }
        else
        {
            // DestroyImmediate(Weapons.GetComponent<sniperRifle>().gameObject);
            Destroy(Weapons.transform.Find("SnipperRiffel").gameObject);
        }
        //assult riffel
        if (isAssault)
        {
            //ar = Weapons.GetComponent<assaultRifle>();
            ar = (assaultRifle)Weapons.transform.Find("AssultRiffel").gameObject;

        }
        else
        {
            //DestroyImmediate(Weapons.GetComponent<assaultRifle>().gameObject);
            Destroy(Weapons.transform.Find("AssultRiffel").gameObject);
        }
        //shot gun
        if (isGun)
        {

            //sg = Weapons.GetComponent<shotgun>();
            sg = (shotgun)Weapons.transform.Find("ShotGun").gameObject;
        }
        else
        {
            Debug.Log("Destroying the shootgun");
            //DestroyImmediate(Weapons.GetComponent<shotgun>().gameObject);
            Destroy(Weapons.transform.Find("ShotGun").gameObject);
        }
        //RocketLauncher
        if (isRocket)
        {
            //rl = Weapons.GetComponent<RocketLauncher>();
            rl = (RocketLauncher)Weapons.transform.Find("RPG7").gameObject;
        }
        else
        {
            //DestroyImmediate(Weapons.GetComponent<RocketLauncher>().gameObject);
            Destroy(Weapons.transform.Find("RPG7").gameObject);
        }*/


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectedWeapon == 1)
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
                if (w.gameObject.name == "SnipperRiffel")
                {
                    sr.setAmmo();
                }
                if (w.gameObject.name == "AssultRiffel")
                {
                    ar.setAmmo();
                }
                if (w.gameObject.name == "ShotGun")
                {
                    sg.setAmmo();
                }
                if (w.gameObject.name == "RPG7")
                {
                    rl.setAmmo();
                }
                if (w.gameObject.name == "TGL")
                {
                    gl.setAmmo();
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


