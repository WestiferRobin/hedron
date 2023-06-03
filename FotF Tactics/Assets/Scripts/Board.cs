using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int boardSize = 10;
    public GameObject tile;
    private GameObject[,] board;

    // Start is called before the first frame update
    void Start()
    {
        InitalizeTiles(gameObject, boardSize, boardSize);
    }

    public void InitalizeTiles(GameObject parent, int width, int height) {
        board = new GameObject[boardSize, boardSize];
        for (int index = 0; index < width; index++) {
            var row = new GameObject();
            row.name = $"TileRow {index}";
            for (int subIndex = 0; subIndex < height; subIndex++) {
                tile.name = $"Tile {subIndex}";
                board[index, subIndex] = Instantiate(tile, new Vector3(index + 0.5f, 0, subIndex + 0.5f), Quaternion.identity);
                board[index, subIndex].transform.SetParent(row.transform);
            }
            row.transform.SetParent(parent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
