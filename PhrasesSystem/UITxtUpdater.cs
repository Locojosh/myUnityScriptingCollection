using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITxtUpdater : MonoBehaviour
{
    public TextMeshProUGUI txt;

    public void UpdateUI(string value)
    {
        txt.text = value;
    }
}
