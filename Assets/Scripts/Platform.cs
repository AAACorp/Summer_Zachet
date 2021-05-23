using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    private bool playerInZone = false;
    public bool gotCube = false;
    public GameObject txtToDisplay;

    public GameObject Wall;
    public Transform posForWall;
    public GameObject Wall2;
    public Transform posForWall2;

    private bool temp = false;
    private bool moveWall = false;

    public GameObject cubePref;
    public Transform placeForCube;

    // Start is called before the first frame update
    void Start()
    {
        playerInZone = false;
        gotCube = false;
        txtToDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && temp == false)
        {
            txtToDisplay.GetComponent<Text>().text = "Нажмите 'E', чтобы положить куб на платформу ";
        }

        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            if(gotCube == false)
            {
                txtToDisplay.GetComponent<Text>().text = "Нужен куб";
                temp = true;
            }

            if(gotCube)
            {
                GameObject cube = Instantiate(cubePref, placeForCube, gameObject.transform);
                cube.transform.localPosition = new Vector3(0, 0.1f, 0);
                gotCube = false;
                moveWall = true; 
                txtToDisplay.SetActive(false);
            }
        }
        if(moveWall)
        {
            Wall.transform.position = Vector3.Lerp(Wall.transform.position, posForWall.position, 0.1f * Time.deltaTime);
            Wall2.transform.position = Vector3.Lerp(Wall2.transform.position, posForWall2.position, 0.1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInZone = true;
        txtToDisplay.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        playerInZone = false;
        txtToDisplay.SetActive(false);
    }
}
