using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class StateManager : MonoBehaviour {
    public static StateManager Instance;

    public enum GameState
    {
        Serve,
        Action,
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
        player1.SetActive(false);
        player2.SetActive(false);
        ball.SetActive(false);
        ModalDialog.Instance.Choice("Game over", "Rematch", "Menu", new UnityAction(Initialize), new UnityAction(() => { }));
    }

    public void Initialize()
    {
        _currentState = GameState.Serve;
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
	
	}

    PlayerBehavior GetPlayer(EPlayer player)
    {
        var playerObj = player == EPlayer.Player1 ? player1 : player2;
        return playerObj.GetComponent<PlayerBehavior>();
    }
}