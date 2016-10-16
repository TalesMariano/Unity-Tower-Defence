using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {

	public Text textoVidas; // texto que exibe quantas vidas o jogador tem
	public Text textoMoedas; // texto que exibe quantas moedas o jogador tem
	public Text textoWave; // texto que mostra em qual wave o jogador se encontra

	public WaveMng waveMng; // referencia para o script de waves

	public Button[] botoes; // array dos botoes de gerar torre
	public int[] valores; // valores das torres // mesma quantidade de itens do que o array acima

	void Update () {

		textoVidas.text = "Vidas: " + GlobalVars.vida; // atualiza texto vidas

		textoMoedas.text = "Moedas: " + GlobalVars.money; // atualiza texto moedas

		textoWave.text = "Wave: " + waveMng.waveAtual; // atualiza texto Waves

		for (int i = 0; i < botoes.Length; i++) { // Loop que ativa e desativa os botoes caso se tenho moedas suficiemtes para compralos

			if( valores[i] <= GlobalVars.money)
				botoes [i].interactable = true;
			else
				botoes [i].interactable = false;

		}
	}
}
