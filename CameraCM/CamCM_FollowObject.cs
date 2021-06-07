using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CamCM_FollowObject : MonoBehaviour
{
    #region SINGLETON
    //Turn this class into a Singleton
    private static CamCM_FollowObject instance;
    public static CamCM_FollowObject Instance
    {
        get
        {
            if(instance == null)
            Debug.LogError("CamCM_FollowObject is NULL");

            return instance; 
        }
    } 
    #endregion
    public Transform[] objects; //List of objects camera can follow
    CinemachineVirtualCamera cam; //This camera

    private void Awake() 
    {
        instance = this; //Singleton
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update() {
        if(Input.GetKey(KeyCode.V))
            FollowObject(1);
        if(Input.GetKey(KeyCode.B))
            FollowObject(2);
    }
    public void FollowObject(int nObject)
    {
        cam.Follow = objects[nObject - 1];
    }
}
