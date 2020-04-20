using UnityEngine;
using System.Collections;

public class gunPlayer : MonoBehaviour {

	//variáveis da posição da arma e prefab do laser
	public		GameObject	laser;
	public		float		forceLaser;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//função para definir comando para atirar
		if (Input.GetButtonDown("Fire1")){
			Fire();
		}
	}

	//função para instaciar o prefab do laser ao atirar
	void Fire(){
		GameObject tempPrefab = Instantiate (laser) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, forceLaser));
		//linha para instanciar o som de tiro do player
		soundFX.playSound (sound.firePlayer);
	}
}
