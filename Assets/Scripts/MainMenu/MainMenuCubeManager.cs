using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCubeManager : MonoBehaviour {

    public float initSpeed;
    public Vector3 RotateAmount;
    public ParticleSystem deathParticles;

    private float maxSpeed = 5f;
    private Vector3 input;
    private Rigidbody rbody;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateAmount * Time.deltaTime);
        input = new Vector3(0, 0, Input.GetAxis("Vertical"));
        if (rbody.velocity.magnitude < maxSpeed && rbody.velocity.magnitude >= initSpeed)
            rbody.AddRelativeForce(-1 * input * initSpeed);
        else
            rbody.AddRelativeForce(new Vector3(0,0,0.1f) * initSpeed);

        if (transform.position.y < -5)
            destroyCube();
    }

    private void OnCollisionEnter(Collision collision)
    {
        destroyCube();
    }

    private void destroyCube()
    {
        Instantiate(deathParticles, transform.position, Quaternion.Euler(270, 0, 0));
        Destroy(gameObject);
    }
}

