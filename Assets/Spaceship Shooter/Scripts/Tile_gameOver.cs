using UnityEngine;
using UnityEngine.UI;

public class Tile_gameOver : MonoBehaviour {

	//variável dos pontos
	public	Text	points;

	// Use this for initialization
	void Start () {
		points.text = "RECORDE: "+PlayerPrefs.GetInt ("recorde").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
