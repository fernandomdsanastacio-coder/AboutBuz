using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PanelDetalhes : MonoBehaviour
{
    public TMP_Text Descrição;
    public Image imagem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MostrarHabilidade(Habilidade hab)
    {
        imagem.sprite = hab.imagem;
        Descrição.text = hab.description;
    }
}
