using UnityEngine;
using System.Collections;

public class spawnHeavyEnemy : MonoBehaviour {

	//variável para receber o prefab do inimigo
	public 		GameObject		enemy, enemy2;

	//variáveis para receber o tempo de spawn, posições e tempo
	public		float 			delay;
	public		Transform 		up;
	public		float 			tempTime;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		tempTime += Time.deltaTime;
		if (tempTime >= delay) {
			tempTime = 0;
			spawn ();
		}
	}

	//função para instanciar o prefab do inimigo na posição desejada
	void spawn(){
		float rand = Random.Range (0, 100);
		if (rand <= 25) {
			GameObject tempSpawn = Instantiate (enemy) as GameObject;
			tempSpawn.transform.position = up.transform.position;
			tempSpawn.name = "Heavy Enemy 1";
		}
		if (rand >= 75) {
			GameObject tempSpawn = Instantiate (enemy2) as GameObject;
			tempSpawn.transform.position = up.transform.position;
			tempSpawn.name = "Heavy Enemy 2";
		}
	}
}
