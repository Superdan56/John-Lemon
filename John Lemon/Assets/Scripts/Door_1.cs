using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_1 : MonoBehaviour
{
    public Vector3 m_Movement;
    Rigidbody m_Rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Switch") {
            
            m_Movement.Set(0f, 100f, 0f);
            m_Movement.Normalize ();
            m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement);
        }
        
    }
}