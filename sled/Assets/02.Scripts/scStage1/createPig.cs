using UnityEngine;
using System.Collections;

public class createPig : MonoBehaviour {
	private Transform tr;
	public GameObject pig;
	private float genTime = 2.0f;

	private float preTime;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		StartCoroutine (this.CreatePig ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator CreatePig(){
		Debug.Log("11");
		while (true) {
						if (Time.time - preTime >= genTime) {
								Debug.Log ("22");
								Instantiate (pig, tr.position, tr.rotation);
						}
				}
		yield return null;
	}
}
