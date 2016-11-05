using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AI : MonoBehaviour {

    // Variables
    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;

    // World gameobject
    public Transform target;

    // Components
    CharacterController myCharacterController;


	// Use this for initialization
	void Start () {
        myCharacterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // Move towards the target position
        MoveTowardsTarget(target.position);
	}

    // Move towards the target position
    void MoveTowardsTarget(Vector3 target)
    {
        // Make sure the enemy never tries to look up or down
        target.y = transform.position.y;

        // Rotate the enemy towards the target
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookatRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookatRotation, Time.deltaTime * rotationSpeed);

        // Move towards the target direction
        direction *= movementSpeed;
        myCharacterController.Move(direction * Time.deltaTime);
    }

    void OnCollisionEnter(Collision coll)
    {
        // Insert code to destroy / damage target here
    }
}
