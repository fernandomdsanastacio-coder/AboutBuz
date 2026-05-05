
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class MenuPrincipal : MonoBehaviour
{
    public InputAction Abrirmenu;
    public GameObject PanelMenu;
    bool Panelaberto=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Abrirmenu.Enable();
        PanelMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Abrir Menu
        if (Abrirmenu.WasPressedThisFrame())
        {
            if (!Panelaberto)
            {
                PanelMenu.SetActive(true);
                Panelaberto = true;
                Debug.Log("aberto");
                Time.timeScale = 0f;
            }
            else if (Panelaberto)
            {
                PanelMenu.SetActive(false);
                Panelaberto = false;
                Debug.Log("fechado");
                Time.timeScale = 1f;
            }
        }
        
    }
}
