using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	// Variaveis Globais que podem ser acessadas por qualquer script sem referencia.

	static public float vida; // vida do jogador
	static public float money; // quantas moedas ele tem

	public float vidaInicial = 10; // define a vida inicial do jogador
	public float dinheiroInicial = 100; // define o dinheiro inicial do jogar

	void Start () {
		vida = vidaInicial; // aplica vida inicial
		money = dinheiroInicial; //aplica dinheiro inicial
	}
}
