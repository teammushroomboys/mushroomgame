using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour {

    public TerrainDeJeu terrainDeJeu;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        Debug.Log("On entre dans une case");
        Roi roi = otherCollider.GetComponent<Roi>();
        if(roi != null)
        {
            Debug.Log("On entre dans une case");
            terrainDeJeu.bougerCaseSurbrillance(transform.position);
        }
    }

}
