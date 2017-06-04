using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roi : MonoBehaviour {

    public Transform terrainDeJeu;
    public float deplacementRate = 0.25f;
    private float attenteDeplacement;
    private bool bouge;
    private Vector3 direction;
    private Vector3 prochainePosition;

    // Use this for initialization
    void Start () {
        Vector3 positionInitiale = terrainDeJeu.gameObject.GetComponent<TerrainDeJeu>().donnerPositionDepart();
        transform.position = positionInitiale;

        attenteDeplacement = 0f;
        bouge = false;
    }
	
	// Update is called once per frame
	void Update () {
        // 3 - Retrieve axis information
        float inputY = Input.GetAxis("Horizontal");
        float inputX = Input.GetAxis("Vertical");

        if (peutBouger())
        {
            direction = Vector3.zero;
            if (inputX > 0)
            {
                direction += Vector3.up;
            }
            else if (inputX < 0)
            {
                direction += Vector3.down;
            }
            if (inputY < 0)
            {
                direction += Vector3.left;
            }
            else if (inputY > 0)
            {
                direction += Vector3.right;
            }

            if (!direction.Equals(Vector3.zero))
            {
                bouge = true;
                attenteDeplacement += deplacementRate;
                prochainePosition = transform.position + direction;
            }
        }

        if (bouge)
        {
            Vector3 mouvement = (direction * (Time.deltaTime)) / deplacementRate;
            transform.position += mouvement;

            if (attenteDeplacement <= 0f)
            {
                transform.position = prochainePosition;
                bouge = false;
            }
            else
            {
                attenteDeplacement -= Time.deltaTime;
            }

        }

    }

    private bool peutBouger()
    {
        return attenteDeplacement <= 0f && !bouge;
    }

}
