using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipClass
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

public class Ship : MonoBehaviour
{
    public ShipClass shipClass = ShipClass.Kestrel;
    private int floorCount = 0;
    private int hallwayCount = 0;
    private int roomCount = 0;

    public List<GameObject> Floors;

    // Start is called before the first frame update
    void Start()
    {
        Floors = new List<GameObject>();
        // configure what ship to build
        // render the rooms
        // layout the rooms
        // apply systems and memebers
        // then create shell
        int hallwayAmmount; 
        int roomAmmount;
        switch (shipClass) {
            // Allies
            case ShipClass.Kestrel:
                hallwayAmmount = 10; 
                roomAmmount = 7;
                break;
            case ShipClass.Federation:
                hallwayAmmount = 14; 
                roomAmmount = 4;
                break;
            case ShipClass.Slug:
                hallwayAmmount = 11; 
                roomAmmount = 5;
                break;
            case ShipClass.Mantis:
                hallwayAmmount = 11; 
                roomAmmount = 6;
                break;
            // Enemies
            case ShipClass.Zoltan:
                hallwayAmmount = 13; 
                roomAmmount = 5;
                break;
            case ShipClass.Stealth:
                hallwayAmmount = 8; 
                roomAmmount = 6;
                break;
            case ShipClass.Rock:
                hallwayAmmount = 10; 
                roomAmmount = 6;
                break;
            case ShipClass.Engi:
                hallwayAmmount = 12; 
                roomAmmount = 2;
                break;
            default:
                hallwayAmmount = 0; 
                roomAmmount = 0;
                break;
        }
        BuildLayout(hallwayAmmount, roomAmmount);
        var floorObject = this.Floors;
        Debug.Log(floorObject.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildLayout(int hallwayAmmount, int roomAmmount) {
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

        var layoutPosition = GetShipClassPosition();
        foreach (var key in layoutPosition.Keys) {
            if (key.Contains("Room")) {
                var room = GameObject.Find(key);
                room.transform.position = layoutPosition[key];
            } else if (key.Contains("Hallway")) {
                var hallway = GameObject.Find(key);
                hallway.transform.position = layoutPosition[key];
            }
        }

        var layoutRotation = GetShipClassRotation();
        foreach (var key in layoutRotation.Keys) {
            var rotation = Vector3.zero;
            if (key.Contains("Room")) {
                var room = GameObject.Find(key);
                rotation = layoutRotation[key];
                room.transform.Rotate(rotation.x, rotation.y, rotation.z, Space.Self);
            } else if (key.Contains("Hallway")) {
                var hallway = GameObject.Find(key);
                rotation = layoutRotation[key];
                hallway.transform.Rotate(rotation.x, rotation.y, rotation.z, Space.Self);
            }
        }

        AddDoors();
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
        Floors.Add(floorOne);

        floorCount++;
        var floorTwo = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorTwo, 5, 5);
        floorTwo.transform.position = new Vector3(0, 0, 5);
        floorTwo.transform.SetParent(hallway.transform);
        Floors.Add(floorTwo);

        for (int index = 0; index < 6; index++) {
            var wall = gameObject.GetComponent<Board>().InitalizeWall();
            Vector3 position = Vector3.zero;
            Vector3 rotation = Vector3.zero;
            switch (index) {
                case 0:
                    position  = new Vector3(0, 0, 0);
                    rotation = new Vector3(0, 0, 0);
                    break;
                case 1:
                    position  = new Vector3(0, 0, 10);
                    rotation = new Vector3(0, 0, 0);
                    break;
                case 2:
                    position  = new Vector3(0, 0, 5);
                    rotation = new Vector3(0, 90, 0);
                    break;
                case 3:
                    position  = new Vector3(0, 0, 10);
                    rotation = new Vector3(0, 90, 0);
                    break;
                case 4:
                    position  = new Vector3(5, 0, 5);
                    rotation = new Vector3(0, 90, 0);
                    break;
                case 5:
                    position  = new Vector3(5, 0, 10);
                    rotation = new Vector3(0, 90, 0);
                    break;
            }
            wall.transform.position = position;
            wall.transform.Rotate(rotation.x, rotation.y, rotation.z, Space.Self);
            wall.transform.SetParent(hallway.transform);
        }

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
        Floors.Add(floorOne);

        floorCount++;
        var floorTwo = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorTwo, 5, 5);
        floorTwo.transform.position = new Vector3(5, 0, 0);
        floorTwo.transform.SetParent(room.transform);
        Floors.Add(floorTwo);

        floorCount++;
        var floorThree = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorThree, 5, 5);
        floorThree.transform.position = new Vector3(5, 0, 5);
        floorThree.transform.SetParent(room.transform);
        Floors.Add(floorThree);

        floorCount++;
        var floorFour = new GameObject($"Floor {floorCount}");
        gameObject.GetComponent<Board>().InitalizeTiles(floorFour, 5, 5);
        floorFour.transform.position = new Vector3(0, 0, 5);
        floorFour.transform.SetParent(room.transform);
        Floors.Add(floorFour);

        for (int index = 0; index < 8; index++) {
            var wall = gameObject.GetComponent<Board>().InitalizeWall();
            Vector3 position = Vector3.zero;
            Vector3 rotation = Vector3.zero;
            switch (index) {
                case 0:
                    position  = new Vector3(0, 0, 0);
                    rotation = new Vector3(0, 0, 0);
                    break;
                case 1:
                    position  = new Vector3(0, 0, 10);
                    rotation = new Vector3(0, 0, 0);
                    break;
                case 2:
                    position  = new Vector3(0, 0, 5);
                    rotation = new Vector3(0, 90, 0);
                    break;
                case 3:
                    position  = new Vector3(0, 0, 10);
                    rotation = new Vector3(0, 90, 0);
                    break;
                case 4:
                    position  = new Vector3(10, 0, 5);
                    rotation = new Vector3(0, 90, 0);
                    break;
                case 5:
                    position  = new Vector3(10, 0, 10);
                    rotation = new Vector3(0, 90, 0);
                    break;
                case 6:
                    position  = new Vector3(5, 0, 0);
                    rotation = new Vector3(0, 0, 0);
                    break;
                case 7:
                    position  = new Vector3(5, 0, 10);
                    rotation = new Vector3(0, 0, 0);
                    break;
            }
            wall.transform.position = position;
            wall.transform.Rotate((float) rotation.x, (float) rotation.y, (float) rotation.z, Space.Self);
            wall.transform.SetParent(room.transform);
        }

        return room;
    }

    public GameObject BuildWall() {
        return gameObject.GetComponent<Board>().InitalizeWall();
    }

    public GameObject BuildDoor() {
        return gameObject.GetComponent<Board>().InitalizeDoor();
    }

    private void AddDoors() {
        var repeats = new List<string>();
        var doors = new List<string>();
        switch (shipClass) {
            // Allies
            case ShipClass.Kestrel:
                repeats.Add("Wall 5");
                repeats.Add("Wall 6");
                repeats.Add("Wall 7");
                repeats.Add("Wall 8");
                repeats.Add("Wall 13");
                repeats.Add("Wall 14");
                repeats.Add("Wall 21");
                repeats.Add("Wall 22");
                repeats.Add("Wall 29");
                repeats.Add("Wall 30");
                repeats.Add("Wall 32");
                repeats.Add("Wall 33");
                repeats.Add("Wall 38");
                repeats.Add("Wall 41");
                repeats.Add("Wall 43");
                repeats.Add("Wall 45");
                repeats.Add("Wall 49");
                repeats.Add("Wall 53");
                repeats.Add("Wall 57");
                repeats.Add("Wall 58");
                repeats.Add("Wall 64");
                repeats.Add("Wall 65");
                repeats.Add("Wall 66");
                repeats.Add("Wall 70");
                repeats.Add("Wall 72");
                repeats.Add("Wall 73");
                repeats.Add("Wall 76");
                repeats.Add("Wall 77");
                repeats.Add("Wall 82");
                repeats.Add("Wall 85");
                repeats.Add("Wall 87");
                repeats.Add("Wall 90");
                repeats.Add("Wall 94");
                repeats.Add("Wall 96");
                repeats.Add("Wall 97");
                repeats.Add("Wall 103");
                repeats.Add("Wall 104");
                repeats.Add("Wall 107");
                repeats.Add("Wall 108");
                repeats.Add("Wall 109");
                repeats.Add("Wall 110");
                repeats.Add("Wall 113");
                repeats.Add("Wall 114");

                doors.Add("Wall 43");
                doors.Add("Wall 49");
                doors.Add("Wall 64");
                doors.Add("Wall 65");
                doors.Add("Wall 66");
                doors.Add("Wall 72");
                doors.Add("Wall 77");
                doors.Add("Wall 83");
                doors.Add("Wall 85");
                doors.Add("Wall 87");
                doors.Add("Wall 94");
                doors.Add("Wall 96");
                doors.Add("Wall 103");
                doors.Add("Wall 104");
                doors.Add("Wall 107");
                doors.Add("Wall 108");
                doors.Add("Wall 109");
                doors.Add("Wall 110");
                doors.Add("Wall 113");
                doors.Add("Wall 114");
                break;
            case ShipClass.Federation:
                break;
            case ShipClass.Slug:
                break;
            case ShipClass.Mantis:
                break;
            // Enemies
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
        foreach (var key in doors) {
            var wall = GameObject.Find(key);
            var door = BuildDoor();
            door.transform.position = wall.transform.position;
            door.transform.Rotate(
                wall.transform.eulerAngles.x, 
                wall.transform.eulerAngles.y, 
                wall.transform.eulerAngles.z, 
                Space.Self
            );
            door.transform.SetParent(wall.transform.parent.gameObject.transform);
        }
        foreach (var repeat in repeats) {
            Destroy(GameObject.Find(repeat));
        }
    }

    private Dictionary<string, Vector3> GetShipClassPosition() {
        var shipClassPosition = new Dictionary<string, Vector3>();
        switch (shipClass) {
            // Allies
            case ShipClass.Kestrel:
                shipClassPosition["Hallway 1"] = new Vector3(0, 0, 0);

                shipClassPosition["Room 1"] = new Vector3(5, 0, 0);

                shipClassPosition["Hallway 2"] = new Vector3(15, 0, 5);
                shipClassPosition["Hallway 3"] = new Vector3(15, 0, 10);

                shipClassPosition["Room 2"] = new Vector3(25, 0, -5);
                shipClassPosition["Room 3"] = new Vector3(25, 0, 5);
                shipClassPosition["Room 4"] = new Vector3(35, 0, -5);
                shipClassPosition["Room 5"] = new Vector3(35, 0, 5);

                shipClassPosition["Hallway 4"] = new Vector3(35, 0, -5);
                shipClassPosition["Hallway 5"] = new Vector3(35, 0, 20);

                shipClassPosition["Room 6"] = new Vector3(45, 0, 0);

                shipClassPosition["Hallway 6"] = new Vector3(50, 0, 0);
                shipClassPosition["Hallway 7"] = new Vector3(50, 0, 15);
                shipClassPosition["Hallway 8"] = new Vector3(60, 0, 0);
                shipClassPosition["Hallway 9"] = new Vector3(60, 0, 15);

                shipClassPosition["Room 7"] = new Vector3(60, 0, 0);

                shipClassPosition["Hallway 10"] = new Vector3(70, 0, 0);
                break;
            case ShipClass.Federation:
                break;
            case ShipClass.Slug:
                break;
            case ShipClass.Mantis:
                break;
            // Enemies
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

    private Dictionary<string, Vector3> GetShipClassRotation() {
        var shipClassRotation = new Dictionary<string, Vector3>();
        switch (shipClass) {
            // Allies
            case ShipClass.Kestrel:
                shipClassRotation["Hallway 2"] = new Vector3(0, 90, 0);
                shipClassRotation["Hallway 3"] = new Vector3(0, 90, 0);
                shipClassRotation["Hallway 4"] = new Vector3(0, 90, 0);
                shipClassRotation["Hallway 5"] = new Vector3(0, 90, 0);
                shipClassRotation["Hallway 6"] = new Vector3(0, 90, 0);
                shipClassRotation["Hallway 7"] = new Vector3(0, 90, 0);
                shipClassRotation["Hallway 8"] = new Vector3(0, 90, 0);
                shipClassRotation["Hallway 9"] = new Vector3(0, 90, 0);
                break;
            case ShipClass.Federation:
                break;
            case ShipClass.Slug:
                break;
            case ShipClass.Mantis:
                break;
            // Enemies
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

}
