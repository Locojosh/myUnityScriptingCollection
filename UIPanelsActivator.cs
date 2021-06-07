using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelsActivator : MonoBehaviour
{
    public GameObject[] panels; //All UI panels

    #region SINGLETON
    private static UIPanelsActivator instance;
    public static UIPanelsActivator Instance
    {
        get
        {
            if(instance == null)
            Debug.LogError("UIPanelsActivator is NULL");

            return instance; 
        }
    }    
    #endregion

    #region DEFAULT METHODS
    private void Awake() 
    {
        instance = this; //Singleton    
    }
    private void Start() 
    {        
        //Show start panel
        ActivateOnlyThis("CategoriesPanel");
    }
    #endregion

    #region MY METHODS
    //Activates panel given in parameter. Deactivates all others
    public void ActivateOnlyThis(string panel)
    {
        foreach (var p in panels)
        {
            if(p.name == panel)
            {
                p.SetActive(true); //Activate panel
            }
            else
            {
                p.SetActive(false); //Deactivate all other panels
            }
            
        }
    }
    //Activates/Deactivates panel given in parameter. Ignores all others
    public void Activate(string panel, bool value)
    {
        foreach(var p in panels)
        {
            if(p.name == panel)
            {
                p.SetActive(value); //Activate/Deactivate panel
            }
        }
    }
    public void ActivateTrue(string panel)
    {
        foreach(var p in panels)
        {
            if(p.name == panel)
            {
                p.SetActive(true); //Activate/Deactivate panel
            }
        }
    }
    public void ActivateFalse(string panel)
    {
        foreach(var p in panels)
        {
            if(p.name == panel)
            {
                p.SetActive(false); //Activate/Deactivate panel
            }
        }
    }
    //If activated, deactivates. If deactivated, activates. Good for pause panels
    public void ActivateToggle(string panel)
    {
        foreach(var p in panels)
        {
            if(p.name == panel)
            {
                p.SetActive(!p.activeSelf);
            }
        }
    }
    //Deactivates all panels
    public void DeActivateAll()
    {
        foreach(var p in panels)
        {
            p.SetActive(false);
        }
    }
    #endregion
}
