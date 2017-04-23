using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
	public Planet[] planets;
	private int currentPlanet = -1;

	void Start()
	{
		//ChangePlanet(0);
	}



	void ChangePlanet(int newPlanet)
	{
		//planets[currentPlanet].enabled = false;
		planets[newPlanet].enabled = true;

		currentPlanet = newPlanet;
	}
}
