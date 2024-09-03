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
    public float tempoEntreLetras = 0.08f;

    void Awake()
    {
        TryGetComponent(out componenteTexto);
        TryGetComponent(out _audioSource);
        mensagemOriginal = componenteTexto.text;
        componenteTexto.text = "";
    
    }

    void OnEnable()
    {
        ImprimirMensagem(mensagemOriginal);
    }

    void OnDisable()
    {
        componenteTexto.text = mensagemOriginal;
        StopAllCoroutines();
    }

    public void ImprimirMensagem(string mensagem)
    {    
        if(gameObject.activeInHierarchy)
        {
            if(imprimindo) return;
            imprimindo = true;
            StartCoroutine(LetraPorLetra(mensagem));
        }
    }

    IEnumerator LetraPorLetra(string mensagem)
    {
        string msg = "";

        foreach(var letra in mensagem)
        {
            msg += letra;
            componenteTexto.text = msg;
            _audioSource.Play();
            yield return new WaitForSeconds(tempoEntreLetras);
        }

        imprimindo = false;
        StopAllCoroutines();
    }
}
