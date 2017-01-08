using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCameraMove : MonoBehaviour {

    public GameObject objToFollow;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(objToFollow.transform.position.x, 20, objToFollow.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(objToFollow.transform.position.x, 10, objToFollow.transform.position.z);
    }
}
