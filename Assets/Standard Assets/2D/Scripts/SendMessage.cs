using UnityEngine;
using System.Collections;

public class SendMessage : MonoBehaviour {


	public delegate void PowerUpHandler (bool Ispoweredup);
	public static event PowerUpHandler myHandler;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
