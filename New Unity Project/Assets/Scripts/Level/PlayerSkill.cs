using UnityEngine;
using System.Collections;

public class PlayerSkill : MonoBehaviour {
	public static bool bonusReceived;
	public PhotonView myPhotonView;
	public int selectedBonus;
	public static float bonusTimer;
	private float rollBonusTimer;
	public Texture2D potionTexture;
	public Material material;
	public GameObject skillButton;
	public GameObject scriptObject;
	private Texture2D inputTexture;
	public AudioClip sound;
	Ray ray ;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		myPhotonView = gameObject.GetComponent<PhotonView>();
		bonusTimer = 1.5f;
		rollBonusTimer = 0.1f;
		skillButton = GameObject.Find("ButtonSkill");
		scriptObject = GameObject.Find("Scripts");

	}
	
	// Update is called once per frame
	void Update () {
		if(bonusReceived)
		{

			rollBonusTimer -= Time.deltaTime;
			if(rollBonusTimer <= 0)
			{
				selectedBonus = Random.Range(1, 11);

				if(selectedBonus == 1)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[0];
				}
				else if(selectedBonus == 2)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[1];
				}
				else if(selectedBonus == 3)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[2];
				}
				else if(selectedBonus == 4)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[3];
				}
				else if(selectedBonus == 5)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[4];
				}
				else if(selectedBonus == 6)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[5];
				}
				else if(selectedBonus == 7)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[6];
				}
				else if(selectedBonus == 8)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[7];
				}
				else if(selectedBonus == 9)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[8];
				}
				else if(selectedBonus == 10)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[9];
				}


				skillButton.renderer.material.mainTexture = inputTexture;
				rollBonusTimer = 0.1f;
			}
			
			bonusTimer -= Time.deltaTime;
			if(bonusTimer <= 0)
			{
				selectedBonus = Random.Range(1, 11);

				if(selectedBonus == 1)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[0];
				}
				else if(selectedBonus == 2)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[1];
				}
				else if(selectedBonus == 3)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[2];
				}
				else if(selectedBonus == 4)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[3];
				}
				else if(selectedBonus == 5)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[4];
				}
				else if(selectedBonus == 6)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[5];
				}
				else if(selectedBonus == 7)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[6];
				}
				else if(selectedBonus == 8)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[7];
				}
				else if(selectedBonus == 9)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[8];
				}
				else if(selectedBonus == 10)
				{
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[9];
				}

				skillButton.renderer.material.mainTexture = inputTexture;
				bonusReceived = false;
				Debug.Log(selectedBonus);
			}
		}


		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit ;
		if(Input.GetMouseButtonDown(0) && !bonusReceived)
		{
			if (Physics.Raycast (ray, out hit)) {

				if(hit.transform.name == "ButtonSkill")
				{
					sound = scriptObject.GetComponent<AllSkillsTexture>().sounds[selectedBonus - 1];

					if(selectedBonus == 1)
					{
						myPhotonView.RPC("MakeThemBlind", PhotonTargets.Others);
					
						Debug.Log("Make Them Blind");
					}
					else if(selectedBonus == 2)
					{
						PlayerMovement.dashCasted = true;
						Debug.Log("DASH");
					}
					else if(selectedBonus == 3)
					{
						myPhotonView.RPC("MakeThemFreeze", PhotonTargets.Others);
						Debug.Log("FREEZE");
					}
					else if(selectedBonus == 4)
					{
						myPhotonView.RPC("HookThem", PhotonTargets.Others);
					}
					else if(selectedBonus == 5)
					{
						Debug.Log("ICE CUBE");
					}
					else if(selectedBonus == 6)
					{
						Debug.Log("LIGHTNING");
					}
					else if(selectedBonus == 7)
					{
						Debug.Log("MAGNETIC FIELD");
					}
					else if(selectedBonus == 8)
					{
						Debug.Log("OIL");
					}
					else if(selectedBonus == 9)
					{
						Debug.Log("Shield");
					}
					else if(selectedBonus == 10)
					{
						PlayerMovement.speedUpCasted = true;
					}

					Camera.main.audio.PlayOneShot(sound);
					inputTexture = scriptObject.GetComponent<AllSkillsTexture>().skillTexture[10];
					skillButton.renderer.material.mainTexture = inputTexture;
				}
			}
		}
	}
}
