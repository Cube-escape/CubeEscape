using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDiceScript : MonoBehaviour
{
	static Rigidbody rb;
	public static Vector3 diceVelocity;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		diceVelocity = rb.velocity;
	}

	private void OnMouseDown()
	{
		if (DiceScript.dicecnt == 1)
		{
			float dirX = Random.Range(0, 500);
			float dirY = Random.Range(0, 500);
			float dirZ = Random.Range(0, 500);
			transform.position = new Vector3(120, 56, 14);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 1000);
			rb.AddTorque(dirX, dirY, dirZ);
		}

	}
}
