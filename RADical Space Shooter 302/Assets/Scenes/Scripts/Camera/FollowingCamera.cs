using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {

    public GameObject followee;

    private Vector3 offset;

	void Start () {
        offset = transform.position - followee.transform.position;
	}
		
	void LateUpdate () {
        transform.position = followee.transform.position + offset;
	}
}