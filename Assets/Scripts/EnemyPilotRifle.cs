﻿using UnityEngine;
using System.Collections;

public class EnemyPilotRifle : MonoBehaviour
{
    const int rifleRange = 65000;
    public ParticleSystem muzzleFlash;
    public PilotHealth ph;
    bool routineFinished = true;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (routineFinished && this.gameObject.GetComponent<Animator>().GetBool("fire"))
        //{
        //    this.gameObject.GetComponent<Animator>().SetBool("fire", false);
        //}
        if (playerInScope() && routineFinished)
        {
            this.gameObject.GetComponent<Animator>().SetBool("fire", true);
            //attack();
            transform.LookAt(GameObject.FindGameObjectsWithTag("player")[0].transform);
            muzzleFlash.Play();
            ph.setHealth(ph.GetHealth() - 10);
            StartCoroutine(attack());
        }

    }
    bool playerInScope()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("player");
        float diff = (player[0].transform.position - gameObject.transform.position).sqrMagnitude;
        return (diff <= rifleRange);
    }
    IEnumerator attack()
    {
        routineFinished = false;
        //Debug.Log(this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Gunplay"));
        yield return new WaitForSeconds(this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        this.gameObject.GetComponent<Animator>().SetBool("fire", false);
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(10);
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        routineFinished = true;
    }
}
