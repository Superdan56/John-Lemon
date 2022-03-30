using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision_Script : MonoBehaviour
{
    bool seePlayer;

    void Start() {
        seePlayer = false;
    }

    void Update() {
        if (seePlayer) {
            
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            
        }
    }
}
