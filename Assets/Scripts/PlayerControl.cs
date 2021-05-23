using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 4f;
    public float jumpSpeed = 8f;
    public float gravity = 25f;
    public float sprintSpeed = 2f;

    bool isSprint = false;

    Vector3 moveDir = Vector3.zero;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= playerSpeed;
        }    

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded && isSprint == false)
        {
            moveDir.y = jumpSpeed;
        }

        if (Input.GetKey("left shift") && controller.isGrounded) { isSprint = true; moveDir *= sprintSpeed; }
        else isSprint = false;

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);




    }
}
