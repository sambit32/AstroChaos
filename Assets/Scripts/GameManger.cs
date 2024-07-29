using System.Security.Cryptography;
using DialogueEditor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField] private GameObject astroidSpawner;
    // [SerializeField] private NPCConversation controlsNarrator;
    [SerializeField] private NPCConversation stroyNarrator;


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
        // controlsNarrator.gameObject.SetActive(false);
        stroyNarrator.gameObject.SetActive(true);
        ConversationManager.Instance.StartConversation(stroyNarrator);
        // controlsNarrator.gameObject.SetActive(true);
        gameON = false;
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
        score.value = 0;
        gameOverUI.gameObject.SetActive(false);
        astroidSpawner.SetActive(true);
        stroyNarrator.gameObject.SetActive(false);
        Time.timeScale = 1;
        StartTimer();
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

    // public void ControlsNarrator(){
    //     // stroyNarrator.gameObject.SetActive(false);
    //     // controlsNarrator.gameObject.SetActive(true);
    //     ConversationManager.Instance.StartConversation(controlsNarrator);
    // }

    public void BactToMain(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Try(){
        SceneManager.LoadScene("GamePlay");
    }
}
