/* Module		: Trial.cs
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

	List<Color> objectColors = new List<Color>();
	int targetSpot = -1;
	int currentObject = -1;
	float currentObjectTime = 0f;
	int timesSpacePressed = 0;
	int lastObjectSpacePressed = -1;
	float timeOfSpacePressed = 0;
	bool finished = false;
	
	/* -- Methods ----------------------------------------------------------- */


	/* Method		: public void setUpTrial ((TextMesh tt, SpriteRenderer t, 
	 * 					Color tc, List<Color> tcp))
	 *
	 * Description	: Sets up the trial with the target and order of objects 
	 * 					to show.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	public void setUpTrial (TextMesh tt, SpriteRenderer t, Color tc, List<Color> tcp) {
		targetText = tt;
		target = t;
		targetColor = tc;
		trialColorPool = tcp;

		for (int i = 0; i < numberToShow; i++) {
			objectColors.Add(
				trialColorPool[Random.Range(0, trialColorPool.Count)]);
		}

		targetSpot = Random.Range(0, numberToShow + 1) - 1;

		if (targetSpot >= 0) objectColors[targetSpot] = targetColor;
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
			lastObjectSpacePressed = currentObject;
			timeOfSpacePressed = currentObjectTime;
		}
	}

	/* Method		: public void startTrial ()
	 *
	 * Description	: Starts the trial.
	 *
	 * Parameters	: Trial t	- The trial to run
	 *
	 * Returns		: void
	 */
	public void startTrial() {
		StartCoroutine_Auto(runTrial());
	}

	/* Method		: public IEnumerator runTrial()
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
	public IEnumerator runTrial() {
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
			target.color = objectColors[i];

			target.gameObject.SetActive(true);
			yield return new WaitForSeconds(timeUp);
			target.gameObject.SetActive(false);
			yield return new WaitForSeconds(timeBetween);
		}

		finished = true;
	}

	/* -- Get/Sets ---------------------------------------------------------- */

	public bool isFinished() {return finished;}
	public bool shotHitTarget() {return lastObjectSpacePressed == targetSpot;}
	public int getTargetSpot() {return targetSpot;}
	public int getTimesSpacePressed() {return timesSpacePressed;}
	public int getLastObjectSpacePressed() {return lastObjectSpacePressed;}
	public float getTimeOfSpacePressed() {return timeOfSpacePressed;}


}
