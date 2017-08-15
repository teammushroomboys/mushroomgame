using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainDeJeu : MonoBehaviour
{

    public Sprite[] terrain;

    private Vector2 leftBottomBorder, rightTopBorder;
    private GameObject[,] cells;
    private Vector3 tailleCase;
    private int[,] intTab =
        {
            {0,1,1,1,1,1,1,1,1,2},
            {13,9,9,9,9,9,9,9,9,15},
            {13,9,9,9,9,9,9,9,9,15},
            {13,9,9,9,9,9,9,9,9,15},
            {13,9,9,9,9,9,9,9,9,15},
            {13,9,9,9,9,9,9,9,9,15},
            {13,9,9,9,9,9,9,9,9,15},
            {13,9,9,9,9,9,9,9,9,15},
            {13,9,9,9,9,9,9,9,9,15},
            {26,27,27,27,27,27,27,27,27,28},

        }
    ;

    // Use this for initialization
    void Awake()
    {
        leftBottomBorder = new Vector2(0, 0);
        rightTopBorder = new Vector2(intTab.GetLength(0) - 1, intTab.GetLength(0) - 1);

        tailleCase = terrain[0].bounds.size;

        intTabToCells();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Transform[,] intTabToCells()
    {
        cells = new Transform[intTab.GetLength(0), intTab.GetLength(1)];

        for (int i = 0; i < intTab.GetLength(0); i++)
        {
            for (int j = 0; j < intTab.GetLength(1); j++)
            {
                Vector3 newPosition = new Vector3(tailleCase.x * i, tailleCase.y * j, transform.position.z);
                GameObject object = Instantiate(terrain[0]) as GameObject;
                cells[i, j] = Instantiate(terrain[0]) as GameObject;
            //     GameObject spellBolt;
            //  spellBolt = Instantiate(spells[0], transform.position, transform.rotation) as GameObject;
            //  spellBolt.transform.position = transform.position;


                cells[i, j] = Instantiate(terrains[1]) as Transform;
                cells[i, j].position = new Vector3(tailleCase.x * i, tailleCase.y * j, transform.position.z);
            }
        }

        return cells;
    }

    public Vector2 GetLeftBottomBorder()
    {
        return leftBottomBorder;
    }

    public Vector2 GetRightTopBorder()
    {
        return rightTopBorder;
    }
}
