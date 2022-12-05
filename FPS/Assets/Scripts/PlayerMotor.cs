using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour
{

    //optional
    [SerializeField]
    private Camera cam;
    //

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;
    // Start is called before the first frame update

    //Multiplayer test
    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //M test
        view = GetComponent<PhotonView>();

    }
    public void Rotate(Vector3 rot)
    {
        rotation = rot;
    }

    public void Move (Vector3 velo)
    {
        velocity = velo;
    }

    public void RotateCamera (Vector3 camr)
    {
        cameraRotation = camr;
    }


    // Update is called once per frame
    void Update()
    {
        //M test
        if (view.IsMine)
        {
            PerformMovement();
            PerformRotation();
        }
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
