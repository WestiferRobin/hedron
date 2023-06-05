using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ship : MonoBehaviour
{
    enum ShipClass
    {
        Unknown = -1,
        Kestrel = 0,
        Federation = 1,
        Slug = 2,
        Mantis = 3,
        Engi = 4,
        Zoltan = 5,
        Stealth = 6,
        Rock = 7,
    }
    
    public int shipClassId = 0;
    private ShipClass shipClass = ShipClass.Unknown;
    private int floorCount = 0;
    private int hallwayCount = 0;
    private int roomCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch (shipClassId) {
            case 0: 
                shipClass = ShipClass.Kestrel;
                break;
            case 1: 
                shipClass = ShipClass.Federation;
                break;
            case 2: 
                shipClass = ShipClass.Slug;
                break;
            case 3: 
                shipClass = ShipClass.Mantis;
                break;
            case 4: 
                shipClass = ShipClass.Engi;
                break;
            case 5: 
                shipClass = ShipClass.Zoltan;
                break;
            case 6: 
                shipClass = ShipClass.Stealth;
                break;
            case 7: 
                shipClass = ShipClass.Rock;
                break;
            default: 
                shipClass = ShipClass.Unknown;
                break;
        }
        BuildShip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildShip() {
        // configure what ship to build
        // render the rooms
        // layout the rooms
        // apply systems and memebers
        // then create shell
        int hallwayAmmount; 
        int roomAmmount;
        int doorAmmount;
        int wallAmmount;
        switch (shipClass) {
            // Atlantians
            case ShipClass.Kestrel:
                hallwayAmmount = 1; //10; 
                roomAmmount = 1; //7;
                wallAmmount = 9;
                doorAmmount = 3;
                break;
            case ShipClass.Federation:
                hallwayAmmount = 14; 
                roomAmmount = 4;
                wallAmmount = 0;
                doorAmmount = 0;
                break;
            case ShipClass.Slug:
                hallwayAmmount = 11; 
                roomAmmount = 5;
                wallAmmount = 0;
                doorAmmount = 0;
                break;
            case ShipClass.Mantis:
                hallwayAmmount = 11; 
                roomAmmount = 6;
                wallAmmount = 0;
                doorAmmount = 0;
                break;
            // Annunaki
            case ShipClass.Zoltan:
                hallwayAmmount = 13; 
                roomAmmount = 5;
                wallAmmount = 0;
                doorAmmount = 0;
                break;
            case ShipClass.Stealth:
                hallwayAmmount = 8; 
                roomAmmount = 6;
                wallAmmount = 0;
                doorAmmount = 0;
                break;
            case ShipClass.Rock:
                hallwayAmmount = 10; 
                roomAmmount = 6;
                wallAmmount = 0;
                doorAmmount = 0;
                break;
            case ShipClass.Engi:
                hallwayAmmount = 12; 
                roomAmmount = 2;
                wallAmmount = 0;
                doorAmmount = 0;
                break;
            default:
                hallwayAmmount = 0; 
                roomAmmount = 0;
                wallAmmount = 0;
                doorAmmount = 0;
                break;
        }
        BuildLayout(hallwayAmmount, roomAmmount, wallAmmount, doorAmmount);
        AssignLayout(hallwayAmmount, roomAmmount, wallAmmount, doorAmmount);
    }

    private void AssignLayout(int hallwayAmmount, int roomAmmount, int wallAmmount, int doorAmmount) {
        Dictionary<string, Stack<Vector3>> shipClassPosition = GetShipClassPosition();
        Dictionary<string, Stack<Vector3>> shipClassRotation = GetShipClassRotation();

        var hallways = gameObject.transform.Find("Hallways");
        var hallwayPosStack = shipClassLayout["Hallway"];
        var hallwayRotationStack = shipClassRotation["Hallway"];
        for (int index = 0; index < hallwayAmmount; index++) {
            var hallway = hallways.transform.Find($"Hallway {index + 1}");
        }

        var rooms = gameObject.transform.Find("Rooms");
        var roomPosStack = shipClassLayout["Room"];
        var roomRotationStack = shipClassRotation["Room"];
        for (int index = 0; index < roomAmmount; index++) {
            var room = rooms.transform.Find($"Room {index + 1}");
        }

        var walls = gameObject.transform.Find("Walls");
        var wallPosStack = shipClassLayout["Wall"];
        var wallRotationStack = shipClassRotation["Wall"];
        for (int index = 0; index < roomAmmount; index++) {
            var wall = walls.transform.Find($"Wall {index + 1}");
        }

        var doors = gameObject.transform.Find("Doors");
        var doorPosStack = shipClassLayout["Door"];
        var doorRotationStack = shipClassRotation["Door"];
        for (int index = 0; index < roomAmmount; index++) {
            var door = doors.transform.Find($"Door {index + 1}");
        }
    }

    private Dictionary<string, Stack<Vector3>> GetShipClassPosition() {
        var shipClassPosition = new Dictionary<string, Stack<Vector3>>();
        switch (shipClass) {
            // Atlantians
            case ShipClass.Kestrel:
                break;
            case ShipClass.Federation:
                break;
            case ShipClass.Slug:
                break;
            case ShipClass.Mantis:
                break;
            // Annunaki
            case ShipClass.Zoltan:
                break;
            case ShipClass.Stealth:
                break;
            case ShipClass.Rock:
                break;
            case ShipClass.Engi:
                break;
            default:
                break;
        }
        return shipClassPosition;
    }

    private Dictionary<string, Stack<Vector3>> GetShipClassRotation() {
        var shipClassRotation = new Dictionary<string, Stack<Vector3>>();
        switch (shipClass) {
            // Atlantians
            case ShipClass.Kestrel:
                break;
            case ShipClass.Federation:
                break;
            case ShipClass.Slug:
                break;
            case ShipClass.Mantis:
                break;
            // Annunaki
            case ShipClass.Zoltan:
                break;
            case ShipClass.Stealth:
                break;
            case ShipClass.Rock:
                break;
            case ShipClass.Engi:
                break;
            default:
                break;
        }
        return shipClassRotation;
    }

    private void BuildLayout(int hallwayAmmount, int roomAmmount, int wallAmmount, int doorAmmount) {
        var hallways = new GameObject("Hallways");
        for (int index = 0; index < hallwayAmmount; index++) {
            var hallway = BuildHallway();
            hallway.transform.SetParent(hallways.transform);
        }
        hallways.transform.SetParent(gameObject.transform);

        var rooms = new GameObject("Rooms");
        for (int index = 0; index < roomAmmount; index++) {
            var room = BuildRoom();
            room.transform.SetParent(rooms.transform);
        }
        rooms.transform.SetParent(gameObject.transform);

        var walls = new GameObject("walls");
        for (int index = 0; index < wallAmmount; index++) {
            var wall = BuildWall();
            wall.transform.SetParent(walls.transform);
        }
        walls.transform.SetParent(gameObject.transform);

        var doors = new GameObject("Doors");
        for (int index = 0; index < doorAmmount; index++) {
            var door = BuildDoor();
            door.transform.SetParent(doors.transform);
        }
        doors.transform.SetParent(gameObject.transform);
    }

    private GameObject BuildHallway() {
        hallwayCount++;
        var hallway = new GameObject($"Hallway {hallwayCount}");
        hallway.transform.position = new Vector3(0, 0, 0);

        floorCount++;
        var floorOne = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorOne, 5, 5);
        floorOne.transform.position = new Vector3(0, 0, 0);
        floorOne.transform.SetParent(hallway.transform);

        floorCount++;
        var floorTwo = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorTwo, 5, 5);
        floorTwo.transform.position = new Vector3(0, 0, 5);
        floorTwo.transform.SetParent(hallway.transform);

        return hallway;
    }

    private GameObject BuildRoom() {
        roomCount++;
        var room = new GameObject($"Room {roomCount}");
        room.transform.position = new Vector3(0, 0, 0);

        floorCount++;
        var floorOne = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorOne, 5, 5);
        floorOne.transform.position = new Vector3(0, 0, 0);
        floorOne.transform.SetParent(room.transform);

        floorCount++;
        var floorTwo = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorTwo, 5, 5);
        floorTwo.transform.position = new Vector3(5, 0, 0);
        floorTwo.transform.SetParent(room.transform);

        floorCount++;
        var floorThree = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorThree, 5, 5);
        floorThree.transform.position = new Vector3(5, 0, 5);
        floorThree.transform.SetParent(room.transform);

        floorCount++;
        var floorFour = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorFour, 5, 5);
        floorFour.transform.position = new Vector3(0, 0, 5);
        floorFour.transform.SetParent(room.transform);

        return room;
    }

    public GameObject BuildWall() {
        return gameObject.GetComponent<Board>().InitalizeWall();
    }

    public GameObject BuildDoor() {
        return gameObject.GetComponent<Board>().InitalizeDoor();
    }
}
