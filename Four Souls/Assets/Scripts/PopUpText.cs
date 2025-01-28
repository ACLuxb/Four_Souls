using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;


public class PopUpText : MonoBehaviour
{
    public GameObject starttextcanvas;
    public TMP_Text starttext;

    public GameObject chrystaltext;
    public TMP_Text notenoughchrystals;

    public static event Action EnoughChrystals;

    public void CloseStartText() 
    {
        
        starttextcanvas.SetActive(false);

       
    }
}
