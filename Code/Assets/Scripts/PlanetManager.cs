using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetManager : MonoBehaviour
{
	public DudeManager[] planets;
	public SuccessMessage message;
	private int currentPlanet = 0;

	private bool isInTransition = false;
	private bool isEndGame = false;

	void Start()
	{
		planets[0].gameObject.SetActive(true);
	}

	void Update()
	{
		if (!isEndGame)
		{
			if (planets[currentPlanet].checkDudesAlignement() && !isInTransition)
			{
				StartCoroutine(DisplayMessage());
			}
		}


		//Manage reload of level
		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	void ChangePlanet()
	{
		planets[currentPlanet].gameObject.SetActive(false);
		currentPlanet++;

		if(currentPlanet == planets.Length)
		{
			message.displayEndMessage();
			isEndGame = true;
		}
		else
		{
			planets[currentPlanet].gameObject.SetActive(true);
			isInTransition = false;
		}
	}

	private IEnumerator DisplayMessage()
	{
		isInTransition = true;

		Debug.Log("Start message");
		yield return new WaitForSeconds(0.5f);

		Debug.Log("Display message");
		message.text.enabled = true;
		message.displayMessage();

		yield return new WaitForSeconds(2f);

		Debug.Log("Hide message and change planet");
		message.text.enabled = false;

		ChangePlanet();
	}
}
