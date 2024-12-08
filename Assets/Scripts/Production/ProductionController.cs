using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ProductionType
{
    Sawmill = 0,
    Stonemill,
    Paseka,
}

public class ProductionController : MonoBehaviour
{
    public GetPointForAgent Ambar;
    public GetPointForAgent Sawmill;
    public GetPointForAgent Stonemill;
    public GetPointForAgent Paseka;

    public GetRandomPointForAgent Flag;

    public ResourcesScript Resources;
    
    public int BearsAtFlag;


    [SerializeField] private TMP_Text _atPasekaText;
    [SerializeField] private TMP_Text _atStonemillText;
    [SerializeField] private TMP_Text _atSawmillText;
    
    private int _pasekaBearsCount;
    private int _sawmillBearsCount;
    private int _stonemillBearsCount;

    private List<BearAgent> _bearsAtFlag = new();
    
    private const int _maxWorkersCount = 6;
    public const int _maxFlagCount = 40;
    
    public void BearSpawned(BearAgent agent)
    {
        agent.Initialize(Flag, Ambar);
        agent.GoToFlag();
    }

    public void BearAtFlag(BearAgent agent)
    {
        Resources.AddBear();
        _bearsAtFlag.Add(agent);
    }

    public void SendBearTo(int intType)
    {
        var type = (ProductionType)intType;
        
        if (_bearsAtFlag.Count == 0)
            return;

        if (type == ProductionType.Paseka && _pasekaBearsCount >= _maxWorkersCount)
            return;
        
        if (type == ProductionType.Stonemill && _stonemillBearsCount >= _maxWorkersCount)
            return;

        if (type == ProductionType.Sawmill && _sawmillBearsCount >= _maxWorkersCount)
            return;
        
        var bear = _bearsAtFlag[0];
        _bearsAtFlag.Remove(bear);
        
        Resources.RemoveBear();
        
        switch (type)
        {
            case ProductionType.Sawmill:
                bear.SetWorkPlace(Sawmill);
                _sawmillBearsCount++;
                _atSawmillText.text = $"{_sawmillBearsCount} / {_maxWorkersCount}";
                break;
            case ProductionType.Stonemill:
                bear.SetWorkPlace(Stonemill);
                _stonemillBearsCount++;
                _atStonemillText.text = $"{_stonemillBearsCount} / {_maxWorkersCount}";
                break;
            case ProductionType.Paseka:
                bear.SetWorkPlace(Paseka);
                _pasekaBearsCount++;
                _atPasekaText.text = $"{_pasekaBearsCount} / {_maxWorkersCount}";
                break;
        }
        
        bear.ToWork();
    }
}
