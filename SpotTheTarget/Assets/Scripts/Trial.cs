/* Module		: Trial.cs
 * Author		: Bryce Jassmond
 * Email		: bjassmond@alum.wpi.edu
 * CoAuthor		: N/A
 * Email		: N/A
 *
 * Description	: Runs a given ButtonAction when pressed
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

	public GameObject targetText;
	public SpriteRenderer target;
	public Color targetColor;
	public List<Color> trialColorPool = new List<Color>();
	public int numberToShow = 6;
	public float timeUp = 2f;
	public float timeBetween = 1f;

	int timesSpacePressed = 0;
	int lastObjectSpacePressed = -1;
	int timeOfSpacePressed = 0;

	
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
			objectColors.Add(trialColorPool[Random.Range(0, trialColorPool.Count)]);
		}

		int targetSpot = Random.Range(0, numberToShow + 1) - 1;

		if (targetSpot > 0) objectColors[targetSpot] = targetColor;

		StartCoroutine_Auto(runTrial(objectColors));
	}
	
	IEnumerator runTrial(List<Color> colors) {
		target.color = targetColor;
		target.gameObject.SetActive(true);
		targetText.gameObject.SetActive(true);
		yield return new WaitForSeconds(timeUp);
		target.gameObject.SetActive(false);
		targetText.gameObject.SetActive(false);
		yield return new WaitForSeconds(timeBetween);

		for (int i = 0; i < numberToShow; i++) {
			target.color = colors[i];
			target.gameObject.SetActive(true);
			yield return new WaitForSeconds(timeUp);
			target.gameObject.SetActive(false);
			yield return new WaitForSeconds(timeBetween);
		}
	}
}
