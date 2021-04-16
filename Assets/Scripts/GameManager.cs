using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    EASY,
    NORMAL,
    HARD
}
public class GameManager : MonoBehaviour
{
    public GameObject hackingTile;
    public int gridSize;
    public GameObject[,] hackingGrid;
    public GameLevel gameLevel;
    public GameObject panel, testPanel;
    public string[] playerAnswer;
    public string[] hackingAnswer;
    public string[,] hackingCode;
    private string[] hackingCodeGenerator = new string[] { "AG", "ER", "AS", "GF", "FD", "BB" };
    public int turn, firstI, firstJ, secondI, rightAmount, score;
    public TMPro.TextMeshProUGUI endText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkGamePlay();
        if(turn == 4)
        {
            endText.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void easyGrid()
    {
        panel.SetActive(false);
        testPanel.SetActive(true);
        gameLevel = GameLevel.EASY;
        createPlanes();
    }

    public void normalGrid()
    {
        panel.SetActive(false);
        testPanel.SetActive(true);
        gameLevel = GameLevel.NORMAL;
        createPlanes();
    }

    public void hardGrid()
    {
        panel.SetActive(false);
        testPanel.SetActive(true);
        gameLevel = GameLevel.HARD;
        createPlanes();
    }

    public void resetPlanes()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("Tiles");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        createPlanes();
    }
    void createPlanes()
    {
        endText.gameObject.SetActive(false);
        firstI = 0;
        firstJ = 0;
        secondI = 0;
        rightAmount = 0;
        turn = 0;
        score = 0;
        playerAnswer = new string[4];
        hackingAnswer = new string[4];

        for(int i = 0; i < 4; i++)
        {
            int tempNum = Random.Range(0, 6);
            hackingAnswer[i] = hackingCodeGenerator[tempNum];
        }

        switch (gameLevel)
        {
            case GameLevel.EASY:
                gridSize = 4;
                break;
            case GameLevel.NORMAL:
                gridSize = 5;
                break;
            case GameLevel.HARD:
                gridSize = 6;
                break;
        }
        

        hackingGrid = new GameObject[gridSize, gridSize];
        hackingCode = new string[gridSize, gridSize];

        int codeOne = Random.Range(0, gridSize);
        int codeTwo = gridSize - 1 - Random.Range(1, gridSize);
        int codeThree = codeOne + Random.Range(1 - codeOne, gridSize - codeOne);

        while(codeThree == codeOne)
        {
            codeThree = codeOne + Random.Range(1 - codeOne, gridSize - codeOne);
        }

        int codeFour = codeTwo + Random.Range(1 - codeTwo, gridSize - codeTwo);

        while (codeFour == codeTwo)
        {
            codeFour = codeOne + Random.Range(1 - codeOne, gridSize - codeOne);
        }


        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                int tempNum = Random.Range(0, 6);
                hackingCode[i, j] = hackingCodeGenerator[tempNum];
            }

        }

        hackingCode[codeOne, gridSize - 1] = hackingAnswer[0];
        hackingCode[codeOne, codeTwo] = hackingAnswer[1];
        hackingCode[codeThree, codeTwo] = hackingAnswer[2];
        hackingCode[codeThree, codeFour] = hackingAnswer[3];

        //for (int i = (int)gridSize - 1; i >= 0; i--)
        //{
        //    hackingCode[i, codeOne] = hackingAnswer[0];
        //}



        for (int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                hackingGrid[i, j] = (GameObject)Instantiate(hackingTile, new Vector3(i - (gridSize / 2 - 0.5f), j - (gridSize / 2 - 0.5f), 0), Quaternion.identity);
                hackingGrid[i, j].GetComponent<GridScript>().code = hackingCode[i, j];
            }
        }
    }

    void checkGamePlay()
    {
        switch (turn)
        {
            case 0:
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (j == gridSize - 1)
                        {
                            hackingGrid[i, j].GetComponentInChildren<GridScript>().ableToChoose = true;
                        }
                    }
                }
                break;
            case 1:
                for (int i = firstI; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (i == firstI)
                        {
                            hackingGrid[i, j].GetComponentInChildren<GridScript>().ableToChoose = true;
                        }
                    }
                }
                break;
            case 2:
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = firstJ; j < gridSize; j++)
                    {
                        if (j == firstJ)
                        {
                            hackingGrid[i, j].GetComponentInChildren<GridScript>().ableToChoose = true;
                        }
                    }
                }
                break;
            case 3:
                for (int i = secondI; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (i == secondI)
                        {
                            hackingGrid[i, j].GetComponentInChildren<GridScript>().ableToChoose = true;
                        }
                    }
                }
                break;
        }
    }
}
