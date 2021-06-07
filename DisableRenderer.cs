using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DisableRenderer : MonoBehaviour
{
    Renderer rend;
    private void Awake() 
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
}
