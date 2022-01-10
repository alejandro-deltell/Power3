using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSouce;

    public float mainThrust = 100f;
    public float rotationSpeed = 100f;
    public AudioClip mainEngine;

    public bool isAlive = true;
    public bool hasFinished = false;

    public ParticleSystem centralBoost;
    public ParticleSystem leftParticles;
    public ParticleSystem rightParticles;



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

            if (!centralBoost.isPlaying)
            {
                centralBoost.Play();

            }
        }

        else
        {
            audioSouce.Stop();
            centralBoost.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);

            if (!rightParticles.isPlaying)
            {
                rightParticles.Play();
            }

            else if (Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-rotationSpeed);
                if (!leftParticles.isPlaying)
                {
                    leftParticles.Play();
                }
            }

            else
            {
                rightParticles.Stop();
                leftParticles.Stop();
            }
        }

        void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true; // freezing rotation so we can manually rotate
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
        }


    }
}
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        Thrusting();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RightRotation();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            LeftRotation();
        }
        else
        {
            StopRotation();
        }
    }

    void Thrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopTrhusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    void StopTrhusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }



    void RightRotation()
    {
        ApplyRotation(rotationThrust);
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    void LeftRotation()
    {
        ApplyRotation(-rotationThrust);
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    void StopRotation()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
}
