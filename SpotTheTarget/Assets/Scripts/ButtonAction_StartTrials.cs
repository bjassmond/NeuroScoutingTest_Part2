/* Module		: ButtonAction_StartTrials.cs
 * Author		: Bryce Jassmond
 * Email		: bjassmond@alum.wpi.edu
 * CoAuthor		: N/A
 * Email		: N/A
 *
 * Description	: Give the trial manager the number of trials to run for it to
 * 					start them.
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

/* -- Class Definition ------------------------------------------------------ */
public class ButtonAction_StartTrials : ButtonAction {
	
	/* -- Variables --------------------------------------------------------- */
	
	[SerializeField] TextMesh text;
	TrialManager trialManager;
	
	
	/* -- Methods ----------------------------------------------------------- */
	
	
	/* Method		: public override void runAction()
	 *
	 * Description	: Overrides abstract action definition. Gives the trial
	 * 					manager the number of trials to run from the text.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	public override void runAction() {
		trialManager = GameObject.FindObjectOfType<TrialManager>();
		trialManager.startTrials(int.Parse(text.text));
	}
	
}
