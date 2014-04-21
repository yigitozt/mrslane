using UnityEngine;
using System.Collections;

public class MainMenuControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit ;
		if(Input.GetMouseButton(0))
		{
			if (Physics.Raycast (ray, out hit)) {
				if(hit.transform.name == "buttonPlay")
				{
					Application.LoadLevel(1);
				}

				if(hit.transform.name == "buttonShop")
				{
					Application.LoadLevel(2);
				}
			}
		}
	}
}
