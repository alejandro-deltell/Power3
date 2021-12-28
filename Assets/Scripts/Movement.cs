using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSouce;
    
    public float mainThrust = 100f;
    public float rotationSpeed = 100f;
    public AudioClip mainEngine;

    public bool isAlive = true;
    public bool hasFinished = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSouce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space) && isAlive)
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            
            if (!audioSouce.isPlaying)
            {
                audioSouce.PlayOneShot(mainEngine);               
            }            
        }

        else if (audioSouce.isPlaying && !hasFinished)
        {
            audioSouce.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotaion(rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotaion(-rotationSpeed);
        }
    }

    void ApplyRotaion(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
