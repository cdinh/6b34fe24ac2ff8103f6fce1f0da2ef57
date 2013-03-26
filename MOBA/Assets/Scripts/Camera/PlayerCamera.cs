using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public GameObject toFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = toFollow.transform.position - toFollow.transform.forward * toFollow.transform.renderer.bounds.size.x;
        gameObject.transform.position += new Vector3(0, toFollow.transform.renderer.bounds.size.y, 0);
        gameObject.transform.forward = toFollow.transform.forward;
	}
}
