using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public Transform spawnPosition;
    public ParticleSystem deathParticles;

    private float maxSpeed = 5f;
    private Vector3 input;
    private Rigidbody rbody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        transform.position = spawnPosition.position;
	}
	
	// Update is called once per frame
	void Update () {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if(rbody.velocity.magnitude < maxSpeed)
            rbody.AddForce(input * moveSpeed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Goal"))
            transform.position = spawnPosition.position;
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            transform.position = spawnPosition.position;
        }
            

    }
}
