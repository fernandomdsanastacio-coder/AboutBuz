using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ApanharItem : MonoBehaviour
{
    public TMP_Text texto;
    public InputAction apanhar;
    [SerializeField] private GameObject player;
    bool entroutrigger=false;
    bool apanhou=false;
    bool podeclicar=true;
    bool menuAberto = false;
    public GameObject PanelHability;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        apanhar.Enable();
        PanelHability.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("estatua"))
        {
            if (apanhou==false)
                texto.gameObject.SetActive(true);
            entroutrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("estatua"))
        {
            
            texto.gameObject.SetActive(false);
            entroutrigger = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (apanhar.WasPressedThisFrame()&&entroutrigger)
        {
            Debug.Log("Ativou");
            agarrar agarrarscript = player.GetComponent<agarrar>();
            agarrarscript.enabled = true;
            apanhou=true;
            menuAberto = true;
            if(menuAberto&&podeclicar)
            {
                PanelHability.SetActive(true);
                Time.timeScale = 0f;
            }
            
        }
        if(apanhou)
        {
            texto.gameObject.SetActive(false);
            
        }
    }
      
    public void Click()
    {
        PanelHability.SetActive(false);
        Time.timeScale = 1f;
        menuAberto = false;
        podeclicar = false;
    }
}
