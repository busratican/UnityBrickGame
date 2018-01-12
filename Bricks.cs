using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	
	public GameObject brickParticle;
	public GameObject enemyPrefab;
	Vector3 brickPos;



	void OnCollisionEnter (Collision other)
	{
		Instantiate(brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBrick();
		if (gameObject.name == "BricksEnemy") 
		{
			brickPos=new Vector3(gameObject.transform.position.x,
			                 gameObject.transform.position.y,
			                 gameObject.transform.position.z);

			Instantiate(enemyPrefab, brickPos, Quaternion.identity);
		}
		Destroy(gameObject);


	}
	
}