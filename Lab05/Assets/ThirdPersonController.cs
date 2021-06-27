using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float verticalVelocity = 0.0f;
    float y = 0.0f;
    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, 5.0f*rotation,0);
        float updown = Input.GetAxis("Mouse Y");
        if (y + updown > 50 || y + updown <0)
        {
            updown = 0;
        }
        y += updown;
        Camera.main.transform.RotateAround(transform.position, transform.right,updown);
        Camera.main.transform.LookAt(transform);
        float forwardSpeed = Input.GetAxis("Vertical") * 5.0f;
        float lateralSpeed = Input.GetAxis("Horizontal") * 5.0f;
        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        CharacterController characterController = GetComponent<CharacterController>();

        if(Input.GetButton("Jump")&& characterController.isGrounded)
        {
            verticalVelocity = 5.0f;
        }
        Vector3 speed = new Vector3(lateralSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime); 
    }
}
