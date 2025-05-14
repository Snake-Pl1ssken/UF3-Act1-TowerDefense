using UnityEngine;
using UnityEngine.Events;

public class MenuDesplegable : MonoBehaviour
{
    [SerializeField] GameObject panelTorres;
    [SerializeField] GameObject panelTorreArquero;
    [SerializeField] GameObject panelTorreMagica;
    [SerializeField] GameObject panelTorreBombas;

    UnityEvent eventoParaLlamarAlOcultar;

    private Cimiento cimiento;

    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    private void Awake()
    {
        panelTorres.SetActive(false);
        panelTorreArquero.SetActive(false);
        panelTorreMagica.SetActive(false);
        panelTorreBombas.SetActive(false);

        cimiento = GetComponentInParent<Cimiento>();
    }

    public void EstableceEvento(UnityEvent evento)
    {
        eventoParaLlamarAlOcultar = evento;
    }

    public void Mostrar()
    {
        if (!cimiento.HayTorreConstruida())
        {
            panelTorres.gameObject.SetActive(true);
        }
        else if (cimiento.TipoTorre() == "TorreArqueros")
        {
            panelTorreArquero.gameObject.SetActive(true);
        }
        else if (cimiento.TipoTorre() == "TorreMagica")
        {
            panelTorreMagica.gameObject.SetActive(true);
        }
        else if (cimiento.TipoTorre() == "TorreCanyones")
        { 
            panelTorreBombas.gameObject.SetActive(true);
        }
    }

    public void Ocultar()
    {
        panelTorres.gameObject.SetActive(false);
        panelTorreArquero.gameObject.SetActive(false);
        panelTorreMagica.gameObject.SetActive(false);
        panelTorreBombas.gameObject.SetActive(false);

        eventoParaLlamarAlOcultar?.Invoke();
    }
}
