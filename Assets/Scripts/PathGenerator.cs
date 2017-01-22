using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour {

	public GameObject dot;
	[Range(-10f, 10f)]
	public float sinMultiplier = 1f;
	[Range(-10f, 10f)]
	public float cosMultiplier = 1f;
	[Range(-10f, 10f)]
	public float sinYMultiplier = 1f;
	[Range(-10f, 10f)]
	public float cosYMultiplier = 1f;
	[Range(-3f, 3f)]
	public float offsetX = 0f;
	[Range(0.1f, 5f)]
	public float offsetY = 0.1f;

	// Use this for initialization
	void Start () {
		for (int i=-2; i>-22; i--) {
			float x = sinMultiplier * Mathf.Sin((i * offsetY) * sinYMultiplier) + cosMultiplier * Mathf.Cos((i * offsetY) * cosYMultiplier) + offsetX;
			GameObject path = Instantiate(dot, new Vector3(x, (i * offsetY)), Quaternion.identity);
			path.name = string.Format("PathDot_{0}", i+2);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
