using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
	public	eHideableType	hideableType;

    private bool activated = false;
    public bool isActivated
    {
        get { return activated; }
        set { activated = value; }
    }

    private bool picked = false;
    public bool isPicked
    {
        get { return picked; }
        set { picked = value; }
    }

	public	bool	isPickable()
	{
		return hideableType == eHideableType.HIDEABLE_POWER_UP;
	}
}
