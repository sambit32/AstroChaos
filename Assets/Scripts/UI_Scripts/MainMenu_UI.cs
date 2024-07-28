using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public void loadNewGame(){
        SceneManager.LoadScene("GamePlay");
    }

    public void optionsMenu(){

    }

    public void Quit(){
        Application.Quit();
    }
}
