using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


	Transform player;               // Reference to the player's position.
	public Transform goal;
	NavMeshAgent nav;               // Reference to the nav mesh agent.

	void Awake()
	{
		nav = GetComponent <NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update()
	{
		nav.SetDestination (player.position);
	}
}
