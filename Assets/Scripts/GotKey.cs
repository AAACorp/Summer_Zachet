using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotKey : MonoBehaviour
{
    public GameObject door;
    private DoorController doorController;
    // Start is called before the first frame update
    void Start()
    {
        doorController = door.GetComponent<DoorController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        doorController.gotKey = true;
        Destroy(gameObject);
    }
}
