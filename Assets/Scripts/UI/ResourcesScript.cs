using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ResourcesScript : MonoBehaviour
{
    public int metal;
    public int wood;
    public int honey;
    
    public TMP_Text metalText;
    public TMP_Text woodText; 
    public TMP_Text honeyText;

    private int metalPreview;
    private int woodPreview;
    private int honeyPreview;
    
    private void Start()
    {
        CancelPreview();
    }

    private void UpdateText()
    {
        metalText.text = metalPreview.ToString();
        woodText.text = woodPreview.ToString();
        honeyText.text = honeyPreview.ToString();
    }

    public void ApplyPreview()
    {
        metal = metalPreview;
        wood = woodPreview;
        honey = honeyPreview;
    }

    public void CancelPreview()
    {
        metalPreview = metal;
        woodPreview = wood;
        honeyPreview = honey;

        UpdateText();
    }
    
    public void ChangeMetalPreview(int delta)
    {
        metalPreview += delta;
        UpdateText();
    }

    public void ChangeWoodPreview(int delta)
    {
        woodPreview += delta;
        UpdateText();
    }

    public void ChangeHoneyPreview(int delta)
    {
        honeyPreview += delta;
        UpdateText();
    }

}
