using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Splines;

public class Enemigo : MonoBehaviour, IGolpeable
{
    public SplineContainer ruta;
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float vida = 1f;
    [SerializeField] private float vidaMaxima = 2f;
    [SerializeField] private barraDeVida _barraDeVida;
    [SerializeField] private float umbralLlegada = 1f;

    float distanciaEntrePuntos = 5f;
    Vector3[] pathPointsCache;
    Vector3 PosicionSiguiente;
    int indiceSiguientePosicion = 1;

    public void EstablecerRuta(SplineContainer r)
    {
        ruta = r;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float longitudRuta = ruta.CalculateLength();
        int cantidadPuntos = Mathf.CeilToInt(longitudRuta / distanciaEntrePuntos) + 1;

        pathPointsCache = new Vector3[cantidadPuntos];
        for (int i = 0; i < cantidadPuntos; i++)
        {
            float t = (float)i / (float)cantidadPuntos;
            pathPointsCache[i] = ruta.EvaluatePosition(t);
        }

        transform.position = pathPointsCache[0];
        PosicionSiguiente = pathPointsCache[indiceSiguientePosicion];

        vida = vidaMaxima;
        _barraDeVida.UpdateBarraDeVida(vida, vidaMaxima);
        GameManager.Instance.NotificaEnemigoCreado();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = PosicionSiguiente - transform.position;
        Vector3 velocidadMovimiento = direccion.normalized * velocidad;
        transform.position += velocidadMovimiento * Time.deltaTime;

        if (Vector3.Distance(PosicionSiguiente, transform.position) < umbralLlegada)
        {
            indiceSiguientePosicion++;
            if (indiceSiguientePosicion == pathPointsCache.Length)
            {
                Destroy(gameObject);
                GameManager.Instance.NotificaEnemigoLlegaAlFinal();
            }
            else
            { 
                PosicionSiguiente = pathPointsCache[indiceSiguientePosicion];
            }
        }
    }
    public void RecibeDanyo(float cantidad)
    {
        vida -= cantidad;

        if (vida > 0)
        {
            _barraDeVida.UpdateBarraDeVida(vida, vidaMaxima);
        }
        else
        {
            GameManager.Instance.NotificaEnemigoDestruido();
            Destroy(this.gameObject);        
        }
    }

    private void OnDestroy() 
    { 
        GameManager.Instance.NotificaEnemigoDestruido(); 
    }
}
