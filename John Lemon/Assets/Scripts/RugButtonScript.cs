using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugButtonScript : MonoBehaviour
{

    public Vector3 m_Movement;
    public GameObject door;
    Rigidbody Rb;

    void Start() {
        Rb = door.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
           
        m_Movement.Set(0f, -400f, 0f);
        Rb.MovePosition (Rb.position + m_Movement);
        
    }

    void OnTriggerExit(Collider other) {

        m_Movement.Set(0f, 400f, 0f);
        Rb.MovePosition (Rb.position + m_Movement);
        
    }
}
