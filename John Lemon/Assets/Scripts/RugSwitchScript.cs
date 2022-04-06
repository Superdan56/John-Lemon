using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugSwitchScript : MonoBehaviour
{
    public Vector3 m_Movement;
    public GameObject door1;
    public GameObject door2;
    Rigidbody Rb1;
    Rigidbody Rb2;

    void Start() {
        Rb1 = door1.GetComponent<Rigidbody>();
        Rb1 = door1.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
           
        m_Movement.Set(0f, -400f, 0f);
        Rb1.MovePosition (Rb1.position + m_Movement);
        Rb2.MovePosition (Rb2.position + m_Movement);
        
    }

    void OnTriggerExit(Collider other) {

        m_Movement.Set(0f, 400f, 0f);
        Rb1.MovePosition (Rb1.position + m_Movement);
        Rb2.MovePosition (Rb2.position + m_Movement);
        
    }


}
