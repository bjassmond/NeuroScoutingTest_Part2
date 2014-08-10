/* Module		: Stats.cs
 * Author		: Bryce Jassmond
 * Email		: bjassmond@alum.wpi.edu
 * CoAuthor		: N/A
 * Email		: N/A
 *
 * Description	: Display statistics on the trials
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
public class Stats : MonoBehaviour {
	
	/* -- Variables --------------------------------------------------------- */
	
	[SerializeField] List<TextMesh> stats = new List<TextMesh>();
	
	
	/* -- Methods ----------------------------------------------------------- */


	/* Method		: public void loadStats(List<Trial> trials)
	 *
	 * Description	: Runs through each trial, recording the stats, and places
	 * 					them in the appropriate text meshes.
	 *
	 * Parameters	: List<Trial> trials	- The list of trials
	 *
	 * Returns		: void
	 */
	public void loadStats(List<Trial> trials) {
		stats[0].text = trials.Count.ToString();
		stats[1].text = trials[0].numberToShow.ToString();

		int correct = 0;
		int incorrect = 0;
		int noShot = 0;
		float avgShots = 0f;
		float trialsWithShots = 0f;
		float avgTime = 0f;

		foreach (Trial t in trials) {
			if (t.getTimesSpacePressed() > 0) {
				if (t.shotHitTarget()) correct++;
				else incorrect++;

				avgShots += t.getTimesSpacePressed();
				avgTime += t.getTimeOfSpacePressed();
				trialsWithShots += 1;
			}
			else {
				if (t.getTargetSpot() >= 0) noShot++;
				else correct++;
			}
		}

		if (trialsWithShots > 0) {
			avgShots /= trialsWithShots;
			avgTime /= trialsWithShots;
		}

		stats[2].text = correct.ToString();
		stats[3].text = incorrect.ToString();
		stats[4].text = noShot.ToString();
		stats[5].text = avgShots.ToString();
		stats[6].text = avgTime.ToString();

		string feedback = "";

		float correctWrongRatio = correct/trials.Count;

		if (correctWrongRatio > .9f) feedback += "You are very accurate,\n";
		else if (correctWrongRatio > .8f) feedback += "You are accurate,\n";
		else if (correctWrongRatio > .7f) feedback += "You are fairly accurate,\n";
		else if (correctWrongRatio > .5f) feedback += "You are sorta accurate,\n";
		else feedback += "You are inaccurate,\n";

		if (avgShots < 1.1f) feedback += "very sure of your shot,\n";
		else if (avgShots < 1.5f) feedback += "sure of your shot,\n";
		else if (avgShots < 2f) feedback += "fairly sure of your shot,\n";
		else if (avgShots < 3f) feedback += "sorta sure of your shot,\n";
		else if (avgShots < 1.5f) feedback += "not sure of your shot,\n";

		if (avgTime < .5f) feedback += "and have very quick fingers.";
		else if (avgTime < .6f) feedback += "and have quick fingers.";
		else if (avgTime < .75f) feedback += "and have fairly quick fingers.";
		else if (avgTime < 1) feedback += "and have decent fingers.";
		else if (avgTime < 1.5f) feedback += "and have sorta slow fingers.";
		else feedback += "and slow fingers.";

		stats[7].text = feedback;
	}
}
