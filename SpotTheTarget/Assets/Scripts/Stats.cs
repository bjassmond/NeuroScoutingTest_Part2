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
		float avgTime = 0f;

		foreach (Trial t in trials) {
			if (t.getTimesSpacePressed() > 0) {
				if (t.shotHitTarget()) correct++;
				else incorrect++;
			}
			else {
				if (t.getTargetSpot() >= 0) noShot++;
				else correct++;
			}

			avgShots += t.getTimesSpacePressed();
			avgTime += t.getTimeOfSpacePressed();
		}

		print (avgShots + ", " + avgTime);

		avgShots = avgShots * trials.Count;
		avgTime = avgTime / trials.Count;

		stats[2].text = correct.ToString();
		stats[3].text = incorrect.ToString();
		stats[4].text = noShot.ToString();
		stats[5].text = avgShots.ToString();
		stats[6].text = avgTime.ToString();
	}
}
