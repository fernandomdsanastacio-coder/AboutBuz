
using TMPro;
using UnityEngine;


public class GrabScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public Transform target;
    [SerializeField] private TMP_Text texto;

    private agarrar FirstGrabbool;

    private void Start()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Playertag"))
        {
            
            //Procura o script agarrar no player - primeiro no próprio objeto, depois no pai e depois nos filhos
            agarrar agarrarscript = other.GetComponent<agarrar>()
                ?? other.GetComponentInParent<agarrar>()//?? significa "se for null, tenta o seguinte"
                ?? other.GetComponentInChildren<agarrar>();// igual
            if (agarrarscript == null)
            {
                Debug.Log("nao encontrado");// ainda não aconteceu
                return;
            }
            if (agarrarscript.Grab == null)
            {
                agarrarscript.Grab = transform;
            }

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Playertag"))
        {

            agarrar agarrarscript = other.GetComponent<agarrar>()
               ?? other.GetComponentInParent<agarrar>()//?? significa "se for null, tenta o seguinte"
               ?? other.GetComponentInChildren<agarrar>();

            if (agarrarscript == null) return;

            if (agarrarscript.Grab == transform)
            {
                agarrarscript.Grab = null;
            }
        }
    }
}
