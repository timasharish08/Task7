using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;

    private CanvasGroup _group;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void Start()
    {
        _group.alpha = 0;
    }

    public void OnPlayerDied()
    {
        _group.alpha = 1;
        Time.timeScale = 0;
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
