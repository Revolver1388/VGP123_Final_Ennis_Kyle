using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState { play, pause, end, winState };
    public GameState currentState = GameState.play;
    private static GameManager Instance;
    public GameObject pauseUI;
    public GameObject player;
    public GameObject endUI;
    public GameObject collect;
    public GameObject winUI;
   

    public static GameManager GetInstance()
    {
        return Instance;
        }

    // Use this for initialization
    void Start() {
        if (Instance)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.play:
                Play();
                break;
            case GameState.pause:
                Pause();
                break;
            case GameState.end:
                end();
                break;
            case GameState.winState:
                winning();
                break;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (currentState == GameState.play)
            {
                currentState = GameState.pause;
            }
            else if (currentState == GameState.pause)
            {
                pauseUI.SetActive(false);
                currentState = GameState.play;
            }

        }

        if (playerControls.instance.win == true)
        {
            if (currentState == GameState.play)
            {
                currentState = GameState.winState;
            }
            else if (currentState == GameState.winState)
            {
                currentState = GameState.play;
            }
        }

        if ( playerControls.instance.endgame == true )
        {
            if (currentState == GameState.play)
            {
                currentState = GameState.end;
            }
            else if (currentState == GameState.end)
            {
                currentState = GameState.play;
            }
        }
    }

    void Play()
    {
        endUI.SetActive(false);
        playerControls.instance.enabled = true;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    void Pause()
    {
        playerControls.instance.enabled = false;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    void end()
    {
        endUI.SetActive(true);
        Time.timeScale = 0;
    }

    void winning()
    {
        winUI.SetActive(true);
        Time.timeScale = 0;
    }
}
