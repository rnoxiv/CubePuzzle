using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public float delay;
    public float start;

    private Animation anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animation>();
        StartCoroutine(Go());
	}

    IEnumerator Go()
    {
        yield return new WaitForSeconds(start);
        while (true)
        {
            anim.Play();
            yield return new WaitForSeconds(delay);
        }
    }

}
