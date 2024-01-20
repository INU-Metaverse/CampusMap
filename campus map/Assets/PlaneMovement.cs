using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        float MovingDirection = Mathf.Atan2(VerticalInput, HorizontalInput) * Mathf.Rad2Deg;
        

        float Direction = transform.rotation.eulerAngles.y;
        int keyPressed = HorizontalInput != 0 || VerticalInput != 0 ? 1 : 0;
        float speed = 5f;

        float FrontDir = (-Direction + MovingDirection) * Mathf.Deg2Rad;
        Vector3 FrontVec = new Vector3(Mathf.Cos(FrontDir) * speed * keyPressed, 0, Mathf.Sin(FrontDir) * speed * keyPressed);
        rigid.velocity = FrontVec;

        float MouseX = Input.GetAxis("Mouse X");
        //if(MouseX >= 45)
        //{
        //    MouseX = 45;
        //}

        float MouseY = Input.GetAxis("Mouse Y");

        Debug.Log(transform.rotation.eulerAngles.x - MouseY);
        float NextX = transform.rotation.eulerAngles.x - MouseY;
        // 0~90, 270~360
        if (90 <= NextX && NextX <= 270)
        {
            if (NextX <= 180)
            {
                NextX = 90;
            }
            else
            {
                NextX = 270;
            }
        }

        transform.rotation = Quaternion.Euler(NextX, transform.rotation.eulerAngles.y + MouseX, 0);
    }

    //public Vector getDirection()
    //{
    //    Vector vector = new Vector();

    //    double rotX = this.getYaw();
    //    double rotY = this.getPitch();

    //    vector.setY(-Math.sin(Math.toRadians(rotY)));

    //    double xz = Math.cos(Math.toRadians(rotY));

    //    vector.setX(-xz * Math.sin(Math.toRadians(rotX)));
    //    vector.setZ(xz * Math.cos(Math.toRadians(rotX)));

    //    return vector;
    //}
}
