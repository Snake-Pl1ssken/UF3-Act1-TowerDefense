using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class GestorOleadas : MonoBehaviour
{
    [SerializeField] SplineContainer[] rutas;
    [SerializeField] GuionOleadas guionOleadas;
    [System.Serializable]
    public class LineaGuion
    {
        public float espera;
        public DefinicionOleada oleada;
    }
    [System.Serializable]
    public class GuionOleadas
    {
        [SerializeField] public LineaGuion[] lineas;
    }

    private void Start()
    {
        StartCoroutine(LeeGuion());
    }
    IEnumerator LeeGuion()
    {
        for (int i = 0; i < guionOleadas.lineas.Length; i++)
        {

            yield return new WaitForSeconds(guionOleadas.lineas[i].espera);
            StartCoroutine(LanzaOleda(guionOleadas.lineas[i].oleada));
        }
    }
    IEnumerator LanzaOleda(DefinicionOleada definicionOleada)
    {
        for (int i = 0; i < definicionOleada.bloques.Length; i++)
        {
            for (int j = 0;  j < definicionOleada.bloques[i].cantidad; j++)
            {
                yield return new WaitForSeconds(1f / definicionOleada.bloques[i].enemigosPorSegundo);
                int rutaAlAzarIdx = Random.Range(0, rutas.Length);
                //GameObject enemigo = Instantiate(definicionOleada.bloques[i].tipoEnemigos, 
                //    rutas[rutaAlAzarIdx].routePointArray[0], Quaternion.identity);
                //enemigo.GetComponent<Enemigo>().ruta = rutas[rutaAlAzarIdx];
            }
        }
    }
}
