using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	public Transform target;
	public float dist = 5.0f;
	public float height =5.0f;
	Vector3 pos;
	public Transform tr;


	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {


		Vector3 pos = target.position +Vector3.right*dist+Vector3.up * height;
		//tr.position.up = target.position.right +Vector3.up * height;// Vector3.right*dist+Vector3.up * height;

		tr.position  = Vector3.Lerp (tr.position, pos, Time.deltaTime * 10.0f);

		//tr.LookAt (target.position+Vector3.left*dist);
	}
}
