using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	//script do _GC
	private		_GC					_GC;

	//collider do player
	private		PolygonCollider2D	polyPlayer;

	//script dos probes
	private		probes				probes;

	//corpo do player
	private		Rigidbody2D			playerRB;

	[Header("Velocity")]
	//variáveis de movimentãção da nave
	public		float				velocidade;
	private		int					direcao;

	[Header("Explosion Prefab")]
	//vida da nave
	public		GameObject			explosionPrefab;

	//variável de verificação do probe
	public		bool				shower;

	[Header("Gun and Loot")]
	//powerUps
	public		GameObject			extraGun;
	public		GameObject			extraGun2;
	//public		GameObject			loot;
	private		int					addGun=1;

	// Use this for initialization
	void Start () {
		//inicializando o script do _GC
		_GC =  FindObjectOfType (typeof(_GC)) as _GC;

		//inicializando o script dos probes
		probes = FindObjectOfType (typeof(probes)) as probes;

		//inicializando o Rigidbody do player
		playerRB = GetComponent<Rigidbody2D> ();

		//inicializando o polygon
		polyPlayer = GetComponent<PolygonCollider2D> ();

		//atribuindo o nome ao objeto
		transform.name = "Player";

		//desativando collider e tempo de desativado
		polyPlayer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//função para ativar collider em alguns segundos depois de spawnado
		Invoke ("ColliderActivation", 3f);

		//funções de movimentação do player
		float movimentX	= Input.GetAxis ("Horizontal");
		float movimentY = Input.GetAxis ("Vertical");

		//definir limites de tela para movimento
		//transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -8.2f, 8.2f), Mathf.Clamp(transform.position.y, -8.11f, 8.11f));
		if (transform.position.x < -5.75f) {
			transform.position = new Vector3 (-5.75f, transform.position.y, transform.position.z);
		} else if (transform.position.x > 5.75f) {
			transform.position = new Vector3 (5.75f, transform.position.y, transform.position.z);
		}

		if (transform.position.y < -5.7f) {
			transform.position = new Vector3 (transform.position.x, -5.7f, transform.position.z);
		} else if (transform.position.y > 5.7f) {
			transform.position = new Vector3 (transform.position.x, 5.7f, transform.position.z);
		}


		//adicionando velocidade a nave
		playerRB.velocity = new Vector2 (movimentX * velocidade, movimentY * velocidade);

		if (movimentX > 0) {
			direcao = 1;
		} else if (movimentX == 0) {
			direcao = 0;
		} else if (movimentX < 0) {
			direcao = -1;
		}
	}

	//função para verificar colisão com triggers
	void OnTriggerEnter2D (Collider2D col){
		switch (col.gameObject.tag){
			case "laserEnemy":
				//função para desativar arma adicional ao receber dano
				if (addGun >= 1) {
					addGun -= 1;
				}

				if (addGun == 1) {
					extraGun.SetActive (false);
				} else if (addGun == 2) {
					extraGun2.SetActive (false);
				}
				
				if (addGun == 0) {
					dead ();
				}
			break;
			case "extraGun":
				if (addGun < 3) {
					addGun += 1;
				}
				powerUp ();
				_GC.points += 300;
				Destroy (col.gameObject);
			break;
			case "extraLife":
				_GC.lifes += 1;
				_GC.points += 300;
				Destroy (col.gameObject);
			break;
		}
	}

	//função para verificar colisão com colliders
	void OnCollisionEnter2D (Collision2D col){
		switch (col.gameObject.tag){
			case "Enemy":
				dead ();
			break;
		}
	}

	//função para os powerUps armas extras e vidas
	void powerUp(){
		//função para ativar as armas adicionais
		switch (addGun) {
			case 2:
				extraGun.SetActive (true);
			break;
			case 3:
				extraGun2.SetActive (true);
			break;
		}
	}

	//função para spawnar a animação de explosão ao morrer e powerUps
	void dead(){
		GameObject tempExplosion = Instantiate (explosionPrefab) as GameObject;
		tempExplosion.transform.position = transform.position;
		tempExplosion.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 1);
		_GC.dead ();

		//linha para instanciar o som de explosão
		soundFX.playSound (sound.explosionPlayer);

		//instanciando o powerUp quando o inimigo for destruído
		/*GameObject tempPrefabLoot = Instantiate (loot) as GameObject;
		tempPrefabLoot.transform.position = transform.position;*/

		//linha para destruir o objeto deposi do tempo escolhido
		Destroy (tempExplosion, 1);
		Destroy (this.gameObject);
	}
	
	//função para ativar o collider
	void ColliderActivation(){
		polyPlayer.enabled = true;
	}
}
