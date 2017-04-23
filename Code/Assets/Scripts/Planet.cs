using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	public float tolerance = 1;
	public bool allAreAligned = false;

	void Update()
	{
		float angle = GetComponentInChildren<MovementBehaviour>().m_angle;
		foreach (MovementBehaviour dude in GetComponentsInChildren<MovementBehaviour>())
		{
			if (dude.m_angle > angle - tolerance && dude.m_angle < angle + tolerance)
			{
				allAreAligned = true;
			}
			else
			{
				allAreAligned = false;
				break;
			}
		}

		if (allAreAligned)
		{
			Debug.Log("VICTORY");
		}
	}

}
