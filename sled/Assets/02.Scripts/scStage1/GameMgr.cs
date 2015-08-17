using UnityEngine;
using System.Collections;

public class GameMgr : MonoBehaviour {
	public Transform[] points;
	public GameObject[] treePoints;
	public Transform[] coinPoints;

	public GameObject monsterPrefab;
	public GameObject treePrefab;
	public GameObject coinPrefab;

	public float createTime = 2.0f;
	public bool isGameOver = false;

	private float startTime;
	public float gameTime;

	public int level;
	public int coin;


	// Use this for initialization
	void Start () {
		Screen.SetResolution (800, 480, true);
		startTime = Time.time;
		points = GameObject.Find ("PigSpawnPoint").GetComponentsInChildren<Transform> ();
		treePoints = GameObject.FindGameObjectsWithTag ("TREEPOINT");
		coinPoints = GameObject.Find ("CoinSpawnPoint").GetComponentsInChildren<Transform> ();

		if (points.Length > 0) {
			StartCoroutine(this.CreateMonster());
		}
		if (treePoints.Length > 0) {
			StartCoroutine(this.CreateTree());
		}
		if (coinPoints.Length > 0) {
			StartCoroutine(this.CreateCoin());
		}


		level = 1;

		if (PlayerPrefs.GetString ("points") == "") {
			coin = 0;
				} else {
						coin = int.Parse (PlayerPrefs.GetString ("points"));
				}
		playerCtrl.basicAngle = Input.acceleration.y;

	}

	IEnumerator CreateMonster()
	{
		while(!isGameOver){
			yield return new WaitForSeconds(createTime);

			for(int idx=1;idx<points.Length;idx++){
				Instantiate(monsterPrefab,points[idx].position,points[idx].rotation);
			}
		}
	}

	public IEnumerator CreateTree()
	{
		yield return new WaitForSeconds(0.1f);
		for(int i=0;i<treePoints.Length;i++){
			Transform[] points = treePoints[i].GetComponentsInChildren<Transform>();
			if(level<=3){
				for(int k =0;k<level;k++){
					int j = Random.Range (1,5);
					Instantiate(treePrefab,points[j].position,points[j].rotation);
				}
			}else{				
				int j = Random.Range (1,5);
				for(int k=1;k<=4;k++){
					if(j!=k)						
						Instantiate(treePrefab,points[k].position,points[k].rotation);
				}
			}
		}
	}

	public IEnumerator CreateCoin()
	{
			yield return new WaitForSeconds(0.1f);
			
			for(int idx=1;idx<coinPoints.Length;idx++){
				Instantiate(coinPrefab,coinPoints[idx].position,coinPoints[idx].rotation);
			}

	}
	
	// Update is called once per frame
	void Update () {
		gameTime = Time.time - startTime;
	}
}
