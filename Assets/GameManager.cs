using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TMP_Text datosAguante;
    [SerializeField] private float resistencia;
    [SerializeField] private GameObject derrotaCanvas;
    [SerializeField] private GameObject victoriaCanvas;

    private float cantidadEnemigos;
    private bool ultimoEnemigoCreado = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {

        if (resistencia <= 0)
            StartCoroutine(FinalPartida(false));

        if (resistencia <= 0)
            StartCoroutine(FinalPartida(true));

        datosAguante.text = $"Aguanta!: {resistencia}";

        Debug.Log(ultimoEnemigoCreado);
    }

    public void NotificaEnemigoCreado() 
    { 
        cantidadEnemigos++; 
    }

    public void NotificaEnemigoDestruido() 
    { 
        cantidadEnemigos--; 
    }

    public void NotificaEnemigoLlegaAlFinal() 
    { 
        resistencia--; 
    }

    public void NotificaUltimoEnemigoCreado() 
    { 
        ultimoEnemigoCreado = true; 
    }

    IEnumerator FinalPartida(bool victoria)
    {
        if (victoria)
        {
            victoriaCanvas.SetActive(true);
        }
        else
        { 
            derrotaCanvas.SetActive(true);
        }

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SampleScene");
    }
}
