using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    // photon related var here
    private PhotonView PV;


    void Start()
    {
        // photon code here
        PV = GetComponent<PhotonView>();
    }
    void Update()
    {
        // photon code here
        if(PV.IsMine) // Does the current player belong to this specific instance of the player object?
        Movement();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void Movement()
    {
        float yMov = Input.GetAxis("Vertical");
        float xMov = Input.GetAxis("Horizontal");
        transform.position += new Vector3(xMov / 7.5f, yMov / 7.5f, 0);
    }
}
