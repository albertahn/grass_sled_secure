using UnityEngine;
using System.Collections;

public class pigCtrl : MonoBehaviour {

	private Transform tr;
	public float moveSpeed = 5.0f;

	private Transform playerTr;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		playerTr = GameObject.FindWithTag ("PLAYER").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (tr.position,playerTr.position);
		if (dist <= 25) {
						moveSpeed = 0;
				} else {
			moveSpeed=5.0f;
				}
		tr.Translate (Vector3.forward*Time.deltaTime*moveSpeed,Space.Self);
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "WALL") {

			//Debug.Log("pig here man");

			Destroy(this.gameObject);
		}
	}
}
