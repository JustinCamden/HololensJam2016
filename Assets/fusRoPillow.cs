using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class fusRoPillow : MonoBehaviour {

    public HandsManager myManager;
    public GameObject ghostPillow;


    bool shooting;
    int myPower;
    const int maxPower = 10;

    int chargeTime;
    const int powerUpTime = 10;

    bool charging;

    public GameObject[] pillows;
    public int randNum = 0;

    public gameManager myGame;

    public AudioSource charge;
    // Use this for initialization
    void Start () {
        myPower = 0;
        charging = false;
        chargeTime = 0;
        shooting = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(myGame.myState());
	}

    public void spawnPillow()
    {
        if (shooting)
        {
            randNum = Random.Range(0, pillows.Length);
            GameObject myPillow = Instantiate(pillows[randNum], new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            myPillow.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 500);
            myPillow.GetComponent<Rigidbody>().AddForce(gameObject.transform.up * 50);
        }
    }

    public void switchShoot()
    {
        if (myGame.myState() == 2)
        {
            shooting = !shooting;
            charge.Play();
        }
        if (!shooting)
        {
            ghostPillow.SetActive(true);
            ghostPillow.transform.SetParent(null);
        }
        else
        {
            ghostPillow.SetActive(false);
            ghostPillow.transform.SetParent(gameObject.transform);
            ghostPillow.transform.localPosition = new Vector3(0, 0.22f, 1.39f);
        }
    }

}
