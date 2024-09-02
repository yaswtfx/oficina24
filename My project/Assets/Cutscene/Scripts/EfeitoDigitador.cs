using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class NewBehaviourScript : MonoBehaviour
{
    private TextMeshProUGUI componenteTexto;
    private AudioSource _audioSource;
    private string mensagemOriginal;
    public bool imprimindo;

    void Awake()
    {
        TryGetComponent(out componenteTexto);
        TryGetComponent(out _audioSource);
        mensagemOriginal = componenteTexto.text;
        componenteTexto = "";
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {
        componenteTexto.text = mensagemOriginal;
    }

    public void ImprimirMensagem(string mensagem)
    {

    }

    IEnumerator LetraPorLetra(string mensagem)
    {
        string msg = "";

        foreach(var letra in mensagem)
        {
            msg += letra;
            componenteTexto.text = mensagem;
        }
    }
}
