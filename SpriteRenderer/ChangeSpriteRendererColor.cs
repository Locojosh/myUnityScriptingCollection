using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeSpriteRendererColor : MonoBehaviour
{
    SpriteRenderer rend;
    [SerializeField]
    Color defaultCol, lighterCol;
    [Header("Value for decreasing Saturation")]
    public float lighterColSaturationValue = 20f;
    public float tintFactor = 0.5f;

    private void Awake() 
    {
        rend = GetComponent<SpriteRenderer>();
        defaultCol = rend.color; 
        CreateLightCol();
    }

    #region MY METHODS
    //PUBLIC

    //True> Makes color of rend lighter (less saturated HSV).. False> Returns color to default value
    public void ChangeColorToLighter(bool value)
    {
        if(value)
        {
            rend.color = lighterCol;
        }
        else
        {
            rend.color = defaultCol;
        }
    }

    //PRIVATE

    //Creates the ligher version of defaultCol
    private void CreateLightCol()
    {
        /*
        float h, s, v;
        Color.RGBToHSV(defaultCol, out h, out s, out v);
        s = lighterColSaturationValue;
        lighterCol = Color.HSVToRGB(h, s, v,false);
        */

        float r = defaultCol.r + (255 - defaultCol.r) * tintFactor;
        float g = defaultCol.g + (255 - defaultCol.g) * tintFactor;
        float b = defaultCol.b + (255 - defaultCol.b) * tintFactor;
        
        lighterCol = new Color(r, g, b, defaultCol.a);
    }
    #endregion
}
