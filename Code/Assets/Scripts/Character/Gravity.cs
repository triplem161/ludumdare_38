using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Gravity : MonoBehaviour
{
	public Transform planet;
	public int speed = 1;

	void FixedUpdate()
	{
		GetGravityDirection();
	}

	private void GetGravityDirection()
	{
		transform.up = planet.position - transform.position;
		transform.position += transform.up * Time.deltaTime;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += -transform.right * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += transform.right * Time.deltaTime * speed;
		}
	}


}
