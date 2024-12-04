using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ResourcesScript : MonoBehaviour
{
    public int metall;
    public int wood;
    public int honey;
    
    public TMP_Text metalText;
    public TMP_Text woodText; 
    public TMP_Text honeyText;

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        metalText.text = metall.ToString();
        woodText.text = wood.ToString();
        honeyText.text = honey.ToString();
    }

    public void ChangeMetal(int delta)
    {
        metall += delta;
        UpdateText();
    }

    public void ChangeWood(int delta)
    {
        wood += delta;
        UpdateText();
    }

    public void ChangeHoney(int delta)
    {
        honey += delta;
        UpdateText();
    }

}
