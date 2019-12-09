using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public float weaponForce;
    public PilotHealth ph;
    private bool shooted=false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ph.setAmmo(100, 100);
            shooted = false;
        }

        if (Input.GetMouseButtonDown(0)&&shooted==false)
        {
            ShootRocket();
            shooted = true;
        }
    }
    public void setAmmo()
    {
        ph.setAmmo(100, 100);
        shooted = false;
    }
    void ShootRocket()
    {
		ph.setAmmo(100, 0);
		GameObject rocket = Instantiate(rocketPrefab, transform.TransformPoint(0, 0, -1f), transform.rotation);
		rocket.GetComponent<Rigidbody>().useGravity = false;
        rocket.GetComponent<Rigidbody>().AddForce(-transform.forward * weaponForce, ForceMode.Impulse);
        //destroy grenade if touched enemy, otherwise destroy grenade after specific time
        Destroy(rocket, 3);
    }

}
