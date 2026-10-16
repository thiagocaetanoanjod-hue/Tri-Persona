using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScriptMenu : MonoBehaviour
{
    [SerializeField] private GameObject painelConfig;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelCredits;
    [SerializeField] private Scrollbar scrollVolume;
    [SerializeField] private Slider sliderMusica;
    [SerializeField] private TMP_Text textNome;
    [SerializeField] private TMP_InputField NovoNome;

    public void NovoJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void Configurar()
    {
        painelMenu.SetActive(false);
        painelConfig.SetActive(true);
    }

    public void VoltarCredits()
    {
        painelCredits.SetActive(false);
        painelMenu.SetActive(true);
    }

     public void VoltarConfig()
    {
        painelConfig.SetActive(false);
        painelMenu.SetActive(true);
    }

    public void Creditos()
    {
        painelCredits.SetActive(true);
        painelMenu.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void MudancaVolume()
    {
        Debug.Log(scrollVolume.value);
    }

    public void MudancaMusica()
    {
        Debug.Log(sliderMusica.value);
    }

    public void Nomear(TMP_InputField input)
    {
        NovoNome.text = input.text;
    }
}
