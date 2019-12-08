using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponChoose : MonoBehaviour
{
    public static WeaponChoose Instance;
    public bool isGun=false;
    public bool isSnipper=false;
    public bool isAssault=false;
    public bool isRocket=false;
    public bool isGrenade=false;
    private int primaryWeaponcounter=0;
    private int heavyWeapon = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = null;
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void chooseGun()
    {
        if (primaryWeaponcounter<2)
        {
            isGun = true;
            primaryWeaponcounter++;
        }
        
    }

    public void chooseSnipper()
    {
        if (primaryWeaponcounter < 2)
        {
            isSnipper = true;
            primaryWeaponcounter++;
        }
        
    }

    public void chooseAssault()
    {
        if (primaryWeaponcounter < 2)
        {
            isAssault = true;
            primaryWeaponcounter++;
        }
       
    }

    public void chooseRocket()
    {
        if (heavyWeapon < 1)
        {
            isRocket = true;
            heavyWeapon++;
        }
        
    }

    public void chooseGrenade()
    {
        if(heavyWeapon < 1)
        {
            isGrenade = true;
            heavyWeapon++;
        }
        
    }

    public void play()
    {
       if(primaryWeaponcounter==2 && heavyWeapon == 1)
        {
            //gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
        
    }

    public bool[] getData()
    {
        bool[] res = new bool[5];
        res[0] = isSnipper;
        res[1] = isAssault;
        res[2] = isGun;
        res[3] = isRocket;
        res[4] = isGrenade;
        return res;
    }
}
