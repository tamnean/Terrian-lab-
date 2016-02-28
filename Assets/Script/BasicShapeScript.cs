using UnityEngine;
using System.Collections;

public abstract class BasicShapeScript : MonoBehaviour {
	protected Rigidbody rigid;
	protected float jumpForce = 200f;
	private bool isGrounded;



	void Awake () { //If there isn't real there also call
		rigid = GetComponent<Rigidbody>();
	}

	public void Jump(){
		Jump (0f ,jumpForce ,0f);
	}

	public void Jump(float x,float y , float z){
		if (isGrounded) {
			rigid.AddForce(x,y,z);
		}
	}


	public bool IsPlayerNearBy(GameObject player){//detect distance
		float distance = (transform.position - player.transform.position).magnitude;
		if (distance < 10) {
			return true;
		}
		return false;
	}

	protected void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Terrain") {
			isGrounded = true;
		}
	}

	protected void OnCollisionExit(Collision other){
		if (other.gameObject.tag == "Terrain") {
			isGrounded = false;
		}
	}

	public abstract void interactWithPlayer(GameObject player);
}
