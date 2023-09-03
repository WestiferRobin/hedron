using Assets.Scripts.DefaultBoard;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// TODO: Fix this crap with the new Prism prefab. Maybe make this into a factory?
public class Hedron : MonoBehaviour
{
    public int hedronSize = 5;
    public GameObject prismTemplate;
    public Vector3 initalPosition = Vector3.zero;
    public Vector3 initalRotation = Vector3.zero;
    private readonly Dictionary<Guid, GameObject> prisms = new();

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < hedronSize; i++)
        //{
        //    var currentPosition = new Vector3(initalPosition.x, 0, i + initalPosition.z);
        //    GameObject asdf = prismTemplate;
        //    asdf.transform.rotation = new Quaternion(initalRotation.x, initalRotation.y, initalRotation.z, this.transform.rotation.w);
        //    Instantiate(asdf, this.transform);
        //    PrismCore prism = asdf.GetComponent<PrismCore>();
        //    prism.InitalizePrism();
        //    asdf.transform.position = currentPosition;
        //    this.prisms.Add(prism.Id, asdf);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
