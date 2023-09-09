using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Hedron : MonoBehaviour
{
    public GameObject prismPrefab;

    [SerializeField] private Tilemap tilemap;
    public int numberOfPrisms = 5;

    void Start()
    {
        GeneratePrisms();
    }

    void GeneratePrisms()
    {
        for (int i = 0; i < numberOfPrisms; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(i + 4.5f, 4, 0); // Adjust the spacing as needed
            if (prismPrefab.TryGetComponent<PrismMovement>(out var prismMovement))
            {
                prismMovement.tilemap = tilemap;
                var prism = Instantiate(prismPrefab, spawnPosition, Quaternion.identity);
                prism.transform.parent = transform;
            }
        }
    }
}
