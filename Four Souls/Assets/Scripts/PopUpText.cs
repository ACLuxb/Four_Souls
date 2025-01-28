using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.InputSystem;


public class PopUpText : MonoBehaviour
{
    public GameObject starttextcanvas;
    public TMP_Text starttext;

    public GameObject crystaltext;
    public TMP_Text notenoughchrystals;

    public static Action NotEnoughCrystals;

    public void CloseStartText() 
    {   
        starttextcanvas.SetActive(false);
    }

    public void OnEnable()
    {
        NotEnoughCrystals += EnableCrystaltext;
    }

    public void OnDisable()
    {
        NotEnoughCrystals -= EnableCrystaltext;
    }

    public void EnableCrystaltext()
    { 
        crystaltext.SetActive(true); 
    }


    public void CloseCrystalText()
    {
        crystaltext.SetActive(false);
        OnDisable();
    }
}
