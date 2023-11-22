using DG.Tweening;
using Root.Systems.GameRunner;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private MaskableGraphic _mainPanel;
    [SerializeField] private MaskableGraphic _label;

    [SerializeField] private float _labelDelay = 2f;
    [SerializeField] private float _labelDuration = 1f;

    [SerializeField] private float _panelDelay = 0.5f;
    [SerializeField] private float _panelDuration = 0.75f;

    [Inject] private IGameRunnerSystem _gameRunnerSystem;

    private bool IsFirstLaunch
    {
        get { return PlayerPrefs.GetInt("is_first_launch", 1) == 1; }
        set { PlayerPrefs.SetInt("is_first_launch", value ? 1 : 0); }
    }

    private void Start()
    {
        if (IsFirstLaunch)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(_labelDelay);
            sequence.Append(_label.DOFade(0f, _labelDuration));
            sequence.AppendInterval(_panelDelay);
            sequence.AppendCallback(() => _gameRunnerSystem.BeginGame());
            sequence.Append(_mainPanel.DOFade(0f, _panelDuration));
            sequence.Play();
            
            IsFirstLaunch = false;
        }
        else
        {
            _label.gameObject.SetActive(false);
            _mainPanel.gameObject.SetActive(false);
            _gameRunnerSystem.BeginGame();
        }
    }

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
