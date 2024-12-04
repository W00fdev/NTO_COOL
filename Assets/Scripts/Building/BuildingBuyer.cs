using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingBuyer : MonoBehaviour
{
    public int MetalPrice;
    public int WoodPrice;
    public int HoneyPrice;

    public ResourcesScript Resources;
    public Building Prefab;
    public BuildingsGrid Grid;
    
    public void BuyAndPlace()
    {
        if (Resources.metall >= MetalPrice
            && Resources.wood >= WoodPrice
            && Resources.honey >= HoneyPrice)
        {
            Resources.ChangeMetal(-MetalPrice);
            Resources.ChangeWood(-WoodPrice);
            Resources.ChangeHoney(-HoneyPrice);
            
            Grid.StartPlacingBuilding(Prefab);
        }
    }
}
