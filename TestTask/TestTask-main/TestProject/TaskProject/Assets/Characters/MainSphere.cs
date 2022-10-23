using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public Counter Counter;

public class MainSphere : MonoBehaviour {

	protected Vector3 Startpos;
	protected bool ResetB;

	// Use this for initialization
	void Start()
	{
		Startpos = transform.position;
		
	}

	// Update is called once per frame
	void Update () {
		
		//if the white ball fall into the hole
		if (transform.position.y < -0.1f)
		{
			GetComponent<Rigidbody>().freezeRotation = true;
			transform.position = new Vector3(0, 0.1f, 0);
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().freezeRotation = false;
		}

		//if the game restart
		if (ResetB)
		{
			ResetB = false;
			GetComponent<Rigidbody>().freezeRotation = true;
			transform.position = Startpos;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().freezeRotation = false;
			//transform.rotation = Quaternion.Euler(0, 0, 0);
			//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
		}
	}
	public void ResetBall()
	{
		ResetB = true;
	}
}
