using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	public static int dicecnt;
	public static int secondroll;
	int doorNum;


	SceneManagement sc10;
	[SerializeField] Text explainTxt;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
		sc10 = new SceneManagement();
		dicecnt = 0;
		doorNum = Random.Range(1, 6);




		explainTxt.text = doorNum.ToString() + "의 약수";





	}

	// Update is called once per frame
	void Update() {
		diceVelocity = rb.velocity;
		

		if (dicecnt == 1)
		{

			if (doorNum == 6)
			{
				if (DiceNumberTextScript.diceNumber == 1 || DiceNumberTextScript.diceNumber == 2 || DiceNumberTextScript.diceNumber == 3 || DiceNumberTextScript.diceNumber == 6)
				{
					Stage10GameManager.DoseDiceGameEnd = true;
				}
				else
				{
					StartCoroutine("gameover");
				}
			}

			if (doorNum == 5)
			{
				if (DiceNumberTextScript.diceNumber == 5 || DiceNumberTextScript.diceNumber == 1)
				{
					Stage10GameManager.DoseDiceGameEnd = true;
				}
				else
				{
					StartCoroutine("gameover");
				}
			}

			if (doorNum == 4)
			{
				if (DiceNumberTextScript.diceNumber == 1 || DiceNumberTextScript.diceNumber == 2 || DiceNumberTextScript.diceNumber == 4)
				{
					Stage10GameManager.DoseDiceGameEnd = true;
				}
				else
				{
					StartCoroutine("gameover");
				}
			}

			if (doorNum == 3)
			{
				if (DiceNumberTextScript.diceNumber == 3 || DiceNumberTextScript.diceNumber == 1)
				{
					Stage10GameManager.DoseDiceGameEnd = true;
				}
				else
				{
					StartCoroutine("gameover");
				}
			}

			if (doorNum == 2)
			{
				if (DiceNumberTextScript.diceNumber == 2 || DiceNumberTextScript.diceNumber == 1)
				{
					Stage10GameManager.DoseDiceGameEnd = true;
				}
				else
				{
					StartCoroutine("gameover");
				}
			}

			if (doorNum == 1)
			{
				if (DiceNumberTextScript.diceNumber == 1)
				{
					Stage10GameManager.DoseDiceGameEnd = true;
				}
				else
				{
					StartCoroutine("gameover");

				}



			}

		}
			

		
	}
	IEnumerator gameover() //설명 및 명언(상단 출력)
	{
		yield return new WaitForSeconds(5f);
		sc10.gameover(10);

	}

	void OnMouseDown()
	{
		float dirX = Random.Range(0, 500);
		float dirY = Random.Range(0, 500);
		float dirZ = Random.Range(0, 500);
		transform.position = new Vector3(120, 56, 14);
		transform.rotation = Quaternion.identity;
		rb.AddForce(transform.up * 1000);
		rb.AddTorque(dirX, dirY, dirZ);
		dicecnt += 1;

	}
}








