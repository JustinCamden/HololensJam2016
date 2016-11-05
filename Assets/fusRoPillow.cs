using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class fusRoPillow : MonoBehaviour {

    public HandsManager myManager;

    int myPower;
    const int maxPower = 10;

    int chargeTime;
    const int powerUpTime = 10;

    bool charging;

    public GameObject[] pillows;
    public int randNum = 0;

    public gameManager myGame;

    // Use this for initialization
    void Start () {
        myPower = 0;
        charging = false;
        chargeTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (myGame.myState() == 2)
        {
            if (myManager.HandsPressed == true)
            {
                charging = true;
                if (chargeTime == powerUpTime)
                {
                    myPower += 1;
                    chargeTime = 0;
                }
                else
                {
                    chargeTime++;
                }
            }
            else
            {
                if (charging == true)
                {
                    spawnPillow();
                }
            }
        }
	}

    public void spawnPillow()
    {
        randNum = Random.Range(0, pillows.Length);
        GameObject myPillow=Instantiate(pillows[randNum], new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        myPillow.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * myPower);
    }

}
