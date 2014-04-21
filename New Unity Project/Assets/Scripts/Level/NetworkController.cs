using UnityEngine;
using System.Collections;

public class NetworkController : Photon.MonoBehaviour {
	// Use this for initialization
	private PhotonView myPhotonView;
	GameObject witch;
	
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("alpha 0.1");
		
	}
	
	void Update()
	{
		
	}
	
	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
	void OnJoinedLobby(){
		
		PhotonNetwork.JoinRandomRoom ();
	}
	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom (null);
	}
	
	void OnJoinedRoom(){


		GameObject player = PhotonNetwork.Instantiate ("Player1", Vector3.zero, Quaternion.identity, 0);
		myPhotonView = player.GetComponent<PhotonView>();
		
		player.AddComponent<PlayerMovement> ();
		player.AddComponent<PlayerSkill> ();
		
		player.transform.position = new Vector3(0,0, -PhotonNetwork.countOfPlayers * 1.3f);
	
		if(PhotonNetwork.countOfPlayers == 2)
		{
			witch = PhotonNetwork.Instantiate ("Witch", new Vector3(-30, 0, -1.12f), Quaternion.identity, 0);
		}
		else if(PhotonNetwork.countOfPlayers < 2 && witch)
		{
			PhotonNetwork.Destroy(witch);
		}

		
//		if(PhotonNetwork.countOfPlayers == 1)
//		{
//			GameObject startObject = PhotonNetwork.Instantiate ("StartingObject", new Vector3(8,2,0), Quaternion.identity, 0);
//		}
//		else if(PhotonNetwork.countOfPlayers == 2)
//		{
//			GameObject witch = PhotonNetwork.Instantiate ("Witch", new Vector3(-80,8,0), Quaternion.identity, 0);
//			witch.AddComponent<WitchControl>();
//		}
		
		//		PhotonNetwork.SetMasterClient(PhotonNetwork.player);
		//		PhotonNetwork.Disconnect();
	}	
	
	void OnLeftRoom()
	{
		//		if (PhotonNetwork.countOfPlayers < 2)
		//		{
		//			PhotonNetwork.Destroy(object1);
		//		}
	}
}
