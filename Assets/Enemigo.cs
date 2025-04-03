using UnityEngine;
using UnityEngine.Splines;

public class Enemigo : MonoBehaviour
{
    [SerializeField] public SplineContainer ruta;
    [SerializeField] float velocidad = 5f;
    [SerializeField] float vida = 1f;
    
    [SerializeField] float umbralLlegada = 1f;

    float distanciaEntrePuntos = 5f;
    Vector3[] pathPointsCache;
    Vector3 PosicionSiguiente;
    int indiceSiguientePosicion = 1;

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
            }
            else
            { 
                PosicionSiguiente = pathPointsCache[indiceSiguientePosicion];
            }
        }
    }
}
