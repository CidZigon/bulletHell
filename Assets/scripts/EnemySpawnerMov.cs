﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMov : MonoBehaviour
{

    public Boundary boundary;
    public GameObject enemyObject;
    public GameObject playerShip;
    public float spawnRate;
    public float speed;

    private ObjectPool enemies;
    private float nextSpawn = 0.5f;
    private float myTime;

	// Use this for initialization
	void Start ()
    {
        enemies = new ObjectPool();
        enemies.objectForPool = enemyObject;
        enemies.poolAmmount = 10;
        enemies.growth = false;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), 0, transform.position.z);
	    if (transform.position.x <= boundary.xMin || transform.position.x >= boundary.xMax)
	        speed *= -1;

	    if (Time.time > nextSpawn)
	    {
            nextSpawn = Time.time + spawnRate;

	        GameObject clone = Instantiate(enemyObject, transform.position, transform.rotation);
            clone.GetComponent<EnemyMovement>().SetPlayerShip(playerShip);
	    }
	}
}
