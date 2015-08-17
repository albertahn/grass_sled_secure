using UnityEngine;
using System.Collections;

public class coinCtrl : MonoBehaviour {
	
	private GameMgr _gameMgr;
	// Use this for initialization
	void Start () {
		
		_gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if (coll.collider.tag == "PLAYER") {
			_gameMgr.coin+=1;
			Destroy(this.gameObject);
		}
	}
}
