using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour {

	bool alive = true; // se o minion se encontra vivo no momento

	public float vida; // a vida inicial do minion
	public float pseudoVida; // pseudo vida, para que nao se atirem em minions ja mortos
	public float recompensa = 1; // recompensa em moedas para quando o jogador mata um minion


	public Transform goal; // destido de chegada do minion
	NavMeshAgent agent; // agente de navegacao NavMesh

	AudioSource asource; // Audio source que emite efeitos sonoros do minion

	void Start () {
		pseudoVida = vida; // atualiza apseudo vida do minion

		agent = GetComponent<NavMeshAgent>(); // Recebe componemte de navegacao
		agent.destination = goal.position; // define o destino de navegacao

		asource = GetComponent<AudioSource>(); // Recebe componemte de audio
	}

	void Update () {

		if (alive && vida <= 0) // caso esteja vivo e vida caia para abaixo de zero
			Die ();
	}


	public void SetChegada(Transform chegadada){ // Funcao chamada por outro script para definir chegada do minion
		goal = chegadada;
	}

	void Die(){ // funcao de morte do inimigo
		alive = false; // nao esta mais vivo, para evitar repeticao de codigo

		agent.speed = 0; // freia o minion quando morre

		asource.pitch = Random.Range (0.9f, 1.1f); // altera o pitch do som randomicamente para nao soar muito repetitivo
		asource.Play (); // toca o choro de morte do minion


		// mudar para reciclar
		Destroy (gameObject, 0.7f); // destroi o objeto em pouco menos de 1 segundo, para ter tempo de tocar todo audio 
		GlobalVars.money += recompensa; // adiciona a recompensa ao dinheiro do jogaros
	}

	public void Hit(float dano){ // causa dano ao minion, chamado por outros scripts
		vida -= dano;
	}
}
