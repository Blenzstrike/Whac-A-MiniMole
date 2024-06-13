using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZaggingMoleObjectController : MoleObjectController
{
    private bool goingRight = true;
    private float switched = 0;
    protected override void MoveObject()
    {
        base.MoveObject();
        if(elapsedTime > (LiveTimerInSeconds / 6)+switched) 
        { 
            goingRight = !goingRight; 
            switched = elapsedTime; 
        }

        if (goingRight)
        {
            transform.position += new Vector3(movementSpeed*3, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(movementSpeed*3, 0, 0);
        }

    }
}
