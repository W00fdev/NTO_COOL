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
    public int bears;
    
    public TMP_Text metalText;
    public TMP_Text woodText; 
    public TMP_Text honeyText;
    public TMP_Text bearsText;
    
    public TMP_Text bearsAtFlagText;
    
    private int metalPreview;
    private int woodPreview;
    private int honeyPreview;
    private int bearsPreview;
    
    private void Start()
    {
        CancelPreview();
    }

    private void UpdateText()
    {
        metalText.text = metalPreview.ToString();
        woodText.text = woodPreview.ToString();
        honeyText.text = honeyPreview.ToString();
        bearsText.text = bearsPreview.ToString();
    }

    public void AddBear()
    {
        bearsPreview += 1;
        bears += 1;

        bearsAtFlagText.text = $"{bearsPreview} / {ProductionController._maxFlagCount}";
        bearsText.text = bearsPreview.ToString();
    }

    public void RemoveBear()
    {
        bearsPreview -= 1;
        bears -= 1;
        bearsAtFlagText.text = $"{bearsPreview} / {ProductionController._maxFlagCount}";
        bearsText.text = bearsPreview.ToString();
    }

    public void ApplyPreview()
    {
        metal = metalPreview;
        wood = woodPreview;
        honey = honeyPreview;
        bears = bearsPreview;
    }

    public void CancelPreview()
    {
        metalPreview = metal;
        woodPreview = wood;
        honeyPreview = honey;
        bearsPreview = bears;

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
    
    public void ChangeBearsPreview(int delta)
    {
        //bearsPreview += delta;
        //UpdateText();
    }
}
