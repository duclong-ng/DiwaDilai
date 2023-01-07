using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform player;

	public float mixX, maxX;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			Vector3 temp = transform.position;
			temp.x = player.position.x + 2;

			if(temp.x < mixX){
				temp.x = mixX;
			}

			if(temp.x > maxX){
				temp.x = maxX;
			}
			transform.position = temp;
		}
	}
}
