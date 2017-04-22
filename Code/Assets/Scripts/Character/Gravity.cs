using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

	void FixedUpdate()
	{
		GetGravityDirection();
	}

	private void GetGravityDirection()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
		if (hit.collider != null)
		{
			this.transform.up = hit.normal;
		}
	}
}
