using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class StateManager : MonoBehaviour {
    public static StateManager Instance;

    public enum GameState
    {
        Action,
        Pause,
        End
    }

    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    public ScoreManager scoreManager;

    private GameState _currentState;

    public void ResetView()
    {
        player1.GetComponent<PlayerBehavior>().Respawn();
        player2.GetComponent<PlayerBehavior>().Respawn();
        ball.GetComponent<Ball>().Respawn(
            GetPlayer(scoreManager.ballAt).ballRespawnPoint.transform.position
        );
    }

    public void GameOver(EPlayer ballAt)
    {
        _currentState = GameState.End;
        player1.SetActive(false);
        player2.SetActive(false);
        ball.SetActive(false);
        ModalDialog.Instance.Choice("Game over", "Rematch", "Quit", new UnityAction(Initialize), new UnityAction(QuitGame));
    }

    public void Initialize()
    {
        _currentState = GameState.Action;
        scoreManager.Reset();

        player1.SetActive(true);
        player2.SetActive(true);
        ball.SetActive(true);
        ResetView();
    }

    // Use this for initialization
    void Start ()
    {
        Instance = this;
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Cancel") && _currentState == GameState.Action)
        {
            PauseGame();
        }
	}

    void PauseGame()
    {
        Time.timeScale = 0;
        _currentState = GameState.Pause;
        ModalDialog.Instance.Choice("Game paused", "Resume", "Exit", new UnityAction(ResumeGame), new UnityAction(QuitGame));
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        _currentState = GameState.Action;
    }

    void QuitGame()
    {
        Application.Quit();
    }

    PlayerBehavior GetPlayer(EPlayer player)
    {
        var playerObj = player == EPlayer.Player1 ? player1 : player2;
        return playerObj.GetComponent<PlayerBehavior>();
    }
}