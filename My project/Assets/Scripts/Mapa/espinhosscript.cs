using UnityEngine;
using UnityEngine.SceneManagement;

public class espinhosscript : MonoBehaviour
{
    public Transform player;
    public int x;
    public int y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Playertag"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector3.zero;
            player.transform.position = (new Vector2 (x,y));
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
