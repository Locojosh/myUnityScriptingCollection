using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRoute : MonoBehaviour
{
    [Header("General")]
    public float velocity; 
    public float disMin; //Distance from objective to go to next point 
    public bool bFollowRouteOrExternal = true; //true: follow route; false: follow external point
    [Header("Route")]
    public Transform[] routePoints;
    private int nCurrentRoutePoint; //Index of routePoints
    [Header("External point")]
    public Transform externalPoint; //Follow only one point rather than a route
    public bool bExternalPointReached; //True when external point has been reached

    //Private
    private Transform currentPoint; //Point currently following
    private bool bStop = false; //Force stop in place

    private void Start() 
    {
        //Set initial currentPoint
        if(!bFollowRouteOrExternal) //Follow external point
        {
            if(externalPoint == null)
                Debug.LogError("ExternalPoint in FollowRoute in " +gameObject.name + " not assigned");
            else
                SetCurrentPoint(externalPoint);
        }    
        else  //Follow route point
        {
            FollowRoutePoint(nCurrentRoutePoint);
        }
    }
    private void Update() 
    {
        if(!bStop && Vector2.Distance(transform.position, currentPoint.position) > disMin)
        {
            //Follow
            Vector2 pos = Vector2.MoveTowards(transform.position, currentPoint.position, velocity * Time.deltaTime);
            transform.position = pos;

            //When following external point, show that it hasn't been reached
            if(!bFollowRouteOrExternal)
                bExternalPointReached = false;
        }    
        else
        {
            if(bFollowRouteOrExternal) //Following route
            {
                //Follow next route point
                nCurrentRoutePoint = (nCurrentRoutePoint + 1) % routePoints.Length;
                SetCurrentPoint(routePoints[nCurrentRoutePoint]);
            }
            else    //Following external point
            {
                //External point has been reached
                bExternalPointReached = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            FollowExternalDirection(Vector2.one, 2f);
        }
    }

    #region MY METHODS
    //PUBLIC

    //Follow point other than route
    public void FollowExternalPoint(Transform value, float stoppingT) //StoppingT: How long to stop in place before following
    {
        //Toggle bool to follow external
        bFollowRouteOrExternal = false;

        //Set external point as current point
        SetCurrentPoint(value);

        //Stop for seconds given in stoppingT and then follow
        PauseFollowing(stoppingT);
    }
    //Follow a direction given, ***NOTE****Continues following undefinitely
    public void FollowExternalDirection(Vector2 direction, float stoppingT)
    {
        //Toggle bool to follow external
        bFollowRouteOrExternal = false;

        //Create object and set it as current point
        GameObject unreachablePoint = new GameObject("UnreachablePoint"); //Create object
        unreachablePoint.transform.SetParent(transform); //Set this as parent
        unreachablePoint.transform.localPosition = direction * 10; //Set pos
        SetCurrentPoint(unreachablePoint.transform);

        //Stop for seconds given in stoppingT and then follow
        PauseFollowing(stoppingT);
    }

    //Follow given route point
    public void FollowRoutePoint(int nRoutePoints)
    {
        //Toggle bool to follow external
        bFollowRouteOrExternal = true;

        //Set given route point
        nCurrentRoutePoint = (nRoutePoints) % routePoints.Length;
        SetCurrentPoint(routePoints[nCurrentRoutePoint]);
    }

    //PRIVATE

    //Sets the currently followed point
    private void SetCurrentPoint(Transform value)
    {
        currentPoint = value;
    }
    //Stop following for given amount of time
    private void PauseFollowing(float nSeconds)
    {
        //Pause
        bStop = true;
        //Unpause
        Invoke("StopForcedStop", nSeconds);
    }
    //Continue (Unpause) following
    private void StopForcedStop()
    {
        bStop = false;
    }
    #endregion
}
