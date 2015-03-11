using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour{


	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Player") {

			Debug.Log("FinishLevel");


				}
	}
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
