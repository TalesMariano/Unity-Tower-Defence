using UnityEngine;
using System.Collections;

public class CalcCaminho : MonoBehaviour {
	
	public Transform goal; // a chegada dos minios
	NavMeshAgent agent; // agente NavMesh
	private NavMeshPath path; // o caminho tracado

	void Start () {
		path = new NavMeshPath ();
		agent = GetComponent<NavMeshAgent> (); // puxa o componente do objeto
		agent.destination = goal.position; // o destino do objeto eh definida na chegada
	}

	public bool ChecaCaminho(){ // funcao chamada por outro script para checar se o caminho eh valido

		agent.CalculatePath (goal.position, path); // calcula se o caminho eh valido
		return (path.status == NavMeshPathStatus.PathComplete); // retorna se eh valido, se o calculo retornar PathComplete, eh valido. se for PathPartial ou PAthInvalid, nao eh

	}
}
