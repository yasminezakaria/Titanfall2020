﻿using System.Collections;
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

    //Pilot titanFall text and Image
    public Image titanFall;
    public Text Txttitanfall;
    int currentTitanMeter=0;

    private int min = 0;
    private int max = 100;



    private int CurrentHealth;

    private float perecentage;
    
    // Start is called before the first frame update
    void Start()
    {
        setHealth(100);
        setWeaponName("SnipperRiffel");
        setTitanfall(100, 0);
    }

    //Set the player health
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

    //Set the titanfall meter
    public void setTitanfall(int max,int extraScore)
    {
        float percent = 0;
        if (currentTitanMeter + extraScore <=100)
        {
            percent = ((float)(currentTitanMeter + extraScore) / (float)max);
            Txttitanfall.text = string.Format("{0}", Mathf.RoundToInt(percent * 100) + "%");
            titanFall.fillAmount = percent;
            currentTitanMeter = currentTitanMeter+extraScore;
        }
        else
        {
            if (extraScore == 0)
            {
                currentTitanMeter = 0;
                Txttitanfall.text = string.Format("{0}", Mathf.RoundToInt(0 * 100) + "%");
                titanFall.fillAmount = percent;
                currentTitanMeter = currentTitanMeter + extraScore;
            }
        }
        
    }

    //Get the current titian fall meter
    public int getTitanfallMeter()
    {
        return currentTitanMeter;
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
