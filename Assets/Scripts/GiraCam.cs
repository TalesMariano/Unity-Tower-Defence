using UnityEngine;
using System.Collections;

public class GiraCam : MonoBehaviour {

	bool giroInicio = true; // para o efeito de girar a camera no inicio do jogo
	public float turnTime = 2; // quanto tempo leva para girar a camera pelo botao
	float tempTime = 3; // valor step para Slerp de angulo da camera, iniciado e 3 para nao forcar o Slerp
	Quaternion desireQuar; // a posicao do giro da camera quando completo

	void Start () {
		desireQuar = transform.rotation; // proxima posicao recebe a posicao inicial, para camera voltar a posicao inicial depois do efeito de giro
	}

	void Update () {

		if (giroInicio) {
			transform.Rotate(Vector3.up * -10 * Time.deltaTime); // Efeito de Rotacao da camera na tela inicial
		}

		if (tempTime < 2) {// para evitar ficar adicionado step sem motivo
			tempTime += Time.deltaTime / turnTime; // aumenta o step de acordo com o tempo definido
			transform.rotation = Quaternion.Slerp (transform.rotation, desireQuar, tempTime); // rotaciona a camera para proxima posicao, de maneira suave pelo Slerp
		}
	}

	public void Gira90(int maisUm){ // Funcao chamada pelos botoes de giro. MaisUm representa +1 ou -1, definindo a direcao do giro
		tempTime = 0; // zera o step para iniciar o giro
		desireQuar *= Quaternion.Euler (0, 45 * maisUm, 0); // proxima posicao do giro eh atualizada para prosicao desejada
	}

	public void ComecaJogo(){ // Funcao chamada pelo botao de inicio de jogo, para parar o giro automatico 
		giroInicio = false; // fim do gira da tela inicial
		tempTime = 0; // zera o step para iniciar o giro
	}
}
