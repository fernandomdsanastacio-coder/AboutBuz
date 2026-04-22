
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class SairOps : MonoBehaviour
{
    public Slider volumemusicaS;
    public Slider volumeSFXS;
    public Toggle fullscreenT;
    

    public GameObject PanelOps;
    public GameObject PanelMenu;
    //Todas as Soluções do monitor
    private Resolution[] resolutions;
    public void X()
    {
        PanelOps.SetActive(false);
        PanelMenu.SetActive(true);
    }
    void Start()
    {
        //mostra o valor que o jogador tinha antes
        volumemusicaS.value = PlayerPrefs.GetFloat("VolumeM", 1f);//1f valor padrão
        volumeSFXS.value = PlayerPrefs.GetFloat("VolumeSFX", 1f);//SFX

        fullscreenT.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;//==1 tranforma o 1 e o 0 em true ou false, é começado em 1 porque os jogadores gostam mais de começar em fullscreen
    
        
    
    }
    
    public void OnApplyButton()//o valor muda no slider mas só quando clicar no butão
    {
        //Volume aplicado
        PlayerPrefs.SetFloat("VolumeM", volumemusicaS.value);
        PlayerPrefs.SetFloat("VolumeSFX", volumeSFXS.value);

        Screen.fullScreen = fullscreenT.isOn;
        PlayerPrefs.SetInt("Fullscreen", fullscreenT.isOn ? 1 : 0);//converte a bool em numero para guardar no PlayerPrefs



        PlayerPrefs.Save();//necessário porque sem ele quando o jogo crashar ele não guardaria, a unity só guarda quando fecha o jogo
    }
    
    
}
