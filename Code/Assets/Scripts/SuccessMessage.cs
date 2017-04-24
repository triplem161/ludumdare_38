using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessMessage : MonoBehaviour
{
	public string[] randomMessage;
	public Text text;

	void Awake()
	{
		text = GetComponent<Text>();
	}

	public void displayMessage()
	{
		text.text = randomMessage[Random.Range(0, randomMessage.Length)];
	}

	public void displayEndMessage()
	{
		text.enabled = true;
		text.text = "Victory \n Thanks For Playing";
	}
}
