using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.GetComponentInParent<EnemyController>()){
			c.transform.parent.gameObject.SetActive(false);
		}
	}
}
