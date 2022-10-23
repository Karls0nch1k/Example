using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	protected MainSphere MainSphere;
	protected Sphere[] balls;

	public int i = 0;

	// Use this for initialization
	void Start () {

		MainSphere = FindObjectOfType<MainSphere>();
		balls = FindObjectsOfType<Sphere>();

	}

	// Update is called once per frame
	void Update () {

		// raycast to check certain objects
		RaycastHit hit;
		Ray ray;
		if (Input.touchCount > 0)
		{
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		}
		else
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		}
			
		var direction = Vector3.zero;

		if (Physics.Raycast(ray, out hit))
		{
			var ballPos = new Vector3(MainSphere.transform.position.x, 0.1f, MainSphere.transform.position.z);
			var mousePos = new Vector3(hit.point.x, 0.1f, hit.point.z);

			direction = (mousePos - ballPos).normalized;
		}

		//when you tap on the left side of the screen you can move the white ball
		if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) && MainSphere.GetComponent<Rigidbody>().velocity.magnitude == 0)
		{
			MainSphere.GetComponent<Rigidbody>().velocity = direction * 5f;
		}

			
		//game reset
		if (i == 10)
		{
			i = 0;
			MainSphere.ResetBall();
			foreach (var ball in balls)
			{
				ball.gameObject.SetActive(true);
				ball.ResetBall();
			}
		}
	}

	//counter of balls in holes
	public void PlusObj()
	{
		i++;
	}
}