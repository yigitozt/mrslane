using UnityEngine;
using System.Collections;

public class PlayerTriggerNetwork : Photon.MonoBehaviour {
	public PhotonView myPhotonView;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		
		if(stream.isWriting) 
		{
			//			stream.SendNext(transform.position);
		}
		else {
			//			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
		}	
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag == "potion")
		{
			if(myPhotonView.isMine)
			{
				PlayerSkill.bonusTimer = 1.0f;
				PlayerSkill.bonusReceived = true;
				Debug.Log("TRIGGER WORK");
			}
		}
	}
}
