using UnityEngine;
using System.Collections;

public class preStartManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution (800,480,true);
		if (PlayerPrefs.GetInt ("IsLogIn") == 1)
						Application.LoadLevel ("scStart");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Texture background;

	public void OnGUI(){
		GUI.DrawTexture (new Rect(0,0,800,480),background);


				if (GUI.Button (new Rect (80, 80, 300, 100), "<color=white><size=30>Log In</size></color>")) {
			
					Application.LoadLevel ("scLogIn");
			
			
				}//endifelse
			
				//show single play button
				if (GUI.Button (new Rect (80, 190, 300, 100), "<color=white><size=30>Create Account</size></color>")) {
				
						Application.LoadLevel ("scReg");
				
				
				}//endifelse
			
			
				//show multiplay button
				

				if (GUI.Button (new Rect (80, 300, 300, 100), "<color=white><size=30>Exit</size></color>")) {
			
						Application.Quit();
					
				}//endifelse
		}

}
