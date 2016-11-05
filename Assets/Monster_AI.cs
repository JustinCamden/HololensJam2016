using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AI : MonoBehaviour {

    // Variables
    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;
    public 

    // World gameobject
    public Transform target;
    Enemy_Spawner enemySpawner;

    // Components
    CharacterController myCharacterController;


	// Use this for initialization
	void Start () {
        myCharacterController = GetComponent<CharacterController>();
        enemySpawner = FindObjectOfType<Enemy_Spawner>();
        target = GameObject.FindWithTag("Target").transform;
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

    void OnControllerColliderHit(ControllerColliderHit coll)
    {
        // Check to see if the object is a pillow
        Pillow pillow = coll.gameObject.GetComponent<Pillow>();
        StuffedAnimal stuffedAnimal = coll.gameObject.GetComponent<StuffedAnimal>();
        if (pillow != null || stuffedAnimal != null)
        {
            // Destroy other gameobject if pillow
            pillow.EnemyHit();

            // Destroy this gameobject if it is a pillow
            enemySpawner.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }
}
