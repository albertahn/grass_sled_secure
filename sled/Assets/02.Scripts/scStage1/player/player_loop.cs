using UnityEngine;
using System.Collections;

public class player_loop : MonoBehaviour {
	public Transform startPoint;
	public Transform playerTr;
	private GameMgr _gameMgr;
	public GameObject[] trees;
	public GameObject[] coins;

	// Use this for initialization
	void Start () {
		startPoint = GameObject.Find ("playerSpawnPoint/startPoint").GetComponent<Transform> ();
		playerTr = GetComponent<Transform> ();
		_gameMgr = GameObject.Find ("GameManager").GetComponent<GameMgr> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "ENDPOINT") {
			//Debug.Log("hello");
			playerTr.position = startPoint.position;
			_gameMgr.level+=1;
			if(_gameMgr.level>=4){
				_gameMgr.level=4;
			}

			trees = GameObject.FindGameObjectsWithTag("TREE");
			for(int i=0;i<trees.Length;i++){
				Destroy(trees[i]);
			}
			StartCoroutine(_gameMgr.CreateTree());

			coins = GameObject.FindGameObjectsWithTag("COIN");
			for(int i=0;i<coins.Length;i++){
				Destroy(coins[i]);
			}
			StartCoroutine(_gameMgr.CreateCoin());
		}
	}
}