using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roi : MonoBehaviour {

    public Vector2 speed = new Vector2(20, 20);

    private Vector2 movement;

    void Start () {
        // Position de départ aléatoire selon la taille de la carte (Pour l'instant en dur)
        transform.position = new Vector3(Random.Range(0, 4), Random.Range(0, 4), transform.position.z);
    }
	
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);
    }
    
    /**
    FixedUpdate possède un temps fixe entre chaque execution contrairement à update qui varie entre chacune de ses executions
    (si le jeu ram par exemple).
    Cette méthode existe exprès pour tout ce qui concerne la physique (Les RigidBody)

    source : https://unity3d.com/fr/learn/tutorials/topics/scripting/update-and-fixedupdate
    */
    void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
