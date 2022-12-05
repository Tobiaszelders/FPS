using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    //Multiplayer test
    //PhotonView view;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();

        //M test
        //view = GetComponent<PhotonView>();
    }

    void Update()
    {
        //If statement for multiplayer
        //if (view.IsMine)
        //{
            //Calculate movement velocity as a 3D vector
            float xMovement = Input.GetAxisRaw("Horizontal");
            float zMovement = Input.GetAxisRaw("Vertical");

            Vector3 moveHorizontal = transform.right * xMovement;
            Vector3 moveVertical = transform.forward * zMovement;

            // Movement result (in 1's)
            Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

            // Apply movement
            motor.Move(velocity);


            float yRotation = Input.GetAxisRaw("Mouse X");

            Vector3 rotation = new Vector3(0f, yRotation, 0f) * lookSensitivity;

            //Apply rotation
            motor.Rotate(rotation);



            float xRotation = Input.GetAxisRaw("Mouse Y");

            Vector3 cameraRotation = new Vector3(xRotation, 0f, 0f) * lookSensitivity;

            //Apply rotation
            motor.RotateCamera(cameraRotation);
        //}
    }
}
