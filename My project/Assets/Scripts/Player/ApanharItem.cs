using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ApanharItem : MonoBehaviour
{
    public TMP_Text texto;
    public InputAction apanhar;
    [SerializeField] private GameObject player;
    bool entroutrigger=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        apanhar.Enable();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("estatua"))
        {
            texto.gameObject.SetActive(true);
            entroutrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("estatua"))
        {
            texto.gameObject.SetActive(false);
            entroutrigger= false;
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
        }
    }
}
