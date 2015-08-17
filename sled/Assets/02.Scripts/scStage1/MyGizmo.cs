using UnityEngine;
using System.Collections;

public class MyGizmo : MonoBehaviour {
	public Color _color = Color.yellow;
	public float _radius;

	void OnDrawGizmos(){
		_radius = 1.0f;
		Gizmos.color = _color;

		Gizmos.DrawSphere (transform.position, _radius);
	}
}
