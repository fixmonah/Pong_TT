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

    void Update()
    {
        levelLabel.text = string.Format($"Level: {GameController.instance.GetLevel()}");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrExit();
        }
    }

    private void PauseOrExit()
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

    public void CloseProgram()
    {
        Application.Quit();
    }
}
