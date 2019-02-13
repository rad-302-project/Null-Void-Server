using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed;
    public Text overallScoreDisplay;
    public Transform respawnLocation;

    Rigidbody2D playerBody;
    //Animator animator;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleAnimations();
    }

    void HandleMovement()
    {

        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            // Vector3.Forward is what we'll use here.
        }

        // Rotate Left
        if (Input.GetKey(KeyCode.A))
        {

        }

        // Rotate Right
        else if (Input.GetKey(KeyCode.D))
        {

        }
    }

    void HandleAnimations()
    {
        //animator.SetBool("Moving", moving); May or may not see use for this project. 
    }
}