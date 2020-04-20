using UnityEngine;
using System.Collections;

public class gunEnemy : MonoBehaviour {

	//variáveis de ataque da nave
	public		GameObject	laserEnemy;
	public		float 		forceFireX, forceFireY;
	private		float 		tempTimeFire;
	public		float 		tempFire;
	public		int 		CF;

	//varíaveis de IA inimiga
	private	int			rand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//função de atirar do inimigo
		tempTimeFire += Time.deltaTime;
		if (tempTimeFire >= tempFire) {
			tempTimeFire = 0;
			rand = Random.Range (0, 100); //0 - 99
			if (rand <= CF) {
				fire ();
			}
		}
	}

	//função para o inimigo atirar
	void fire(){
		GameObject tempPrefab = Instantiate (laserEnemy) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (forceFireX, forceFireY));
		//linha para instanciar o som de tiro do inimigo
		soundFX.playSound (sound.fireEnemy);
	}
}
