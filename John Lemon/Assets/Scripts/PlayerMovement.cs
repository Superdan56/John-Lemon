using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour {
    public TextMeshProUGUI countText; 
    public Vector3 m_Movement;
    public Animator m_Animator;
    public float turnSpeed = 20f;
    Quaternion m_Rotation = Quaternion.identity;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    
    private bool detected;
    private int detectCounter;

    // Start is called before the first frame update
    void Start() {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource>();

        detected = false;
        detectCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

        if (isWalking) {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else {
            m_AudioSource.Stop ();
        }

        if (detected) {
            detectCounter += 1;
            SetCountText();
        }

    }

    void OnAnimatorMove () {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }

    void OnTriggerEnter(Collider Other) {
        
        if(Other.GetComponent<Collider>().tag == "Switch") {
            detected = true;
        }
    }

    void SetCountText() {
        countText.text = "Detection: " + detectCounter.ToString();
    }
}
