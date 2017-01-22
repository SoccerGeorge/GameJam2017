using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour {

	public GameObject dot;
	[Range(-3f, 3f)]
	public float sinMultiplier = 1f;
	[Range(-3f, 3f)]
	public float cosMultiplier = 1f;
	[Range(-3f, 3f)]
	public float sinYMultiplier = 1f;
	[Range(-3f, 3f)]
	public float cosYMultiplier = 1f;
	[Range(-1f, 1f)]
	public float offsetX = 0f;
	public float offsetY = 0.1f;
	public int numDots = 20;
	public int startOffset = 2;

	// Use this for initialization
	void Start () {
		GeneratePath();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float GetPathLocation (float posY) {
		return sinMultiplier * Mathf.Sin(posY * sinYMultiplier) + cosMultiplier * Mathf.Cos(posY * cosYMultiplier) + offsetX;
	}

	public void GeneratePath () {
		while (transform.childCount > 0) {
			foreach (Transform child in transform) {
				GameObject.DestroyImmediate(child.gameObject);
			}
		}

		for (int i=startOffset; i<(numDots+startOffset); i++) {
			float x = sinMultiplier * Mathf.Sin((-i * offsetY) * sinYMultiplier) + cosMultiplier * Mathf.Cos((-i * offsetY) * cosYMultiplier) + offsetX;
			GameObject pathDot = Instantiate(dot, new Vector3(x *3f, (-i * offsetY)), Quaternion.identity);
			pathDot.name = string.Format("PathDot_{0}", i - startOffset);
			pathDot.transform.parent = transform;
		}
	}
}
