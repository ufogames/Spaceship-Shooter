using UnityEngine;
using System.Collections;

public class probes: MonoBehaviour {

	//conversar com o script do player para poder pegar o transform
	private		player 			playerScript;
	private		_GC 			GCScript;

	//corpo do probe
	private	 	Rigidbody2D		probeRB;

	[Header("Moviment")]
	//variáveis de velocidade do inimigo
	public		float			velocidade;
	public 		float 			movimentX, movimentY;

	[Header("Life Probe")]
	//variáveis de vida do probe
	public		GameObject		explosionPrefab;
	public		int				HP;

	[Header("Ponctuation")]
	//variável de pontuação
	public		int				pointsProbe;

	//variável de verificação
	public		int 			visible;

	[Header("Loot")]
	//variáveis do loot
	public		GameObject		loot; 
	public		GameObject		loot2;
	public		int 			chanceDrop;
	private		int 			randomDrop;

	// Use this for initialization
	void Start () {
		//inicializando o Rigidbody do probe
		probeRB = GetComponent<Rigidbody2D> ();

		//inicializando o script do player
		playerScript = FindObjectOfType (typeof(player)) as player;

		//inicializando o script do GC
		GCScript = FindObjectOfType (typeof(_GC)) as _GC;
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		//função para fazer com que o probe siga o player
		if (playerScript == null){	
			//adicionando velocidade ao inimigo
			probeRB.velocity = new Vector2 (movimentX * velocidade, movimentY * velocidade);
		} else if (playerScript != null) {
			float step = velocidade * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, playerScript.transform.position, step);
		}
	}

	//função para detectar com colliders
	void OnCollisionEnter2D (Collision2D col){
		switch (col.gameObject.tag) {
			case "Player":
				dead ();
			break;
		}
	}

	//funão para detectar colisão com triggers
	void OnTriggerEnter2D (Collider2D col){
		switch (col.gameObject.tag) {
			case "laserPlayer":
				damage (1);
			break;
		}
	}

	//função para receber dano
	void damage(int getDamage){
		HP -= getDamage;
		if (HP <= 0) {
			dead ();
		}
	}

	//função para spawnar explosão ao morrer
	void dead(){
		GameObject tempExplosion = Instantiate (explosionPrefab) as GameObject;
		tempExplosion.transform.position = transform.position;
		tempExplosion.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 1);
		GCScript.points += pointsProbe;
		//linha para instanciar a explosão
		soundFX.playSound (sound.explosionProbe);

		//função para spawnar loot
		randomDrop = Random.Range (0, 100);

		if (randomDrop <= chanceDrop) {
			randomDrop = Random.Range (0, 100);
			if (randomDrop <= 95) {
				GameObject tempPrefabDrop = Instantiate (loot) as GameObject;
				tempPrefabDrop.transform.position = transform.position;
			} else if (randomDrop > 95) {
				GameObject tempPrefabDrop = Instantiate (loot2) as GameObject;
				tempPrefabDrop.transform.position = transform.position;
			}
		}

		//linha para destruir as partículas depois de 1 segundo
		Destroy (tempExplosion, 1);
		Destroy (this.gameObject);
	}
}