using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {
	
	private Server LoginServer; //= GetComponent<Server>();

	private string index,email,score;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (800, 480, true);

		index = PlayerPrefs.GetString("user_index");
		email = PlayerPrefs.GetString("email");
		score = PlayerPrefs.GetString("points");

		LoginServer = GetComponent<Server>();
		LoginServer.SaveBestScore (index,email,score);

		StartCoroutine(LoginServer.SaveBestScore (index,email,score));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Texture background;
	void OnGUI(){
		GUI.DrawTexture (new Rect(0,0,800,480),background);
		string str = "<size=40>You DIED!!!!!</size>";
		GUI.Label(new Rect (100 - 2, 100, 500, 500),"<Color='black'>"+ str+"</Color>");        // 왼쪽
		GUI.Label(new Rect (100, 100 - 2, 500, 500),"<Color='black'>"+ str+"</Color>");        // 위
		GUI.Label(new Rect (100 + 2, 100, 500, 500),"<Color='black'>"+ str+"</Color>");        // 오른쪽
		GUI.Label(new Rect (100, 100 + 2, 500, 500),"<Color='black'>"+ str+"</Color>");   
		GUI.Label (new Rect(150,50,500,500),"<size=30><Color='white'>score: "+ PlayerPrefs.GetString("points")+"</Color></size>");


		if (GUI.Button (new Rect (100, 150, 200, 100), "<size=40>Retry</size>")) {
			Application.LoadLevel("scStage1");
		}
		if (GUI.Button (new Rect (100, 270, 200, 100), "<size=40>MainMenu</size>")) {
			Application.LoadLevel("scStart");
		}
	}
}
