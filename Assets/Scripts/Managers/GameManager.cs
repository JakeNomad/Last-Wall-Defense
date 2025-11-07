using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject targetDoor;
    public TextMeshProUGUI gameOverText;
    private bool isGameOver = false;

    void Start()
    {
        gameOverText.enabled = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.enabled = true;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
