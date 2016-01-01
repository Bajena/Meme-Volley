using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject ballAt;
    public GUIText scoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    public void Reset()
    {
        player1Score = 0;
        player2Score = 0;
        SetScoreText();
    }

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + player1Score + "-" + player2Score;
    }
}
