using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ifstaement1 : MonoBehaviour
    {

    public int speed;
    public bool hasStarted = false;

    void Start()
        {
        Debug.Log("Speed is " + speed);
        }
    

    void Update()
        {
        MoveSpeed();
        }

    void MoveSpeed()
        {
        if (Input.GetKeyDown(KeyCode.A))
            {
            speed += 5;
            Debug.Log("Speed is " + speed);
            hasStarted = true;
            }
        else if (Input.GetKeyDown(KeyCode.S) && speed > 0)
            {
            speed -= 5;
            Debug.Log("Speed is " + speed);
            hasStarted = true;
            }


        if (speed > 20 && hasStarted == true)
            {
            Debug.Log("Slow down");
            hasStarted = false;
            }
        else if (speed == 0 && hasStarted == true)
            {
            Debug.Log("Speed up!");
            hasStarted = false;
            }
        }
    }
    


