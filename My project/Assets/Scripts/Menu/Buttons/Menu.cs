using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject PanelOpt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void Options()
    {
        PanelMenu.SetActive(false);
        PanelOpt.SetActive(true);
    }
    public void Leave()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
