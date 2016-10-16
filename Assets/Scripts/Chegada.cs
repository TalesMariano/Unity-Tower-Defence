using UnityEngine;
using System.Collections;

public class Chegada : MonoBehaviour {

	void OnTriggerEnter(Collider other){ // para quando os minions alcancarem a chegada
		if (other.tag == "Minion") { // verifica se eh um minion
			other.GetComponent<Minion> ().pseudoVida = 0; // define a pseudo vida como 0 para evitar novos tiros

			GlobalVars.vida -= 1;// reduz a vida do jogador em 1
			Destroy(other.gameObject, 2); // destroi o minion em 2 segundos, garantindo que todos os tiros a caminho dele cheguem a tempo
		}
	}
}
