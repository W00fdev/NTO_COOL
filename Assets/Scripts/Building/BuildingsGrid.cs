using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);
    private Building[,] grid;
    private Building flyingBuilding;
    private Camera mainCamera;
    private Plane groundPlane;

    public ResourcesScript Resources;

    public Building StartFlagBuilding;
    
    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];
        mainCamera = Camera.main;
        
        groundPlane = new Plane(Vector3.up, transform.position);
    }

    private void Start()
    {
        int placeX = 47;
        int placeY = 37;
        for (int x = 0; x < StartFlagBuilding.Size.x; x++)
        {
            for (int y = 0; y < StartFlagBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = StartFlagBuilding;
            }
        }
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (flyingBuilding == null) 
            flyingBuilding = Instantiate(buildingPrefab);
        
        flyingBuilding.DrawAvailability(Availability.Available);
    }

    private void Update()
    {
        if (flyingBuilding)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);
                
                bool available = !(x < 0 || y < 0 
                                         || x > GridSize.x - flyingBuilding.Size.x
                                         || y > GridSize.y - flyingBuilding.Size.y);

                
                if (available && IsPlaceTaken(x, y)) available = false;

                flyingBuilding.transform.position = new Vector3(x, transform.position.y, y);

                Availability type = (available) 
                    ? Availability.Available 
                    : Availability.NotAvailable;
                
                flyingBuilding.DrawAvailability(type);
                
                if (available && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(x, y);
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    Delete();
                }
            }
        }
    }


    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = flyingBuilding;
            }
        }
        
        flyingBuilding.DrawAvailability(Availability.NotChosen);
        flyingBuilding.Build();
        flyingBuilding = null;
        
        Debug.Log(placeX + " " + placeY);
        Resources.ApplyPreview();
        
    }

    /*public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundPlane.ClosestPointOnPlane(transform.position), 0.5f);
    }*/

    public void Delete()
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }
        
        Resources.CancelPreview();
    }
}
