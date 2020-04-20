using UnityEngine;
using System.Collections;

public class OnTimer : MonoBehaviour {

	public	float	tempLife;
	private	float	tempTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tempTime += Time.deltaTime;
		if (tempTime >= tempLife) {
			Destroy (this.gameObject);
		}
	}
}
