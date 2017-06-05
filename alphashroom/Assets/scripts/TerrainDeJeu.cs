using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDeJeu : MonoBehaviour {

    // Tableau de cellules
    private Transform[,] cells;
    private int[,] intTab =
        {
            {2,2,2,2,2},
            {2,1,1,1,2},
            {2,1,0,1,2},
            {2,1,1,1,2},
            {2,2,2,2,2}
        }
    ;

    //Position de depart
    private Vector3 positionDepart;

    //Type de cellules
    public Transform grassCell;
    public Transform caseEau;
    public Transform modelSurbrillance;
    private Transform surbrillance;

    // Use this for initialization
    void Awake() {
        cells = intTabToCells(intTab);
        surbrillance = Instantiate(modelSurbrillance) as Transform;
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
                switch(intTab[i, j])
                {
                    case 0:
                    case 1:
                        cells[i, j] = Instantiate(grassCell) as Transform;
                        break;
                    case 2:
                        cells[i, j] = Instantiate(caseEau) as Transform;
                        break;
                }
                Debug.Log("Cellule x : " + i + "y : " + j + " valeur : " + intTab[i, j]);
                Debug.Log("test x : " + tailleCase.x * (i + 1) + " y : " + tailleCase.y * (j + 1) + " z : " + tailleCase.z);
                cells[i, j].position = new Vector3(tailleCase.x * i, tailleCase.y * j, tailleCase.z);
                cells[i, j].gameObject.GetComponent<Case>().terrainDeJeu = this;
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

    public void bougerCaseSurbrillance(Vector3 position)
    {
        surbrillance.position = position;
    }
}
