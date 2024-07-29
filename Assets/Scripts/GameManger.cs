using DialogueEditor;
using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] private GameObject astroidSpawner;
    [SerializeField] private NPCConversation controlsNarrator;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI gameoverScoreText;
    private float time;
    private bool gameON;

    public IntegerVariable score;

    public static GameManger Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        score.Reset();
        astroidSpawner.SetActive(false);
        controlsNarrator.gameObject.SetActive(true);
        gameON = false;
        ConversationManager.Instance.StartConversation(controlsNarrator);
    }

    private void Update()
    {
        
        if (!gameON)
            return;
        time += Time.deltaTime;
        if(time >=3)
        {
            score.value += 2;
            time = 0;
        }
    }

    public void StartGame()
    {
        gameOverUI.gameObject.SetActive(false);
        astroidSpawner.SetActive(true);
        controlsNarrator.gameObject.SetActive(false);
        StartTimer();
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        gameON = false;
        astroidSpawner.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        gameoverScoreText.text = score.value.ToString();
        Time.timeScale = 0;
    }

    private void StartTimer()
    {
        time = 0f;
        gameON = true;
    }
}
