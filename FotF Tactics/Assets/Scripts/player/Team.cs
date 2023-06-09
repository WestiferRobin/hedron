using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public GameObject teamMemberPrefab;
    public List<GameObject> teamMembers;
    private Ship ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("ShipBoard").GetComponent<Ship>();
        teamMembers = new List<GameObject>();
        var floorObject = ship.Floors;
        Debug.Log(floorObject.Count);
        InitializeTeam();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeTeam()
    {
        // Check the ship's class and initialize the team accordingly
        switch (ship.shipClass)
        {
            case ShipClass.Kestrel:
                InitializeKestrelTeam();
                break;
            case ShipClass.Federation:
                // InitializeFederationTeam();
                break;
            case ShipClass.Slug:
                // InitializeSlugTeam();
                break;
            case ShipClass.Mantis:
                // InitializeMantisTeam();
                break;
            case ShipClass.Engi:
                // InitializeEngiTeam();
                break;
            case ShipClass.Zoltan:
                // InitializeZoltanTeam();
                break;
            case ShipClass.Stealth:
                // InitializeStealthTeam();
                break;
            case ShipClass.Rock:
                // InitializeRockTeam();
                break;
            default:
                Debug.Log("Unknown ship class, cannot initialize team.");
                break;
        }
    }

    private void InitializeKestrelTeam()
    {
        // var floorObject = ship.GetFloors();
        // Debug.Log(floorObject.Count);
        int gridSize = 3; // Adjust the grid size as needed

        // if (floorObject != null)
        // {
        //     // Get the bounds of the floor object
        //     Bounds floorBounds = floorObject.GetComponent<Renderer>().bounds;

        //     // Calculate the size of each tile based on the floor size and grid size
        //     float tileSize = floorBounds.size.x / gridSize;

        //     // Iterate over the grid positions and instantiate the team members
        //     for (int row = 0; row < gridSize; row++)
        //     {
        //         for (int col = 0; col < gridSize; col++)
        //         {
        //             // Calculate the position of the current tile within the room
        //             Vector3 tilePosition = floorBounds.min + new Vector3((col + 0.5f) * tileSize, (row + 0.5f) * tileSize, 0f);

        //             // Instantiate the team member at the tile position
        //             GameObject teamMember = Instantiate(teamMemberPrefab, tilePosition, Quaternion.identity);
        //             teamMembers.Add(teamMember);
        //         }
        //     }
        // }
        // else
        // {
        //     Debug.Log("Floor object not found. Cannot initialize team.");
        // }
    }
}
