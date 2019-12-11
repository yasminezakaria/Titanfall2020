﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeExplosion : MonoBehaviour
{
    public GameObject explosionEffect;
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
        shootedEnemies = Physics.OverlapSphere(centerPoint, grenadeRadius);
        foreach (Collider shootedEnemy in shootedEnemies)
        {
            Destroy(instantiatedObj, 3f);
            //Target target = shootedEnemy.gameObject.GetComponent<Target>();
            if (shootedEnemy.gameObject.tag == "EnemyTitan")
            {
                instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
                shootedEnemy.gameObject.GetComponent<EnemyTitan>().takeDamage(125);
                ph.setTitanfall(100, 50);
            }

            if (shootedEnemy.gameObject.tag == "EnemyPilot")
            {
                instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
                //target.TakeDamage(125, 10);
                shootedEnemy.gameObject.GetComponent<EnemyPilot>().takeDamage(125);
                ph.setTitanfall(100, 10);
            }
        }
        Destroy(gameObject);

    }
}
