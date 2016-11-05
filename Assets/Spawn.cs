using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject pillow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnPillow()
    {
        Instantiate(pillow, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
