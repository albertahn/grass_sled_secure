using UnityEngine;
using System.Collections;

public class startManager : MonoBehaviour {
	playerCtrl _playerCtrl;
	public Texture background;

	// Use this for initialization
	void Start () {
		//Screen.SetResolution (800, 480, true);

		Screen.SetResolution (480, 800,  true);
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		//GUI.DrawTexture (new Rect(0,0,800,480),background);
		string str = "<size=40>Turbo Farm</size>";
		GUI.Label(new Rect (100 - 2, 100, 500, 500),"<Color='black'>"+ str+"</Color>");        // 왼쪽
		GUI.Label(new Rect (100, 100 - 2, 500, 500),"<Color='black'>"+ str+"</Color>");        // 위
		GUI.Label(new Rect (100 + 2, 100, 500, 500),"<Color='black'>"+ str+"</Color>");        // 오른쪽
		GUI.Label(new Rect (100, 100 + 2, 500, 500),"<Color='black'>"+ str+"</Color>");   
		GUI.Label (new Rect(100,100,500,500),"<Color='white'>"+str+"</Color>");


		if (GUI.Button (new Rect (100, 100, 200, 70), "<size=40>Start</size>")){

			Application.LoadLevel("scStage1");
		}

		if (GUI.Button (new Rect (100, 200, 200, 70), "<size=40>Coin Shop</size>")){			
			//playerCtrl.basicAngle = Input.acceleration.y;
			Application.LoadLevel("scCoin");
		}

		if (GUI.Button (new Rect (100, 300, 200, 70), "<size=40>Log Out</size>")){

			PlayerPrefs.SetInt("IsLogIn",0);
			PlayerPrefs.SetString("email","");
			PlayerPrefs.SetString("username","");
			PlayerPrefs.SetString("user_index","");
			PlayerPrefs.SetString("points", "");

			Application.LoadLevel("scPreStart");
		}

		if (GUI.Button (new Rect (100, 400, 200, 70), "<size=40>Exit</size>")){
			
			playerCtrl.basicAngle = Input.acceleration.y;
			Application.Quit();
		}
	}
}
