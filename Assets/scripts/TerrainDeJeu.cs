using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDeJeu : MonoBehaviour {

    // Tableau de cellules
    private Transform[,] cells;
    private int[,] intTab =
        {
            {1,1,2,2,1,1,1,1,1,1},
            {1,1,1,2,1,1,1,1,1,1},
            {1,1,1,2,2,1,1,1,1,1},
            {1,1,1,2,2,2,1,1,1,1},
            {1,1,1,1,2,2,1,1,1,1},
            {1,1,1,1,2,2,2,1,1,1},
            {1,1,1,1,2,2,2,2,1,1},
            {1,1,1,1,1,2,2,2,2,1},
            {1,1,1,1,1,1,1,2,2,2},
            {1,1,1,1,1,1,1,1,1,1},
 
        }
    ;

    // Type de cellules
    public Transform grassCell;
    public Transform waterCell;

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
                switch(intTab[i, j])
                {
                    case 1:
                        cells[i, j] = Instantiate(grassCell) as Transform;
                        break;
                    case 2:
                        cells[i, j] = Instantiate(waterCell) as Transform;
                        break;
                }
                cells[i, j].position = new Vector3(tailleCase.x * i, tailleCase.y * j, transform.position.z);
            }
        }


        return cells;
    }
}
