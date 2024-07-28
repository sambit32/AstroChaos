using DialogueEditor;
using UnityEngine;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation npcConversation;

    private void Start()
    {
        ConversationManager.Instance.StartConversation(npcConversation);
    }
    /*private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                ConversationManager.Instance.StartConversation(npcConversation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("press esc to talk");
        }
    }*/
}
