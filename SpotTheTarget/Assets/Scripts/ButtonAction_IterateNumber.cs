/* Module		: ButtonAction_NumberIterate.cs
 * Author		: Bryce Jassmond
 * Email		: bjassmond@alum.wpi.edu
 * CoAuthor		: N/A
 * Email		: N/A
 *
 * Description	: Adds a given interval to the given TextMesh's current text
 * 					value.
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
public class ButtonAction_IterateNumber : ButtonAction {
	
	/* -- Variables --------------------------------------------------------- */
	
	[SerializeField] TextMesh text;
	[SerializeField] int interval = 1;
	[SerializeField] int min = 0;
	[SerializeField] int max = 1000;
	
	
	/* -- Methods ----------------------------------------------------------- */
	
	
	/* Method		: public override void runAction()
	 *
	 * Description	: Overrides abstract action definition. Adds the interval
	 * 					to the current text integer value.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	public override void runAction() {
		text.text = (Mathf.Clamp(int.Parse(text.text) + interval, min, max)).ToString();
	}
	
}
