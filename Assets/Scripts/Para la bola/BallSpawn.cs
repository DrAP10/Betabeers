using UnityEngine;
using System.Collections;

public class BallSpawn : MonoBehaviour {
	float time;
	public float spawn_time=10f;
	public GameObject ball;
	// Use this for initialization
	void Start () {
		time = 11f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > spawn_time) 
		{
			Instantiate (ball, transform.position,transform.rotation);
			time = 0f;
		}
	}
}
