using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float weaponForce;
    public PilotHealth ph;
    private bool shooted = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ph.setAmmo(100, 100);
            shooted = false;
        }

        if (Input.GetMouseButtonDown(0) && shooted == false)
        {
            ShootGrenade();
            shooted = true;
        }
    }
    public void setAmmo()
    {
        ph.setAmmo(100, 100);
        //shooted = false;
    }

    void ShootGrenade()
    {
        ph.setAmmo(100, 0);
        GameObject grenade = Instantiate(grenadePrefab, transform.TransformPoint(0, 0, -1f), transform.rotation);
        grenade.GetComponent<Rigidbody>().useGravity = true;
        grenade.GetComponent<Rigidbody>().AddForce(-transform.forward * weaponForce, ForceMode.Impulse);
        //destroy grenade if touched enemy, otherwise destroy grenade after specific time
        //Destroy(grenade, 3);
    }
}
