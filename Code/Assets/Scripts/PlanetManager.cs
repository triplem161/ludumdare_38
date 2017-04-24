using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
	public DudeManager[] planets;
	private int currentPlanet = 0;

	void Start()
	{
		planets[0].gameObject.SetActive(true);
	}

	void Update()
	{
		if (planets[currentPlanet].checkDudesAlignement())
		{
			ChangePlanet();
		}
	}

	void ChangePlanet()
	{
		planets[currentPlanet].gameObject.SetActive(false);
		currentPlanet++;
		planets[currentPlanet].gameObject.SetActive(true);
	}
}
