using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution (800, 480, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect(100,100,500,100),"<size=40>Comming Soon</size>");
		if (GUI.Button (new Rect (100, 250, 200, 100), "<size=40>MainMenu</size>"))
						Application.LoadLevel ("scStart");
	}
}
