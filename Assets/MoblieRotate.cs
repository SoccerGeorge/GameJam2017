using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoblieRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (SystemInfo.supportsGyroscope)
			transform.rotation = Input.gyro.attitude;
		else
			transform.rotation = Quaternion.Euler(Time.time * 10f, 0f, 0f);
	}
}
