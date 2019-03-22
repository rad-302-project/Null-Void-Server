using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UvScroller : MonoBehaviour {

    public float MapOneSpeed = 90f;
    public float MapTwoSpeed = 90f;

    public Vector2 MapOneDirection = new Vector2(1, 0);
    public Vector2 MapTwoDirection = new Vector2(-1, 0);

    MeshRenderer mesh;
    Vector2 existingSecondOffset;
	void Start ()
    {
        mesh = GetComponent<MeshRenderer>();
	}
	

	void Update ()
    {
        mesh.material.mainTextureOffset += MapOneSpeed * MapOneDirection * Time.deltaTime;

        existingSecondOffset = mesh.material.GetTextureOffset("_DetailAlbedoMap");
        existingSecondOffset += MapTwoSpeed * MapTwoDirection * Time.deltaTime;
        mesh.material.SetTextureOffset("_DetailAlbedoMap", existingSecondOffset);
	}
}
