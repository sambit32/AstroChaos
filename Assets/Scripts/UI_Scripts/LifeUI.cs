using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public GameObject[] hearts;
    public Astronaut astronaut;
    void Start()
    {
        astronaut.OnDeathAction += Astronaut_OnDeathAction;
        for (int i = 0; i < hearts.Length; i++)
        {
            Show(i);
        }
    }

    private void Astronaut_OnDeathAction(object sender, Astronaut.OnDeathEventArgs e)
    {
        Hide(e.life);
    }

    void Hide(int index)
    {
        hearts[index].gameObject.SetActive(false);
    }

    void Show(int index)
    {
        hearts[index].gameObject.SetActive(true);
    }
}
