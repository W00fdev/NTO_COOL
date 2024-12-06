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
        if (Resources.metal >= MetalPrice
            && Resources.wood >= WoodPrice
            && Resources.honey >= HoneyPrice)
        {
            Resources.ChangeMetalPreview(-MetalPrice);
            Resources.ChangeWoodPreview(-WoodPrice);
            Resources.ChangeHoneyPreview(-HoneyPrice);
            
            Grid.StartPlacingBuilding(Prefab);
        }
    }
}
