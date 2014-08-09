/* Module		: Button.cs
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

/* -- Class Definition ------------------------------------------------------ */
public class Button : MonoBehaviour {

	/* -- Variables --------------------------------------------------------- */

	[SerializeField] ButtonAction action;


	/* -- Methods ----------------------------------------------------------- */

	/* Method		: void OnMouseDown()
	 *
	 * Description	: Built in method that runs when a mouse button is pressed
	 * 					down on this. Runs the given action.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	void OnMouseDown() {
		action.runAction();
	}
}
