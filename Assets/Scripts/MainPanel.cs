using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    public Transform UI;
	public GameObject BaitList;

	public void OpenBaitsList()
	{
		
		Instantiate(BaitList, UI, false);
	}
}
