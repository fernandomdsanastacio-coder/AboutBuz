using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class NPCScript : MonoBehaviour
{
    public GameObject dialogopanel;
    public Text dialogotexto;
    public string[] dialogo;
    private int index;
    public float Speed;
    public bool playerperto;
    public GameObject button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&&playerperto)
        {
            if (dialogopanel.activeInHierarchy)
            {
                zerotexto();
            }
            else
            {
                dialogopanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if(dialogotexto.text == dialogo[index])
        {
            button.SetActive(true);
        }
    }
    public void zerotexto()
    {
        dialogotexto.text = "";
        index = 0;
        dialogopanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogo[index].ToCharArray())
        {
            dialogotexto.text += letter;
            yield return new WaitForSeconds(Speed);
        }
    }
    public void proximalinha()
    {
        button.SetActive(false);
        if (index < dialogo.Length-1)
        {
            index++;
            dialogotexto.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zerotexto();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Playertag"))
        {
            playerperto= true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Playertag"))
        {
            playerperto = false;
            zerotexto();
        }
    }
}
