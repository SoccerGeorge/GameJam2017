using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoblieRotate : MonoBehaviour {

	public float speedPos = 1.0f;
	public float speedRot = 1.0f;
	public float speedUpMultiplierDefault = 1.75f;
	public float pathTolerance = 0.5f;
	public int scoreAddition = 5;
	public Camera cam;
	public float camLimit = -64;
	public GameObject explosion;
	public PathGenerator pathGen;
	public TextMesh scoreTxt;
	float speedUpMultiplier;
	Vector3 initPos;
	Quaternion initRot;
	Vector3 initCamPos;
	GameObject explosionInstance;
	bool stopUpdatingCam = false;

	public int currentScore { get; set; }

	// Use this for initialization
	void Start () {
		speedUpMultiplier = speedUpMultiplierDefault;
		initPos = transform.position;
		initRot = transform.rotation;
		initCamPos = cam.transform.position;
		currentScore = 0;
	}

	// Update is called once per frame
	void Update () {
		// Don't run if paused
		if (Time.timeScale == 0) return;

		transform.Translate(0f, -(Time.deltaTime * speedUpMultiplier), 0f, Space.World);
#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(-(Time.deltaTime), 0f, 0f, Space.World);
		if (Input.GetKey(KeyCode.RightArrow))
			transform.Translate((Time.deltaTime), 0f, 0f, Space.World);
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.Rotate(0f, 0f, (Time.deltaTime * 8f), Space.World);
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.Rotate(0f, 0f, -(Time.deltaTime * 8f), Space.World);
		}
#else
		transform.Translate(Input.acceleration.x * (Time.deltaTime * speedPos), 0f, 0f, Space.World);
		transform.Rotate(0f, 0f, -Input.acceleration.y * (Time.deltaTime * speedRot), Space.World);
		scoreTxt.text = -Input.acceleration.y.ToString("F4");
#endif
		if (transform.rotation.eulerAngles.z > 180f) {
			Quaternion rot = Quaternion.Euler(0f, 0f, 0f);
			transform.rotation = rot;
		}
		else if (transform.rotation.eulerAngles.z > 90f) {
			Quaternion rot = Quaternion.Euler(0f, 0f, 90f);
			transform.rotation = rot;
		}

		if (transform.position.x < -10f) {
			transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
		}
		else if (transform.position.x > 10f) {
			transform.position = new Vector3(10f, transform.position.y, transform.position.z);
		}

		speedUpMultiplier = Mathf.Abs(transform.rotation.eulerAngles.z / 30f) * speedUpMultiplierDefault;
		if (speedUpMultiplier < speedUpMultiplierDefault)
			speedUpMultiplier = speedUpMultiplierDefault;

		if (!stopUpdatingCam)
			cam.transform.Translate(0f, -(Time.deltaTime * speedUpMultiplier), 0f, Space.World);
		
		if (cam.transform.position.y < camLimit) {
			cam.transform.position = new Vector3(initCamPos.x, camLimit, initCamPos.z);
			stopUpdatingCam = true;
		}

		UpdateScore();
		//scoreTxt.text = currentScore.ToString();
	}

	public void OnButton () {
		transform.position = initPos;
		transform.rotation = initRot;
		cam.transform.position = initCamPos;
		stopUpdatingCam = false;
		currentScore = 0;
		gameObject.SetActive(true);
		if (explosionInstance != null)
			Destroy(explosionInstance);
	}

	void OnTriggerEnter2D (Collider2D other) {
		explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}

	void UpdateScore () {
		if (transform.position.y > -pathGen.startOffset) return;

		if (Mathf.Abs(transform.position.y % pathGen.offsetY) < 0.5f) {
			float currentPathPosX = pathGen.GetPathLocation(transform.position.y);
			float posXDiff = Mathf.Abs(currentPathPosX - transform.position.x);
			if (posXDiff < pathTolerance) {
				currentScore += scoreAddition;
			}
			else if (posXDiff < pathTolerance * 2f) {
				currentScore += scoreAddition/2;
			}
		}
	}
}
