using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript: MonoBehaviour
{

	Text text;
	public static int diceNumber;
	

	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
		
	
	}

	// Update is called once per frame
	void Update()
	{
		text.text = diceNumber.ToString();

	}
}
