using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HabilidadesUI : MonoBehaviour
{

    public Transform content;
    public GameObject slotpref;
    public Habilidade[] habilidades;
    public PanelDetalhes Panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Habilidade hab in habilidades)
        {
            GameObject slot = Instantiate(slotpref, content);
            slot.GetComponentInChildren<TMP_Text>().text = hab.nome;

            Habilidade habatual = hab;
            slot.GetComponent<Button>().onClick.AddListener(() =>
            {
                Panel.MostrarHabilidade(habatual);
            });
        }
    }
}
