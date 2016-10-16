using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonFade : MonoBehaviour {

	public float timeFade = 1; // o tempo que leva para o botao sumir
	float fading = 0; // representa o alpha das imagens

	public Image image; // Sprite do botao
	public Text text; // Texto do botao

	void Update () {
	
		if (fading > 0) {
			fading -= Time.deltaTime / timeFade; // reduz o alpha das imagem de acordo com o tempo
			Color tempCImg = image.color; // Cria e altera cor nova, pois unity nao altera propriedades das cores altomaticamente
			tempCImg.a = fading;
			image.color = tempCImg;

			Color tempCTxt = text.color;
			tempCTxt.a = fading;
			text.color = tempCTxt;
		}

	}

	public void FullVisible(){ // funcao chamada por outro script, para iniciar fading
		fading = 1;
	}
}
