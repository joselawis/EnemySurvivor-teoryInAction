using Assets.Lawis.Singleton;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private bool isGameActive = true;
    private Player player;
    private int points = 0;

    public bool IsGameActive { get => isGameActive; private set => isGameActive = value; }
    public Player Player { get => player; private set => player = value; }
    public int Points { get => points; private set => points = value; }

    protected override void Awake()
    {
        base.Awake();
        player = FindAnyObjectByType<Player>();
    }

    private void Start()
    {
        UpdatePointsUi();
    }

    private void UpdatePointsUi()
    {
        SceneUiManager.Instance.UpdatePoints(Points);
    }

    public void AddPoints(int points)
    {
        Points += points;
        UpdatePointsUi();
    }

    public void GameOver()
    {
        IsGameActive = false;
        SceneUiManager.Instance.ShowGameOver();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
