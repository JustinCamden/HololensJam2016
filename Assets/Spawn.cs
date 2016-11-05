using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject pillow;
    int counter = 0;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        counter++;
	}

    public void spawnPillow()
    {
        Instantiate(pillow, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
    }
}
