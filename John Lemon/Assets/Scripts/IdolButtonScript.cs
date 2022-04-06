using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolButtonScript : MonoBehaviour
{

    public Vector3 m_Movement;
    public GameObject door;
    Rigidbody Rb;

    void Start() {
        Rb = door.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {

        if(other.GetComponent<Collider>().tag == "Switch") {
            
            m_Movement.Set(0f, -400f, 0f);
            Rb.MovePosition (Rb.position + m_Movement);
        }
        
    }

    void OnTriggerExit(Collider other) {
        
        if(other.GetComponent<Collider>().tag == "Switch") {
            
            m_Movement.Set(0f, 400f, 0f);
            Rb.MovePosition (Rb.position + m_Movement);
        }
    }
}
