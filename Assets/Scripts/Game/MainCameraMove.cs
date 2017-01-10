using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour {
    public Transform[] views;
    public GameObject player;
    public float speed;

    private float rotationSpeed = 0;
    private bool playerChanged = true;
    private int nextView = 0;
	// Use this for initialization
	void Start () {
        transform.position = views[0].position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position != views[nextView].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, views[nextView].position, speed * Time.deltaTime);
        }
            
        if(transform.rotation != views[nextView].rotation)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, views[nextView].rotation, rotationSpeed * Time.deltaTime);
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
            float distNextPoint = Mathf.Sqrt(Mathf.Pow(views[nextView].transform.position.x - transform.position.x, 2) +
                                        Mathf.Pow(views[nextView].transform.position.y - transform.position.y, 2) +
                                        Mathf.Pow(views[nextView].transform.position.z - transform.position.z, 2));
            float difRotation = Mathf.Abs(views[nextView].transform.eulerAngles.y - transform.eulerAngles.y);
            if(transform.eulerAngles.y > views[nextView].transform.eulerAngles.y)
                difRotation = 360 - Mathf.Abs(views[nextView].transform.eulerAngles.y - transform.eulerAngles.y);
            rotationSpeed = speed * ((difRotation * Time.deltaTime) / (distNextPoint * Time.deltaTime));
        }
    }
}
