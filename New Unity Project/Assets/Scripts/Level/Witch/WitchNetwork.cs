using UnityEngine;
using System.Collections;

public class WitchNetwork : Photon.MonoBehaviour {

	private Vector3 correctPlayerPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		
		if(stream.isWriting) {
			stream.SendNext(transform.position);
		}
		else {
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
		}	
	}
}
