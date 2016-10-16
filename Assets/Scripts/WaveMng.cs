using UnityEngine;
using System.Collections;

public class WaveMng : MonoBehaviour {

	public int waveAtual=0; // qual a wave atual em jogo
	public int progressao = 0; // progressao em casa nova wave
	public int valorWave; //  Valor inical da wave // esse valor deve ser o MDC entre os numeros de valor de minios

	public GameObject[] prefMinions; // Prefabs dos minios, colocados do menor para o maior valor
	public int[] valorMinions; // valor dos minions

	public Transform chegada; // chegada dos minios

	int numeroDeSpawns; // quanto minios sao intanciados nessa wave

	public void CalculaWave(){ // Calcula e inicia a proxima wave, iniciado pelo bota
		
		waveAtual++; // adiciona 1 no numero da wave
		valorWave += progressao; // adiociona progressao ao valor da wave

		for (int i = prefMinions.Length-1; i >=0; ) { // Loop de repeticao do menor para o mairo

			if (valorWave % valorMinions [i] == 0) { // se o valor dessa wave eh dividido inteiramente pelos valores dos minions
				numeroDeSpawns = valorWave / valorMinions [i]; // define quantos minions vao vir nessa wave

				StartCoroutine (SpawnMinions (i, numeroDeSpawns)); // inicia a geracao de minions

				break; //quebra o looping

			} else { // se o valor do minion maior nao serve, passa para o proximo
				i--; // continua o looping
			}
		}
	}

	IEnumerator SpawnMinions(int qualMinion, int quantosMinions){  // inicia a wave, definindo qual minion vem e quantos deles
		for (int i = 0; i < quantosMinions; i++) {  // repete de acordo com o numero de minions na wave
			GameObject minion = Instantiate (prefMinions[qualMinion] ,transform.position, transform.rotation) as GameObject; // Instancia o minios
			minion.SendMessage ("SetChegada", chegada); // DEfine sua chegada
			yield return new WaitForSeconds (1); // aguarda 1 segundo para dar distancia para gerar outro minion
		}
	}
}
