using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
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
        textMesh.text = "Timer : " + (int)(gameManager.remainingTime + 1);
    }
}

