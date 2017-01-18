using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int target = 0;
    public Transform exitPoint;
    public Transform[] waypoints;
    public float navigationUpdate;

    private Transform enemy;
    private float navigationTime;

	// Use this for initialization
	void Start () {
        enemy = GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (waypoints != null)
        {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigationUpdate)
            {
                if (target < waypoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, waypoints[target].position, navigationTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                }
                navigationTime = 0;

                }
            }
        }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
            target += 1;
        else if (collision.tag == "Finish")
        {
            GameManager.Instance.RemoveEnemyFromScreen();
            Destroy(gameObject);
        }
            


    }

}

