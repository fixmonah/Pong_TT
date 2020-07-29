using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject StartGame;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject Game;
    
    [SerializeField] private Text levelLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelLabel.text = String.Format($"Level: {GameController.instance.GetLevel()}");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (StartGame.activeSelf)
            {
                CloseProgram();
            }
            else
            {
                Pause.SetActive(true);
            }
        }
    }

    public void CloseProgram()
    {
        Application.Quit();
    }
}
