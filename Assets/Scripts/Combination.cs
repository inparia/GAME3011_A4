using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    // Start is called before the first frame update
    public int combinations;
    private TMPro.TextMeshProUGUI textMesh;
    public GameManager gameManager;
    private bool pointTaken;
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        pointTaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(combinations)
        {
            case 2:
                textMesh.text = "2 Combination : " + gameManager.hackingAnswer[0] + " / " + gameManager.hackingAnswer[1];
                if (gameManager.playerAnswer[0] != null && gameManager.playerAnswer[1] != null)
                {
                    if (gameManager.playerAnswer[0].Equals(gameManager.hackingAnswer[0]) && gameManager.playerAnswer[1].Equals(gameManager.hackingAnswer[1]))
                    {
                        textMesh.color = Color.blue;
                        if(!pointTaken)
                            gameManager.score += 50;

                        pointTaken = true;
                    }
                    else
                    {
                        textMesh.color = Color.red;
                    }
                }
                else
                {
                    textMesh.color = Color.black;
                }

                break;
            case 3:
                textMesh.text = "3 Combinations : " + gameManager.hackingAnswer[0] + " / " + gameManager.hackingAnswer[1] + " / " + gameManager.hackingAnswer[2];
                if (gameManager.playerAnswer[0] != null && gameManager.playerAnswer[1] != null && gameManager.playerAnswer[2] != null)
                {
                    if (gameManager.playerAnswer[0].Equals(gameManager.hackingAnswer[0]) && gameManager.playerAnswer[1].Equals(gameManager.hackingAnswer[1]) && gameManager.playerAnswer[2].Equals(gameManager.hackingAnswer[2]))
                    {
                        textMesh.color = Color.blue;
                        if (!pointTaken)
                            gameManager.score += 100;

                        pointTaken = true;
                    }
                    else
                    {
                        textMesh.color = Color.red;
                    }
                }
                else
                {
                    textMesh.color = Color.black;
                }
                break;
            case 4:
                textMesh.text = "4 Combinations : " + gameManager.hackingAnswer[0] + " / " + gameManager.hackingAnswer[1] + " / " + gameManager.hackingAnswer[2] +" / " + gameManager.hackingAnswer[3];
                if (gameManager.playerAnswer[0] != null && gameManager.playerAnswer[1] != null && gameManager.playerAnswer[2] != null && gameManager.playerAnswer[3] != null)
                {
                    if (gameManager.playerAnswer[0].Equals(gameManager.hackingAnswer[0]) && gameManager.playerAnswer[1].Equals(gameManager.hackingAnswer[1]) && gameManager.playerAnswer[2].Equals(gameManager.hackingAnswer[2]) && gameManager.playerAnswer[3].Equals(gameManager.hackingAnswer[3]))
                    {
                        textMesh.color = Color.blue;
                        if (!pointTaken)
                            gameManager.score += 200;

                        pointTaken = true;
                    }
                    else
                    {
                        textMesh.color = Color.red;
                    }
                }
                else
                {
                    textMesh.color = Color.black;
                }
                break;
        }
    }
}
