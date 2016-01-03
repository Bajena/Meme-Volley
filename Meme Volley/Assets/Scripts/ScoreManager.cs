using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public EPlayer ballAt;

    private Dictionary<EPlayer, int> _score;

    public void Reset()
    {
        _score = new Dictionary<EPlayer, int>();
        _score[EPlayer.Player1] = 0;
        _score[EPlayer.Player2] = 0;
        UpdateScoreText();
    }

    public void PointLost(EPlayer player)
    {
        _score[OtherPlayer(player)]++;
        ballAt = OtherPlayer(player);
        UpdateScoreText();
        StateManager.Instance.ResetView();
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

    void UpdateScoreText()
    {
        
        scoreText.text = "Score: " + _score[EPlayer.Player1] + "-" + _score[EPlayer.Player2];
    }

    EPlayer OtherPlayer(EPlayer player)
    {
        return player == EPlayer.Player1 ? EPlayer.Player2 : EPlayer.Player1;
    }
}
