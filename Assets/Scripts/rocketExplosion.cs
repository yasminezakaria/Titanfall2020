using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketExplosion : MonoBehaviour
{
    public GameObject explosionEffect;
    private float rocketRadius = 3f;
    private Collider[] shootedEnemies;
    private GameObject instantiatedObj;

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
            Target target = shootedEnemy.gameObject.GetComponent<Target>();
            if (shootedEnemy.gameObject.tag == "EnemyTitan")
            {
                instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
                target.TakeDamage(150, 50);
            }

            if (shootedEnemy.gameObject.tag == "EnemyPilot")
            {
                instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
                target.TakeDamage(150, 10);
            }
        }
        Destroy(gameObject);
    }
}
