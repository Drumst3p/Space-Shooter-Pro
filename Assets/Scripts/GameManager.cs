using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    private void Update()
        {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
            {
            // loading the game scene
            SceneManager.LoadScene(1);
            }
        if(Input.GetKeyDown(KeyCode.Escape) && _isGameOver == true)
            {
            Debug.Log("Quit requested!");
            Application.Quit();
            }
        }

    public void GameOver()
        { 
        _isGameOver = true;
        }
}
