using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ClickToChat()
    {
        SceneManager.LoadScene("Chat", LoadSceneMode.Additive);
    }

    public void LoginGuest()
    {
        ;
    }
}
