using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilotHealth : MonoBehaviour
{

    //Pilot Health text and image 
    public Image ImageHealth;
    public Text TxtHeath;

    //Pilot weapon text
    public Text TxtWeapon;

    //Pilot Ammo text and image
    public Image ImageAmmo;
    public Text TxtAmmo;

    private int min = 0;
    private int max = 100;



    private int CurrentHealth;

    private float perecentage;
    
    // Start is called before the first frame update
    void Start()
    {
        setHealth(41);
        setWeaponName("Gun");
    }

    public void setHealth(int health)
    {
        if (health != CurrentHealth)
        {
            if (max - min == 0)
            {
                CurrentHealth = 0;
                perecentage = 0;
            }
            else
            {
                CurrentHealth = health;
                perecentage = (float)CurrentHealth / (float)(max - min);
            }

            TxtHeath.text = string.Format("{0}", Mathf.RoundToInt(perecentage * 100)+"%");
            ImageHealth.fillAmount = perecentage;
        }
    }

    //Set the ammunation
    public void setAmmo(int max,int currentAmmo)
    {
        float ammopercentage = 0;
        ammopercentage = ((float)currentAmmo / (float)max);
        TxtAmmo.text=string.Format("{0}", Mathf.RoundToInt(ammopercentage * 100)+"%");
        ImageAmmo.fillAmount = ammopercentage;
    }

    public void setWeaponName(string name)
    {
        TxtWeapon.text = name;
    }

    public int GetHealth()
    {
        return CurrentHealth;
    }

}
