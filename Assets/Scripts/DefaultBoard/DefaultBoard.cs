using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBoard : MonoBehaviour
{
    public GameObject tile;
    public int width = 10;
    public int height = 10;

    private GameObject[,] board;


    public void Start()
    {
        InitalizeTiles();
    }

    public void InitalizeTiles() {//(GameObject parent, int width, int height) {
        board = new GameObject[width, height];
        for (int index = 0; index < width; index++) {
            var row = new GameObject($"TileRow {index}");
            for (int subIndex = 0; subIndex < height; subIndex++) {
                tile.name = $"Tile {subIndex}";
                board[index, subIndex] = Instantiate(tile, new Vector3(index + 0.5f, 0, subIndex + 0.5f), Quaternion.identity);
                board[index, subIndex].transform.SetParent(row.transform);
            }
            row.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
