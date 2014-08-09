/* Module		: ButtonAction_MainMenu.cs
 * Author		: Bryce Jassmond
 * Email		: bjassmond@alum.wpi.edu
 * CoAuthor		: N/A
 * Email		: N/A
 *
 * Description	: Go to the main menu
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
public class ButtonAction_MainMenu : ButtonAction {
	
	/* -- Variables --------------------------------------------------------- */
	
	
	/* -- Methods ----------------------------------------------------------- */
	
	
	/* Method		: public override void runAction()
	 *
	 * Description	: Overrides abstract action definition. Switch to main menu
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	public override void runAction() {
		Application.LoadLevel("MainMenu");
	}
	
}
