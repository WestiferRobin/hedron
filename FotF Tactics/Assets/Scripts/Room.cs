using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject boardObj;
    // Start is called before the first frame update
    void Start()
    {
        InitalizeTiles();
    }

    public void InitalizeTiles() {
        var one = new GameObject();
        one.name = "Row 1";
        CreateCornerSide(one);
        one.transform.position = new Vector3(0, 0, 0);
        one.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        one.transform.SetParent(gameObject.transform);

        var two = new GameObject();
        two.name = "Row 2";
        CreateOpenSide(two);
        two.transform.position = new Vector3(10, 0, 20);
        two.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        two.transform.SetParent(gameObject.transform);

        var three = new GameObject();
        three.name = "Row 3";
        CreateCornerSide(three);
        three.transform.position = new Vector3(30, 0, 30);
        three.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        three.transform.SetParent(gameObject.transform);
    }

    

    public void CreateOpenSide(GameObject side) {
        var wallSection1 = new GameObject();
        wallSection1.name = "Wall Section 1";
        CreateSideSection(wallSection1);
        wallSection1.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        wallSection1.transform.position = new Vector3(10, 0, 20);
        wallSection1.transform.SetParent(side.transform);

        var openSection = new GameObject();
        openSection.name = "Open Section";
        CreateOpenSection(openSection);
        openSection.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        openSection.transform.position = new Vector3(0, 0, 0);
        openSection.transform.SetParent(side.transform);

        var wallSection2 = new GameObject();
        wallSection2.name = "Wall Section 2";
        CreateSideSection(wallSection2);
        wallSection2.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        wallSection2.transform.position = new Vector3(0, 0, -10);
        wallSection2.transform.SetParent(side.transform);
    }

    public void CreateCornerSide(GameObject side) {
        var cornerSection1 = new GameObject();
        cornerSection1.name = "Corner Section 1";
        CreateCornerSection(cornerSection1);
        cornerSection1.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        cornerSection1.transform.position = new Vector3(0, 0, 0);
        cornerSection1.transform.SetParent(side.transform);

        var wallSection = new GameObject();
        wallSection.name = "Wall Section";
        CreateSideSection(wallSection);
        wallSection.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        wallSection.transform.position = new Vector3(10, 0, 0);
        wallSection.transform.SetParent(side.transform);

        var cornerSection2 = new GameObject();
        cornerSection2.name = "Corner Section 2";
        CreateCornerSection(cornerSection2);
        cornerSection2.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
        cornerSection2.transform.position = new Vector3(30, 0, 0);
        cornerSection2.transform.SetParent(side.transform);
    }

    public void CreateCornerSection(GameObject section) {
        var floor = new GameObject();
        floor.name = "Floor";
        boardObj.GetComponent<Board>().InitalizeTiles(floor, 10, 10);
        // asdf.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        // floor.transform.position = new Vector3(0, 5, 0);
        floor.transform.SetParent(section.transform);

        var wallOne = new GameObject();
        wallOne.name = "Wall 1";
        boardObj.GetComponent<Board>().InitalizeTiles(wallOne, 10, 4);
        wallOne.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
        wallOne.transform.position = new Vector3(0, 0, 0);
        wallOne.transform.SetParent(section.transform);

        var wallTwo = new GameObject();
        wallTwo.name = "Wall 2";
        boardObj.GetComponent<Board>().InitalizeTiles(wallTwo, 10, 4);
        wallTwo.transform.Rotate(-90.0f, -90.0f, 0.0f, Space.Self);
        wallTwo.transform.position = new Vector3(0, 0, 0);
        wallTwo.transform.SetParent(section.transform);
    }

    public void CreateSideSection(GameObject section) {
        var floor = new GameObject();
        floor.name = "Floor";
        boardObj.GetComponent<Board>().InitalizeTiles(floor, 10, 10);
        // asdf.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        // floor.transform.position = new Vector3(0, 5, 0);
        floor.transform.SetParent(section.transform);

        var wallOne = new GameObject();
        wallOne.name = "Wall 1";
        boardObj.GetComponent<Board>().InitalizeTiles(wallOne, 10, 4);
        wallOne.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
        wallOne.transform.position = new Vector3(0, 0, 0);
        wallOne.transform.SetParent(section.transform);
    }

    public void CreateOpenSection(GameObject section) {
        var floor = new GameObject();
        floor.name = "Floor";
        boardObj.GetComponent<Board>().InitalizeTiles(floor, 10, 10);
        // asdf.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        // floor.transform.position = new Vector3(0, 5, 0);
        floor.transform.SetParent(section.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
