using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carpet_button : MonoBehaviour
{

    private int collisionCounter;
    private bool buttonPressed;
    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        collisionCounter = 0;
        buttonPressed = false;
        m_AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        if(collisionCounter >= 1) {
            buttonPressed = true;
        }
        else if(collisionCounter < 1) {
            buttonPressed = false;
        }

        if(buttonPressed) {
            if (!m_AudioSource.isPlaying) {
                m_AudioSource.Play();
            }
        }
        else {
            m_AudioSource.Stop();
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
