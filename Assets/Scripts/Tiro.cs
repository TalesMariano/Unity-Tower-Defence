using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

	public Transform target; // alvo que o tiro persegue
	public float radius = 0.8f; // qual a distacia entre o tiro e o alvo para se considerar uma colisao

	public float speed = 1; // velocidade do tiro
	public float dano = 1; // dano do tiro

	void Update () {
	
		float step = speed * Time.deltaTime; // atuliza o step do tiro
		transform.position = Vector3.MoveTowards(transform.position, target.position, step); // move o tiro em direcao ao alvo

		if (Vector3.Distance (transform.position, target.position) <= radius) { // se o tiro ja atingil o alvo
			target.SendMessage ("Hit", dano); // causa dano ao alvo
			Destroy(gameObject); //destroi o tiro
		}
	}

	public void SetDano(float novoDano){ // define o dano do tiro
		dano = novoDano;
	}

	public void SetAlvo(Transform alvo){ // define o alvo do tiro
		target = alvo;
	}
}
