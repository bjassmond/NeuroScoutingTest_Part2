﻿/* Module		: Trial.cs
 * Author		: Bryce Jassmond
 * Email		: bjassmond@alum.wpi.edu
 * CoAuthor		: N/A
 * Email		: N/A
 *
 * Description	: Runs a trial of showing a target followed by a series of
 * 					objects the user must press the spacebar on when they see
 * 					the one that matches the target.
 *
 * Date			: 2014/08/09
 *
 * History:
 * Revision		Date			Changed By
 * --------		----------		----------
 * 01.00		2014/08/09		bjassmond
 *
 */

/* -- Using ----------------------------------------------------------------- */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* -- Class Definition ------------------------------------------------------ */
public class Trial : MonoBehaviour {

	/* -- Variables --------------------------------------------------------- */

	public TextMesh targetText;
	public SpriteRenderer target;
	public Color targetColor;
	public List<Color> trialColorPool = new List<Color>();
	public int numberToShow = 6;
	public float timeUp = 2f;
	public float timeBetween = 1f;

	int currentObject = -1;
	float currentObjectTime = 0f;
	int timesSpacePressed = 0;
	int lastObjectSpacePressed = -1;
	float timeOfSpacePressed = 0;

	
	/* -- Methods ----------------------------------------------------------- */


	/* Method		: void Start ()
	 *
	 * Description	: Default initialization, called on second pass when 
	 * 					initialized. Sets up and runs trial.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	void Start () {
		List<Color> objectColors = new List<Color>();

		for (int i = 0; i < numberToShow; i++) {
			objectColors.Add(
				trialColorPool[Random.Range(0, trialColorPool.Count)]);
		}

		int targetSpot = Random.Range(0, numberToShow + 1) - 1;

		if (targetSpot > 0) objectColors[targetSpot] = targetColor;

		StartCoroutine_Auto(runTrial(objectColors));
	}

	/* Method		: void Update ()
	 *
	 * Description	: Default update, called once per tick. Reads space input
	 * 					and updates tracking variables if it is pressed.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	void Update() {
		bool spaceHit = Input.GetButtonDown("Space");
		currentObjectTime += Time.deltaTime;

		if (spaceHit) {
			timesSpacePressed += 1;
			lastObjectSpacePressed = currentObject + 1;
			timeOfSpacePressed = currentObjectTime;
		}
	}

	/* Method		: IEnumerator runTrial(List<Color> colors)
	 *
	 * Description	: Runs the trial, displaying the target and it's text
	 * 					first, hiding them, and then showing the
	 * 					specified number of objects one-by-one until the
	 * 					end of the trial, keeping track of the current
	 * 					object number and time spent on it.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	IEnumerator runTrial(List<Color> colors) {
		target.color = targetColor;

		target.gameObject.SetActive(true);
		targetText.gameObject.SetActive(true);
		yield return new WaitForSeconds(timeUp);
		target.gameObject.SetActive(false);
		targetText.gameObject.SetActive(false);
		yield return new WaitForSeconds(timeBetween);

		for (int i = 0; i < numberToShow; i++) {
			currentObject = i;
			currentObjectTime = 0f;
			target.color = colors[i];

			target.gameObject.SetActive(true);
			yield return new WaitForSeconds(timeUp);
			target.gameObject.SetActive(false);
			yield return new WaitForSeconds(timeBetween);
		}

		print ("Times space pressed: " + timesSpacePressed + ", Chosen Object: " + lastObjectSpacePressed +
		       ", Time to Choose Object: " + timeOfSpacePressed + "s");
	}
}
