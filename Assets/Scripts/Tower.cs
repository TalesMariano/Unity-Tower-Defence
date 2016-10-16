using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public float custo; // o custo em moedas para se criar a torre
	public float dano = 1; // quanto dano ela cauda
	public float atkSpeed = 1; // quanto tiros cria por segundo
	float cdTiro = 0; // tempo entre tiros
	Minion tempMinion; // minion alvo no momento

	AudioSource asource; // Audio de efeito de tiro

	public GameObject areaTiro; // area de alcance do tiro

	public Transform transArma; // objeto arma
	public GameObject prefabTiro; // prefab de tiro
	float armaTurn = 15; // velocidade de giro da arma

	void Start () {
		asource = GetComponent<AudioSource>(); // Recebe componete de audio
	}
		
	void Update () {
	
		cdTiro -= Time.deltaTime; // diminue o tempo entre tiros

		if (tempMinion != null) { // caso tenha alvo para atirar
			Vector3 targetDir = tempMinion.transform.position - transArma.position; // direcao de mira da arma
			float step = armaTurn * Time.deltaTime; // step de gira da arma
			Vector3 newDir = Vector3.RotateTowards(transArma.forward, targetDir, step, 0.0F); // roda em direcao ao alvo
			transArma.rotation = Quaternion.LookRotation(newDir); // roda em direcao ao alvo

			if ( tempMinion.pseudoVida>0) { // caso o minion ainda tenha pseudo vida
				if (cdTiro <= 0) { // arma esteja pronta para atirar
					tempMinion.pseudoVida -= dano; // diminue a pseudo vida do minion
					Atira (); // atira 
					cdTiro = 1/atkSpeed; // reseta a espera para atirar novamente
				}
			}
		}
	}

	public void Atira(){ // atira com a arma
		GameObject tiro = Instantiate (prefabTiro,transArma.position, transArma.rotation) as GameObject; // instancia o tiro
		asource.pitch = Random.Range (0.95f, 1.05f); // muda o pitch do som para evitar repeticao
		asource.Play (); // toca o som de tiro
		tiro.SendMessage ("SetAlvo", tempMinion.transform); // define o alvo do tiro
	}

	void OnMouseEnter(){ // caso o mouse passe por cima da torre, mostra a area de ataque
		areaTiro.SetActive (true);
	}

	void OnMouseExit(){ // desliga a area de ataque visivel
		areaTiro.SetActive (false);
	}

	void OnTriggerStay(Collider other){ // enquanto tiverem objetos em sua area de ataque

		if (tempMinion == null && other.tag == "Minion") { // se nao tiver nenhum alvo e tiver um minion para atacar
			tempMinion = other.GetComponent<Minion> (); // define alvo
		}
	}

	void OnTriggerExit(Collider other){
		if (other.GetComponent<Minion> () == tempMinion) { // caso o minion alvo saia do alcance
			tempMinion = null; // sem mais alvo
		}
	}
}
