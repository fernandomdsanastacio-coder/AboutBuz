using UnityEngine;

public class GestorAbas : MonoBehaviour
{
    public GameObject PanelInventário;
    public GameObject PanelHabilidades;
    public GameObject PanelMapa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AbrirHabilidades();
    }

    public void AbrirHabilidades()
    {
        PanelHabilidades.SetActive(true);
        PanelMapa.SetActive(false);
        PanelInventário.SetActive(false);
    }
    public void AbrirInventario()
    {
        PanelHabilidades.SetActive(false);
        PanelMapa.SetActive(false);
        PanelInventário.SetActive(true);
    }
    public void AbrirMapa()
    {
        PanelHabilidades.SetActive(false);
        PanelMapa.SetActive(true);
        PanelInventário.SetActive(false);
    }
    
}
