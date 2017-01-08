using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour {
    public Transform[] views;
    public GameObject player;
    public float speed;

    private bool playerChanged = false;
    private int nextView = 0;
	// Use this for initialization
	void Start () {
        transform.position = views[0].position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position != views[nextView].position)
            transform.position = Vector3.MoveTowards(transform.position, views[nextView].position, speed * Time.deltaTime);
        if(transform.rotation != views[nextView].rotation)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, views[nextView].rotation, 4 * speed * Time.deltaTime);
        if (!playerChanged)
        {
            player.transform.rotation = Quaternion.Euler(0, nextView*90, 0);
            playerChanged = true;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            nextView++;
            playerChanged = false;
            if (nextView >= views.Length)
                nextView = 0;
        }
    }
}
