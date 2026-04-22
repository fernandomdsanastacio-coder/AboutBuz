using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class passagemscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Playertag"))
        {
            SceneManager.LoadScene("Capital");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
