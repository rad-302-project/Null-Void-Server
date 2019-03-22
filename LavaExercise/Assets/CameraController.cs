using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Canvas;
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Canvas.SetActive(!Canvas.activeSelf);
        }
	}
}
