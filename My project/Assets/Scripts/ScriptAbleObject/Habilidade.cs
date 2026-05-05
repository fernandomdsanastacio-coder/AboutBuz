using UnityEngine;

[CreateAssetMenu(menuName = "Habilidade/Nova Habilidade")]
public class Habilidade : ScriptableObject
{
    public string nome;
    public string description;
    public Sprite imagem;
}
