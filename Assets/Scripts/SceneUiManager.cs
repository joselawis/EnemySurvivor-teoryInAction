using Assets.Lawis.UI;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(1000)]
public class SceneUiManager : UIManager<SceneUiManager>
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Canvas gameOverCanvas;

    public void UpdateHealth(float healthPoints)
    {
        healthText.text = $"Health: {healthPoints}";
    }

    public void UpdatePoints(int points)
    {
        pointsText.text = $"Points: {points}";
    }

    public void ShowGameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }
}
