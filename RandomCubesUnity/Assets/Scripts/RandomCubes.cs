/**
 * Created By Jeremiah Underwood (kinda)
 * Date Created Jan 24 2022
 * 
 * Last edited by: NA
 * Last edited: Jan 26 2022
 * 
 * Description: Creates Random Cubes in the scene
  **/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    //Variables
    [SerializeField] private GameObject cubePrefab;               //serialize field to keep unneccecaraly public variables private, but still accessable through the editor
    [SerializeField] private List<GameObject> gameObjectList;
    [SerializeField] private float scalingFactor = 0.95f;
    [SerializeField] private int numberOfCubes = 0;
    void Start()
    {
        gameObjectList = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate() //calls at a constant rate
    {
        numberOfCubes++;                                              //iterate number for cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab);

        gObj.name = "Cube" + numberOfCubes;                            //name cubes

        gObj.transform.position = Random.insideUnitSphere;

        Color randomColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = randomColor;

        gameObjectList.Add(gObj);                                  //add cubes to list

        List<GameObject> removeList = new List<GameObject>();      //newList

        foreach (GameObject goTemp in gameObjectList)              //scales objects in list
        {
            float scale = goTemp.transform.localScale.x;
            scale *= scalingFactor;
            goTemp.transform.localScale = Vector3.one * scale;
            if (scale <= 0.1f)            //mark smallest cubes for removal
            {
                removeList.Add(goTemp);
            }
        }

        foreach (GameObject goTemp in removeList)            //remove and destroy smallest cubes cubes
        {
            gameObjectList.Remove(goTemp);
            Destroy(goTemp);
        }
    }
}
