/* Module		: ButtonAction.cs
 * Author		: Bryce Jassmond
 * Email		: bjassmond@alum.wpi.edu
 * CoAuthor		: N/A
 * Email		: N/A
 *
 * Description	: Base class for defining what action a button can take
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
public abstract class ButtonAction : MonoBehaviour {

	/* -- Variables --------------------------------------------------------- */
	
	
	
	
	/* -- Methods ----------------------------------------------------------- */
	
	
	/* Method		: public abstract void runAction()
	 *
	 * Description	: Abstract definition for a method to run an action.
	 *
	 * Parameters	: void
	 *
	 * Returns		: void
	 */
	public abstract void runAction();

}
