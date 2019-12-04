using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 100;
    public void TakeDamage(int amount){
        health -= amount;
        Debug.Log("Health is "+health);
        if(health<=0){
            Die();
        }
    }
    void Die(){
        Destroy(this.gameObject);
    }
}
