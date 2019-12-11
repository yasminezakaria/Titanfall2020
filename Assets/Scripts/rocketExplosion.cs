﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketExplosion : MonoBehaviour
{
    public GameObject explosionEffect;
    private float rocketRadius = 3f;
    private Collider[] shootedEnemies;
    private GameObject instantiatedObj;
    public PilotHealth ph;

    void OnCollisionEnter(Collision collision)
    {
        Explosion(collision.contacts[0].point);

    }

    void Explosion(Vector3 centerPoint)
    {
        shootedEnemies = Physics.OverlapSphere(centerPoint, rocketRadius);
        foreach (Collider shootedEnemy in shootedEnemies)
        {
            Destroy(instantiatedObj, 3f);
            if (shootedEnemy.gameObject.tag == "EnemyTitan")
            {
                instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
                shootedEnemy.gameObject.GetComponent<EnemyTitan>().takeDamage(150);
                ph.setTitanfall(100, 50);
            }

            if (shootedEnemy.gameObject.tag == "EnemyPilot")
            {
                instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
                shootedEnemy.gameObject.GetComponent<EnemyPilot>().takeDamage(150);
                ph.setTitanfall(100, 10);

            }
        }
        Destroy(gameObject);
    }
}
