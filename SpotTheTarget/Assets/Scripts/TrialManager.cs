/* Module		: TrialManager.cs
 * Author		: Bryce Jassmond
 * Email		: bjassmond@alum.wpi.edu
 * CoAuthor		: N/A
 * Email		: N/A
 *
 * Description	: Creates and runs a given number of trials in order. At the
 * 					end, gives feedback on the trials.
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
public class TrialManager : MonoBehaviour {

	/* -- Variables --------------------------------------------------------- */

	public Trial trialPrefab;
	public int numberOfTrials;
	public List<Color> colorPool = new List<Color>();

	List<Trial> trialList = new List<Trial>();


	/* -- Methods ----------------------------------------------------------- */


	/* Method		: void Start ()
	 *
	 * Description	: Default initialization, called on second pass when 
	 * 					initialized. Indicates this should not be destroyed
	 * 					when changing levels.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	void Start() {
		DontDestroyOnLoad(this);
	}

	/* Method		: public void startTrials(int trialCount)
	 *
	 * Description	: Sets the number of trials to run and changes scenes.
	 *
	 * Parameters	: int trialCount	- Number of trials to run
	 *
	 * Returns		: void
	 */
	public void startTrials(int trialCount) {
		numberOfTrials = trialCount;
		Application.LoadLevel("Trials");
	}

	/* Method		: void OnLevelWasLoaded(int level)
	 *
	 * Description	: Default method that runs when a level is loaded. Sets
	 * 					up the trials to run and then runs them if the 
	 * 					level is for trials, and outputs stats if it is the
	 * 					level for results.
	 *
	 * Parameters	: int level	- the level that was loaded's index
	 *
	 * Returns		: void
	 */

	void OnLevelWasLoaded(int level) {
		if (level == 1) {
			TextMesh targetText = GameObject.FindObjectOfType<TextMesh>();
			SpriteRenderer target = GameObject.FindObjectOfType<SpriteRenderer>();
			
			for(int i = 0; i < numberOfTrials; i++) {
				int colorChoice = Random.Range(0, colorPool.Count);
				Color targetColor = colorPool[colorChoice];
				List<Color> remainingColors = new List<Color>(colorPool);
				remainingColors.RemoveAt(colorChoice);
				
				Trial trial = GameObject.Instantiate(trialPrefab) as Trial;
				trial.setUpTrial(targetText, target, targetColor, 
				                 remainingColors);
				
				trialList.Add (trial);
			}

			StartCoroutine_Auto(runTrials());
		}
		else if (level == 2) {
			Stats stats = GameObject.FindObjectOfType<Stats>();
			stats.loadStats(trialList);
		}
	}

	/* Method		: IEnumerator runTrials()
	 *
	 * Description	: Runs the trials in order
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	IEnumerator runTrials() {
		for (int i = 0; i < trialList.Count; i++) {
			trialList[i].startTrial();

			while(!trialList[i].isFinished())
				yield return new WaitForEndOfFrame();

			yield return new WaitForSeconds(2f);
		}
		Application.LoadLevel("Results");
	}
}
