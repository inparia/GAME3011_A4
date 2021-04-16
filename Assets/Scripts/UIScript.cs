using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    private TMPro.TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Your Score : " + gameManager.score;
    }
}
