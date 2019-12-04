using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilotHealth : MonoBehaviour
{
    public Image ImageHealth;
    public Text TxtHeath;
    public Text TxtWeapon;
    private int min = 0;
    private int max = 100;

    private int CurrentHealth;
    private float perecentage;
    //private int pilotHealth = 100;
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

            TxtHeath.text = string.Format("{0}", Mathf.RoundToInt(perecentage * 100));
            ImageHealth.fillAmount = perecentage;
        }
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
