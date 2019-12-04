using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    private CharacterController cc;
    private bool m_Crouch=false;
    private float original_height;
    private float crouched_height = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        original_height = cc.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_Crouch = !m_Crouch;
            checkCrouching();
        }
        if(m_Crouch && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Sprinting and crouching");
            m_Crouch = false;
            checkCrouching();
        }
        
    }


    void checkCrouching()
    {
        if (!m_Crouch)
        {
          cc.height = original_height;
        }
        else
        {
          cc.height = crouched_height;  
        }
    }
}
