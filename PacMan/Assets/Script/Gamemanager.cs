using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    Gamemanager _instance;

    public Ghost [] _ghosts;
    public Pacman _pacman;

    public int _score{get;private set;}
    public int _lives{get;private set;}

    public Transform _pellets;
    private void Awake() 
    {

    }

    private void Start()
    {
        NewGame();
    }


    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void Update()
    {
        if(this._lives <=0 && Input.GetKey(KeyCode.Space))
        {
            NewGame();
        }
    }

    private void NewRound()
    {
        foreach (Transform item in this._pellets)
        {
            item.gameObject.SetActive(true);
        }
        ResetState();
    }
    private void ResetState()
    {
        for (int i = 0; i < _ghosts.Length; i++)
        {
            this._ghosts[i].gameObject.SetActive(true);
        }
        this._pacman.gameObject.SetActive(true);        
    }

    private void GameOver()
    {
        for (int i = 0; i < _ghosts.Length; i++)
        {
            this._ghosts[i].gameObject.SetActive(false);
        }
        this._pacman.gameObject.SetActive(false);            
    }

    private void SetScore(int score)
    {
        this._score = score;
    }
    private void SetLives(int lives)
    {
        this._lives = lives;
    }

    /// <summary>
    /// Public perchè verrà triggerata daglis cript esterni
    /// </summary>
    /// <param name="ghost"></param>

    public void GhostEaten(Ghost ghost)
    {
        SetScore(this._score + ghost._point);
    }

    /// <summary>
    /// Public perchè verrà triggerata daglis cript esterni
    /// </summary>
    public void PacmanEaten()
    {
        this._pacman.gameObject.SetActive(false);
        SetLives(this._lives - 1);
        if(this._lives > 0)
        {
            //lancio la funzione dopo 3 secondi di attesa
            Invoke(nameof(ResetState),3.0f);
        }
        else
        {
            GameOver();
        }
        
    }
}
