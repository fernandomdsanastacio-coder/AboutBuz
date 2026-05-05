using UnityEngine;

public class player_life : MonoBehaviour
{
    [SerializeField] private bool entrourange=false;
    public int vidaatual;
    public int vidamax=5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaatual = vidamax;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy") && !entrourange)
        {
            vidaatual = vidaatual - 1;
            entrourange = true;
        }
    }
    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("enemy") && entrourange)
            entrourange = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
