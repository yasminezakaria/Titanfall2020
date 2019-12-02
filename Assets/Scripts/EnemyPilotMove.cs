using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPilotMove : MonoBehaviour
{
    int maxHealth = 100;
    int currentHealth = 100;
    public RectTransform healthBar;
    public Animator anim;
    public GameObject playerWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("walking"))
        {
            //float translation = Input.GetAxis("Vertical");
            //float rotation = Input.GetAxis("Horizontal") * 100f;
            //translation += Time.deltaTime;
            //rotation += Time.deltaTime;
            transform.Translate(0, 0, 0.05f);
            //transform.Rotate(0, rotation, 0);
        }
       
    }
    void takeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetBool("hit", true);
        if (currentHealth <= 0)
        {
            anim.SetBool("dead", true);
        }
        healthBar.sizeDelta = new Vector2(currentHealth * 2, healthBar.sizeDelta.y);
    }
}
