using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VitoriaDerrota : MonoBehaviour {

	bool fimjogo = false; // para quando o jogo tiver acabado

	public GameObject objDerrota; // Mensagem de derrota
	public GameObject objVitoria; // Mensagem de vitoria

	void Update () {
	
		if (fimjogo && Input.anyKeyDown) { // se o jogo tiver acabado
			Time.timeScale = 1; // despausa o jogo
			Scene scene = SceneManager.GetActiveScene(); // Reinicia a cena
			SceneManager.LoadScene(scene.name); // Reinicia a cena
		}

		if (!fimjogo && GlobalVars.vida <= 0) { // caso o jogo nao tenha acabado e o jogador nao tenha mais vidas
			Derrota (); // ativa derrota
		}
	}

	public void Vitoria(){ // vitoria chamada pelo botao de vitoria
		Time.timeScale = 0; // pausa o jogo
		objVitoria.SetActive (true); // mostra mensagem de vitoria
		fimjogo = true; // ativa o fim de jogo
	}

	void Derrota(){
		Time.timeScale = 0; // pausa o jogo
		objDerrota.SetActive (true); // mostra mensagem de derrota
		fimjogo = true;// ativa o fim de jogo
	}
}
