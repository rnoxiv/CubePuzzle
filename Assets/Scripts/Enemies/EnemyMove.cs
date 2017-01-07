using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed = 20f;
    public Transform[] path;

    private int nextPoint = 1;
	// Use this for initialization
	void Start () {
        transform.position = path[0].position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position == path[nextPoint].position)
        {
            nextPoint++;
            if (nextPoint >= path.Length)
                nextPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, path[nextPoint].position, speed * Time.deltaTime);            
	}
}
