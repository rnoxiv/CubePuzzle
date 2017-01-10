using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Transform spawnPosition;
    public ParticleSystem deathParticles;
    public ParticleSystem deathParticlesEnemies;
    public Camera cam;

    private float maxSpeed = 5f;
    private bool finishedLevel = false;
    private float finishedTime;
    private Vector3 input;
    private Rigidbody rbody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        transform.position = spawnPosition.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (finishedLevel)
        {
            if (Time.time >= finishedTime + 2)
            {
                GameManager.CompletedLevel();
            }
        }else
        {
            if (transform.position.y < 0.51 && Time.timeScale == 1)
            {
                input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                if (rbody.velocity.magnitude < maxSpeed)
                    rbody.AddRelativeForce(input * moveSpeed);
                if (transform.position.y < -5)
                    Die();
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
            Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Goal")
            GoalReached();
        else if (other.transform.tag == "Enemy")
            Die();
    }

    private void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.Euler(270,0,0));
        transform.position = spawnPosition.position;
        rbody.velocity = Vector3.zero;
    }

    private void GoalReached(){
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
         for (int i = 0; i<gos.Length; i++) {
            Instantiate(deathParticlesEnemies, gos[i].transform.position, Quaternion.Euler(270, 0, 0));
            Destroy(gos[i]);
         }
        finishedLevel = true;
        finishedTime = Time.time;
    }
}
