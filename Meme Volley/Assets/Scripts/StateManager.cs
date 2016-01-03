using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () {
        Instance = this;
        _currentState = GameState.Serve;
        scoreManager.Reset();
        ResetView();
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