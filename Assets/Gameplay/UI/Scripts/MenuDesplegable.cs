using UnityEngine;
using UnityEngine.Events;

public class MenuDesplegable : MonoBehaviour
{
    Canvas canvas;
    UnityEvent eventoParaLlamarAlOcultar;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>(true);
        gameObject.SetActive(false);
    }

    public void EstableceEvento(UnityEvent evento)
    {
        eventoParaLlamarAlOcultar = evento;
    }

    public void Mostrar()
    { 
        gameObject.SetActive(true);
    }

    public void Ocultar()
    {
        gameObject.SetActive(false);
        eventoParaLlamarAlOcultar?.Invoke();
    }
}
