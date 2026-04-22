using UnityEngine;
using UnityEngine.SceneManagement;

public class espinhosscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Playertag"))
        {
            SceneManager.LoadScene("tutorial");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
