using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyWeaponExplosion : MonoBehaviour
{
    public bool rocketLauncher;
    public bool grenadeLauncher;
    public GameObject explosionEffect;
    private float rocketRadius = 3f;
    private float grenadeRadius = 4f;
    private Collider[] shootedEnemies;

    void OnCollisionEnter(Collision collision)
    {
        Explosion(collision.contacts[0].point);
    
    }

    void Explosion(Vector3 centerPoint)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        if (rocketLauncher)
        {
            shootedEnemies = Physics.OverlapSphere(centerPoint, rocketRadius);
            foreach (Collider shootedEnemy in shootedEnemies)
            {
                Debug.Log(shootedEnemy.gameObject.name);
                //decrease damage by 150
            }
        }
        else if (grenadeLauncher)
        {
            shootedEnemies = Physics.OverlapSphere(centerPoint, grenadeRadius);
            foreach (Collider shootedEnemy in shootedEnemies)
            {
                Debug.Log(shootedEnemy.gameObject.name);
                //decrease damage by 125
            }
        }
        Destroy(gameObject);
        //TODO: handle weapon switch
        //TODO: add mask layer when we integrate to avoid the rocket affecting the player.
        //TODO: remove cubes it is just for testing

    }
}
