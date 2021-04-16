using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{

    public Material matOne, matTwo, matThree, matFour;
    private TMPro.TextMeshPro textMesh;
    public bool cursorOn, ableToChoose;
    public GameManager gameManager;
    public string code;
    public bool chosen;
    // Start is called before the first frame update
    void Start()
    {
        cursorOn = false;
        ableToChoose = false;
        textMesh = GetComponentInChildren<TMPro.TextMeshPro>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        textMesh.text = code;
        chosen = false;
    }

    // Update is called once per frame
 

    void Update()
    {
        if (!chosen)
        {
            if (ableToChoose)
            {
                if (cursorOn)
                {
                    GetComponentInChildren<MeshRenderer>().material = matThree;
                }
                else
                {
                    GetComponentInChildren<MeshRenderer>().material = matTwo;
                }

            }
            else
            {
                GetComponentInChildren<MeshRenderer>().material = matOne;
            }
        }
        else
        {
            GetComponentInChildren<MeshRenderer>().material = matFour;
        }
    }

    private void OnMouseOver()
    {
        cursorOn = true;
    }

    private void OnMouseExit()
    {
        cursorOn = false;
    }

    private void OnMouseDown()
    {
        if(gameManager.turn != 4)
        { 
        chosen = true;
            if (ableToChoose)
            {
                switch (gameManager.turn)
                {
                    case 0:
                        resetTiles();
                        gameManager.playerAnswer[0] = code;
                        gameManager.turn = 1;
                        gameManager.firstI = (int)(gameObject.transform.position.x + (gameManager.gridSize / 2 - 0.5f));
                        if (code.Equals(gameManager.hackingAnswer[0]))
                        {
                            gameManager.rightAmount++;
                        }
                        break;
                    case 1:
                        resetTiles();
                        gameManager.playerAnswer[1] = code;
                        gameManager.turn = 2;
                        gameManager.firstJ = (int)(gameObject.transform.position.y + (gameManager.gridSize / 2 - 0.5f));
                        if (code.Equals(gameManager.hackingAnswer[1]))
                        {
                            gameManager.rightAmount++;
                        }
                        break;
                    case 2:
                        resetTiles();
                        gameManager.playerAnswer[2] = code;
                        gameManager.turn = 3;
                        gameManager.secondI = (int)(gameObject.transform.position.x + (gameManager.gridSize / 2 - 0.5f));
                        if (code.Equals(gameManager.hackingAnswer[2]))
                        {
                            gameManager.rightAmount++;
                        }
                        break;
                    case 3:
                        resetTiles();
                        gameManager.playerAnswer[3] = code;
                        gameManager.turn = 4;
                        if (code.Equals(gameManager.hackingAnswer[3]))
                        {
                            gameManager.rightAmount++;
                        }
                        break;
                }
            }
        }
    }

    void resetTiles()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("Tiles");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].GetComponent<GridScript>().ableToChoose = false;
        }
    }
}
