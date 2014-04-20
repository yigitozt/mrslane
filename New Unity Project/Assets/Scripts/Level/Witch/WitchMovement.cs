using UnityEngine;
using System.Collections;

public class WitchMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(Time.deltaTime * 9, 0, 0);
		gameObject.animation.wrapMode = WrapMode.PingPong;
		gameObject.animation.CrossFade("Witch_Run");
	}
}
