using UnityEngine;
using System.Collections;

public class MySphere : BasicShapeScript {


	void Start () {
	
	}
	
	public override void interactWithPlayer(GameObject player){
		Vector3 force = player.transform.position - transform.position;
		rigid.AddForce (force);
	}
}
