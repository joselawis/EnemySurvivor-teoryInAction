using Assets.Lawis.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class IntroUiManager : UIManager<SceneUiManager>
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(InitGame);
    }

    public void InitGame()
    {
        SceneManager.LoadScene(1);
    }
}
