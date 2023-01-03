using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ControlTextos : MonoBehaviour
{
    [SerializeField] public GameObject Exclamation_Red;
    [SerializeField] private GameObject dialogePanel;
    [SerializeField] private TMP_Text DialogoPrincipal;
    [SerializeField] private TMP_Text DialogoSecundario;
    [SerializeField, TextArea(2, 6)] private string[] arrayTextos;

    public bool DestroyItem;
    public MovHorizontal movJugador;
    public Jump salto;
    public Animator animacion;
    public Rigidbody2D rb;
    bool isPlayerInRange;
    bool didDialogeStart;
    bool controlDialogo = true;
    private int LineIndex;

    
    private void Update()
    {
        if (isPlayerInRange && controlDialogo)
        {
            if (!didDialogeStart)
            {
                ActivarTexto();
            }
            else if (DialogoPrincipal.text == arrayTextos[LineIndex] && Input.GetButtonDown("Jump"))
            {
                SiguienteFrase();
            }

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Iniciar dialogo");
            rb.velocity = new Vector2(0, 0);
            Exclamation_Red.SetActive(true);
            isPlayerInRange = true;

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Quitar dialogo");
            isPlayerInRange = false;
            controlDialogo = false;

        }
    }   

    public void ActivarTexto()
    {
        didDialogeStart = true;
        dialogePanel.SetActive(true);
        Exclamation_Red.SetActive(false);
        LineIndex = 0;
        movJugador.enabled = false;
        salto.enabled = false;
        animacion.enabled = false;
        StartCoroutine(MostrarCaracteres());
    }

    public void SiguienteFrase()
    {
        LineIndex++;
        if(LineIndex < arrayTextos.Length)
        {
            controlDialogo = true;
            StartCoroutine(MostrarCaracteres());
        }
        else if (Input.GetButtonDown("Jump"))
        {
            didDialogeStart = false;
            dialogePanel.SetActive(false);
            Exclamation_Red.SetActive(true);
            controlDialogo = false;
            movJugador.enabled = true;
            salto.enabled = true;
            animacion.enabled = true;
            if (DestroyItem)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator MostrarCaracteres ()
    {
        DialogoPrincipal.text = string.Empty;
        foreach (char caracter in arrayTextos[LineIndex])
        {
            DialogoPrincipal.text += caracter;
            yield return new WaitForSecondsRealtime(0.02f); //Para que espere con segundo reales 
        }
    }

}
 