using UnityEngine;
using System.Collections;

public class PlaceTower : MonoBehaviour {

	public CalcCaminho calCam; // referencia ao script que calcula se o caminho dos minions eh valido
	public ButtonFade bFade; // script que mostra quando movimento eh invalido

	public int state = 0; // representa qual objeto eh mostrado no tabuleiro, 0 para quadrado de selecao

	public GameObject[] torres; // array de prefabs a se posicionar no jogo
	public Transform[] selecoes; // array de outline de torres a se posicionar


	void Update () {

		// manda um Raycast da camera para a posicao do mouse
		RaycastHit hit; 
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag == "Chao") { // caso acerte o chao do mapa

				Vector3 novoPos = RoundVector3 (hit.point); // posicao que os cursores assumem

				ResetaPos (); // reseta a posicao de todos os outlines
				selecoes [state].position = novoPos; // apenas o outline desejado recebe a posicao nova

				if (state != 0 && Input.GetMouseButtonDown (0)) { // caso nao seja o cursor basico selecionado, e o botao esquedo do mouse for apertado
					
					if (calCam.ChecaCaminho ()) { // Se certifica que tem caminho para os minions chegarem a chegada, nao estando bloqueado

						GlobalVars.money -= torres [state].GetComponent<Tower> ().custo; // tira o valor da torre do dinheiro od jogador

						Instantiate (torres [state], novoPos, Quaternion.identity);// Instancia a torre desejada no mundo

						state = 0; // cursor volta a ser o basico

					} else {
						bFade.FullVisible (); // caso o caminho esteja bloqueado, mostra uma mensagem na tela
					}
				}
			} else {
				if (Input.GetMouseButtonDown (0)) { // caso clique fora do campo

					state = 0; // cursor volta a ser o basico
				}
			}
		}
	}
		
	void ResetaPos(){ // coloca todos os cursores fora de visao da tela
		foreach (Transform trans in selecoes) {
			trans.position = new Vector3 (0, 100, 0);
		}
	}
		
	Vector3 RoundVector3(Vector3 vetorzinho){ // arredonda a posicao do mouse, para se alinhar todas as posicoes
		return new Vector3 (Mathf.Round (vetorzinho.x), Mathf.Round (vetorzinho.y), Mathf.Round (vetorzinho.z));
	}
		
	public void SetState(int novoState){ // Funcao chamado por botoes para definir qual torre vai ser posiconada
		state = novoState;
	}
}
