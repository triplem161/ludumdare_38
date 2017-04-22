using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Crate : MonoBehaviour
{
	public Transform planet;
	public int speed = 1;

	void Start()
	{
		GetGravityDirection();
	}

	private void GetGravityDirection()
	{
		transform.up = planet.position - transform.position;
		transform.position += transform.up * Time.deltaTime;

		if (Input.GetKey(KeyCode.A))
		{
			transform.position += -transform.right * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.O))
		{
			transform.position += transform.right * Time.deltaTime * speed;
		}
	}


}
