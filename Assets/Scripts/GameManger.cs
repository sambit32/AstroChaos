using System.Security.Cryptography;
using DialogueEditor;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField] private GameObject astroidSpawner;
    // [SerializeField] private NPCConversation controlsNarrator;
    [SerializeField] private NPCConversation stroyNarrator;


    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private TextMeshProUGUI gameoverScoreText;
    private float time;
    private bool gameON;

    public IntegerVariable score;

    public static GameManger Instance;

    private const string playerPrefConversationCheck = "CONVERSATION";
    private void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        score.Reset();
        astroidSpawner.SetActive(false);
        // controlsNarrator.gameObject.SetActive(false);
        if(!PlayerPrefs.HasKey(playerPrefConversationCheck))
        {
            stroyNarrator.gameObject.SetActive(true);
            ConversationManager.Instance.StartConversation(stroyNarrator);
            gameON = false;
            SetPlayerPref();
            return;
        }
        StartGame();
        // controlsNarrator.gameObject.SetActive(true);
        

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
        StartTimer();
        //gameOverUI.gameObject.SetActive(false);
        astroidSpawner.SetActive(true);
        stroyNarrator.gameObject.SetActive(false);
        
    }

    public void StopGame()
    {
        gameON = false;
        astroidSpawner.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        gameoverScoreText.text = score.value.ToString();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetPlayerPref()
    {
        PlayerPrefs.SetInt(playerPrefConversationCheck, 1);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }
}
