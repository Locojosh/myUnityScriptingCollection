using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_TriggerByObjectDistance : MonoBehaviour
{
    public Transform objective; //Used for calculations

    public bool ObjectiveIsHigherOrLower() //Returns: true>higher, false>lower
    {
        if(objective.position.y > transform.position.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ObjectiveIsRightOrLeft() //Returns: true>right, false>left
    {
        if(objective.position.x > transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
