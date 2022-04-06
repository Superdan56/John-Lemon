using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugSwitchScript : MonoBehaviour
{

    public Vector3 m_Movement1;
    public Vector3 m_Movement2;
    public GameObject door1;
    public GameObject door2;
    Rigidbody Rb1;
    Rigidbody Rb2;

    private int collisionCounter;
    private bool buttonPressed;

    void Start() {
        Rb1 = door1.GetComponent<Rigidbody>();
        Rb2 = door2.GetComponent<Rigidbody>();
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
            m_Movement1.Set(-5.59f, 400f, 27.11f);
            m_Movement2.Set(-5.59f, 400f, 32.17f);
            Rb1.MovePosition (m_Movement1);
            Rb2.MovePosition (m_Movement2);
        }
        else {
            m_Movement1.Set(-5.59f, 0f, 27.11f);
            m_Movement2.Set(-5.59f, 0f, 32.17f);
            Rb1.MovePosition (m_Movement1);
            Rb2.MovePosition (m_Movement2);
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