using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject[] pillows;
    public GameObject animals;
    public int randNum = 0;
    public gameManager myGame;

    int counter = 0;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        counter++;

    }

    public void spawnPillow()
    {
        randNum = Random.Range(0, pillows.Length);
        Instantiate(pillows[randNum], new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
    }

    public void spawnAnimals()
    {
        GameObject animalTown=Instantiate(animals, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        animalTown.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 250);
        animalTown.GetComponent<Rigidbody>().AddForce(gameObject.transform.up * 50);
        myGame.switchAnimals();
    } 
}
