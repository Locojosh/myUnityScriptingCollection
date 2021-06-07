using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCM_TriggerFollowChange : MonoBehaviour
{
    [Header("Whether to check horizontal or vertical change")]
    public bool checkVertical, checkHorizontal; 
    [Header("Previous and next room")]
    public int nPrevious, nNext; //Used in CamCM_FollowObject.. tells which object to follow
    [Header("Scripts Referenced")]
    public AI_TriggerByObjectDistance sDisTrigger; //Handles the dis dif calculation
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(checkVertical) //If vertical rooms
                if(sDisTrigger.ObjectiveIsHigherOrLower())
                    CamCM_FollowObject.Instance.FollowObject(nNext);
                else
                    CamCM_FollowObject.Instance.FollowObject(nPrevious);
            
            if(checkHorizontal) //If horizontal rooms
                if(sDisTrigger.ObjectiveIsRightOrLeft())
                    CamCM_FollowObject.Instance.FollowObject(nNext);
                else
                    CamCM_FollowObject.Instance.FollowObject(nPrevious);
        }    
    }
}
