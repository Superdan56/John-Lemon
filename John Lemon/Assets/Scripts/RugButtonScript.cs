using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugButtonScript : MonoBehaviour
{

    public Vector3 m_Movement;
    public GameObject door;
    Rigidbody Rb;

    private int collisionCounter;
    private bool buttonPressed;

    void Start() {
        Rb = door.GetComponent<Rigidbody>();
        collisionCounter = 0;
        buttonPressed = false;
    }

    
    void FixedUpdate() {
        if(collisionCounter >= 1) {
            buttonPressed = true;
        }
        else if(collisionCounter < 1) {
            buttonPressed = false;
        }

        if(buttonPressed) {
            m_Movement.Set(-3.124883f, 400f, 24.0696f);
            Rb.MovePosition (m_Movement);
        }
        else {
            m_Movement.Set(-3.124883f, 0f, 24.0696f);
            Rb.MovePosition (m_Movement);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        collisionCounter += 1;
    }

    void OnTriggerExit(Collider other) {
        collisionCounter -= 1;
    }

}
