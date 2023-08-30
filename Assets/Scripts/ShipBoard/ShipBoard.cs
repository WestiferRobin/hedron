using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBoard : MonoBehaviour
{
    public GameObject tile;

    public GameObject wall;
    public GameObject door;
    private GameObject[,] board;

    private int wallCount = 0;
    private int doorCount = 0;

    public void InitalizeTiles(GameObject parent, int width, int height)
    {
        board = new GameObject[width, height];
        for (int index = 0; index < width; index++)
        {
            var row = new GameObject($"TileRow {index}");
            for (int subIndex = 0; subIndex < height; subIndex++)
            {
                tile.name = $"Tile {subIndex}";
                board[index, subIndex] = Instantiate(tile, new Vector3(index + 0.5f, 0, subIndex + 0.5f), Quaternion.identity);
                board[index, subIndex].transform.SetParent(row.transform);
            }
            row.transform.SetParent(parent.transform);
        }
    }

    public GameObject InitalizeWall()
    {
        wallCount++;
        var wallObj = Instantiate(wall, Vector3.zero, Quaternion.identity);
        wallObj.name = $"Wall {wallCount}";
        return wallObj;
    }

    public GameObject InitalizeDoor()
    {
        doorCount++;
        var doorObj = Instantiate(door, Vector3.zero, Quaternion.identity);
        doorObj.name = $"Door {doorCount}";
        return doorObj;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
