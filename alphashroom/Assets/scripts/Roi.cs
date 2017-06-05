using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roi : MonoBehaviour {

    public Transform terrainDeJeu;
    public Vector2 speed = new Vector2(50, 50);

    // Use this for initialization
    void Start () {
        Vector3 positionInitiale = terrainDeJeu.gameObject.GetComponent<TerrainDeJeu>().donnerPositionDepart();
        transform.position = positionInitiale;
    }
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);
        transform.position += new Vector3(movement.x,movement.y,0);

    }
}
