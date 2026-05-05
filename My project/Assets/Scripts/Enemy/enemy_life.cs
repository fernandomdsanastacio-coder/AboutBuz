using UnityEngine;

public class enemy_life : MonoBehaviour
{
    [SerializeField] private bool entrourange = false;
    public int vidaatual;
    public int vidamax = 3;
    bool sofreuatack=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaatual = vidamax;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("atackrange")||!sofreuatack)
        {
            vidaatual = vidaatual -1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("atackrange"))
            sofreuatack=true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
