using UnityEngine;
using System.Collections;

public class PlayerSkill : MonoBehaviour {
	public static bool bonusReceived;
	public PhotonView myPhotonView;
	public int selectedBonus;
	public static float bonusTimer;
	private float rollBonusTimer;

	// Use this for initialization
	void Start () {
		myPhotonView = gameObject.GetComponent<PhotonView>();
		bonusTimer = 1.5f;
		rollBonusTimer = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(bonusReceived)
		{
			rollBonusTimer -= Time.deltaTime;
			if(rollBonusTimer <= 0)
			{
				selectedBonus = Random.Range(1, 11);
				rollBonusTimer = 0.1f;
			}
			
			bonusTimer -= Time.deltaTime;
			if(bonusTimer <= 0)
			{
				selectedBonus = Random.Range(1, 11);
				bonusReceived = false;
				Debug.Log(selectedBonus);
			}
		}
	}
}
