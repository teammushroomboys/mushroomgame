using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDeJeu : MonoBehaviour {

    // Tableau de cellules
    private Transform[,] cells;
    private int[,] intTab =
        {
            {1,2,3},
            {4,5,6},
            {7,0,9},
        }
    ;

    //Position de depart
    private Vector3 positionDepart;

    //Type de cellules
    public Transform grassCell;

    // Use this for initialization
    void Awake() {
        cells = intTabToCells(intTab);
    }

    // Update is called once per frame
    void Update() {

    }

    private Transform[,] intTabToCells(int[,] intTab) {
        Transform[,] cells = new Transform[intTab.GetLength(0), intTab.GetLength(1)];
        Vector3 tailleCase = (grassCell.GetComponent<SpriteRenderer>().bounds.size);


        for (int i = 0; i < intTab.GetLength(0); i++)
        {
            for (int j = 0; j < intTab.GetLength(1); j++)
            {
                cells[i, j] = Instantiate(grassCell) as Transform;
                Debug.Log("Cellule x : " + i + "y : " + j + " valeur : " + intTab[i, j]);
                Debug.Log("test x : " + tailleCase.x * (i + 1) + " y : " + tailleCase.y * (j + 1) + " z : " + tailleCase.z);
                cells[i, j].position = new Vector3(tailleCase.x * i, tailleCase.y * j, tailleCase.z);
                if (intTab[i, j] == 0)
                {
                    positionDepart = new Vector3(tailleCase.x * i, tailleCase.y * j, tailleCase.z);
                }
            }
        }


        return cells;
    }

    public Vector3 donnerPositionDepart()
    {
        return positionDepart;   
    }

}
