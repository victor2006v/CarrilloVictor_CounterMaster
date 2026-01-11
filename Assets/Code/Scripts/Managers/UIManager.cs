using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Button playButton;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Start() {
        if (playButton != null) playButton.onClick.AddListener(PlayButtonPressed);
        progressBar.value = 0;
        gamePanel.SetActive(false);
        levelText.text = "Level " + (ChunkManager.Instance.GetCurrentLevel() + 1 );
    }

    private void Update() {
        UpdateProgressBar();
    }

    private void PlayButtonPressed() {
        GameManager.Instance.SetGameState(GameManager.GameState.GAME);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void UpdateProgressBar() {
        if (!GameManager.Instance.IsGameState()) return;
        float progress = PlayerController.Instance.transform.position.z / ChunkManager.Instance.GetFinishLineZ();
        progressBar.value = progress;
    }
}
