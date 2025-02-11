﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyWeaponExplosion : MonoBehaviour
{
    public bool rocketLauncher=true;
    public bool grenadeLauncher=false;
    public GameObject explosionEffect;
    private float rocketRadius = 3f;
    private float grenadeRadius = 4f;
    private Collider[] shootedEnemies;
    private GameObject instantiatedObj;
    public PilotHealth ph;


    void OnCollisionEnter(Collision collision)
    {
        Explosion(collision.contacts[0].point);
    
    }
    

    void Explosion(Vector3 centerPoint)
    {
           
        if (rocketLauncher)
        {
            shootedEnemies = Physics.OverlapSphere(centerPoint, rocketRadius);
            foreach (Collider shootedEnemy in shootedEnemies)
            {
                Debug.Log(shootedEnemy.gameObject.name);
                //Target target = shootedEnemy.gameObject.GetComponent<Target>();
                if (shootedEnemy.gameObject.tag == "EnemyTitan")
                {
                    instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
                    //target.TakeDamage(150, 50);
                    ph.setTitanfall(100, 50);
                }

                 if(shootedEnemy.gameObject.tag == "EnemyPilot")
                {
                    instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
                    //target.TakeDamage(150, 10);
                    shootedEnemy.gameObject.GetComponent<EnemyPilot>().takeDamage(150);
                }
                //decrease damage by 150
            }
        }
        else if (grenadeLauncher)
        {
            shootedEnemies = Physics.OverlapSphere(centerPoint, grenadeRadius);
            foreach (Collider shootedEnemy in shootedEnemies)
            {
                Debug.Log(shootedEnemy.gameObject.name);
                Destroy(instantiatedObj, 3f);
                //Target target = shootedEnemy.gameObject.GetComponent<Target>();
                if (shootedEnemy.gameObject.tag == "EnemyTitan")
                {
                    //target.TakeDamage(125, 50);
                    shootedEnemy.gameObject.GetComponent<EnemyTitan>().takeDamage(125);
                    ph.setTitanfall(100, 50);
                }

                if (shootedEnemy.gameObject.tag == "EnemyPilot")
                {
                    shootedEnemy.gameObject.GetComponent<EnemyPilot>().takeDamage(125);
                    ph.setTitanfall(100, 10);
                }
                //decrease damage by 125
            }
        }
        Destroy(gameObject);
        //TODO: handle weapon switch
        //TODO: add mask layer when we integrate to avoid the rocket affecting the player.
        //TODO: remove cubes it is just for testing

    }
}
