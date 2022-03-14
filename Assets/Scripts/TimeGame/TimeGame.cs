using GeneralScripts;

using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

using Random = UnityEngine.Random;

public class TimeGame : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI numberDisplayText, combatMessage;
	[SerializeField] private GameManager gameManager;
	// floats
	private float roundStartDelayTime = 3;
	private float roundStartTime = 0;
	// ints 
	private int waitTime = 0;
	// bools
	private bool roundStarted = false;
	// text
	private string waitingText = "Waiting for new number";

	private void Start()
	{
		Invoke(nameof(SetNewRandomTime), roundStartDelayTime);
		numberDisplayText.text = waitingText;
	}
	void Update() { if(Input.GetKeyDown(KeyCode.Space) && roundStarted) InputReceived(); }

	void InputReceived()
	{
		roundStarted = false;
		float playerWaitTime = Time.time - roundStartTime;
		float error = Mathf.Abs(waitTime - playerWaitTime);
		
		string text = $"You waited for {playerWaitTime} seconds. That's {error} seconds off.";
		string gendMessage = GenerateMessage(error);
		gameManager.DoAttack(gendMessage);
		
		combatMessage.text = $"{text} {gendMessage}";
		numberDisplayText.text = waitingText;
		Invoke(nameof(SetNewRandomTime), roundStartDelayTime);
	}

	string GenerateMessage(float _error)
	{
		string message = 
			(_error < .15f)              ? "Critical Hit" :
			(_error < .75f)              ? "Hit Enemy" :
			_error < 1.25f               ? "Draw" :
			(_error < 1.75f)             ? "Ouch" : "Critical Damage";

		return message;
	}

	void SetNewRandomTime()
	{
		waitTime = Random.Range(5, 21);
		roundStartTime = Time.time;
		roundStarted = true;
		numberDisplayText.text = $"The number to reach is <b> {waitTime} </b> Seconds  ";
	}
}
