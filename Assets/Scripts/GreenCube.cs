using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCube : MonoBehaviour
{
    public GameObject platform;
    private Platform platformScript;
    // Start is called before the first frame update
    void Start()
    {
        platformScript = platform.GetComponent<Platform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        platformScript.gotCube = true;
        Destroy(gameObject);
    }
}
