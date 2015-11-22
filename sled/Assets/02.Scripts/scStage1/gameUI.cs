using UnityEngine;
using System.Collections;

public class gameUI : MonoBehaviour {

	public Texture speed_back;
	public Texture speed_front;
	public Texture timeTexture;
	public Texture coinTexture;

	private int wObj,hObj;
	private int w,h;

	private float speed;
	private float maxSpeed;
	private float speedHeight;

	private playerCtrl _playerCtrl;
	private GameMgr _gameMgr;
	// Use this for initialization
	void Start () {
		_gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();
		w = 800;
		h = 480;
		_playerCtrl = GameObject.FindWithTag ("PLAYER").GetComponent<playerCtrl> ();

		wObj = 250;
		hObj = 250;
		speedHeight=250.0f;
	}
	
	// Update is called once per frame
	void Update () {
		speed = _playerCtrl.vspeed;
		maxSpeed = _playerCtrl.maxVspeed;	
	}

	void OnGUI(){
	//	speedHeight = 180 * speed/maxSpeed;

		GUI.DrawTexture (new Rect(w-wObj,h-hObj,wObj,hObj),speed_back);
		//GUI.DrawTexture (new Rect(w-130,h-40,90,-speedHeight),speed_front);
		GUI.DrawTexture (new Rect(0,h-80,200,100),timeTexture);
		GUI.DrawTexture (new Rect(200,h-80,200,100),coinTexture);
		//GUI.Label (new Rect(w-230,h-75,150,100),"<size=40>"+speed+"</size><size=20>m/h</size>");
		GUI.Label (new Rect(80,h-50,100,100),"<size=35>"+(int)_gameMgr.gameTime+"</size><size=20>s</size>");
		//GUI.Label (new Rect(280,h-50,100,100),"<size=35>"+calculateUnit()+"</size>");
	}

	/*string calculateUnit(){
		int x = _gameMgr.coin;
		int k, m, b, t;
		if (x >= 1000000000) {
			b = x / 1000000000;
			return b.ToString()+'b';
		} else if (x >= 1000000) {
			m = x / 1000000;
			return m.ToString()+'m';
		} else if (x >= 1000) {
			k = x / 1000;
			return k.ToString()+'k';
		} else {
			return x.ToString();
		}
	}*/
}