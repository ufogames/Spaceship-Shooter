using UnityEngine;
using System.Collections;

//classe para instanciar os audios para outros scripts
public enum sound{
	firePlayer, fireEnemy, explosionPlayer, explosionHeavyEnemy, explosionLightEnemy, explosionProbe
}

public class soundFX : MonoBehaviour {

	//variáveis de audio
	public 			AudioClip		fireP, fireE;
	public			AudioClip		explosionP, explosionHE, explosionLE, explosionPro;
	private			AudioSource 	audio;
	public static	soundFX 		instance;

	// Use this for initialization
	void Start () {
		//inicializando o AudioSource
		audio = GetComponent<AudioSource> ();

		//referencia ao próprio script
		instance = this;
	}

	//função para definir cara audio
	public static void playSound (sound currentSound){
		switch (currentSound) {
			case sound.firePlayer:
				instance.audio.PlayOneShot (instance.fireP);
			break;
			case sound.explosionPlayer:
				instance.audio.PlayOneShot (instance.explosionP);
			break;
			case sound.fireEnemy:
				instance.audio.PlayOneShot (instance.fireE);
			break;
			case sound.explosionHeavyEnemy:
				instance.audio.PlayOneShot (instance.explosionHE);
			break;
			case sound.explosionLightEnemy:
				instance.audio.PlayOneShot (instance.explosionLE);
			break;
			case sound.explosionProbe:
				instance.audio.PlayOneShot (instance.explosionPro);
			break;
		}
	}
}
