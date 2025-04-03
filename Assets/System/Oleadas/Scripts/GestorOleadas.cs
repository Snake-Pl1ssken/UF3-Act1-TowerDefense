using UnityEngine;

public class GestorOleadas : MonoBehaviour
{
    [SerializeField] GuionOleadas guionOleadas;
    [System.Serializable]
    public class LineaGuion
    {
        float espera;
        DefinicionOleada oleada;
    }
    [System.Serializable]
    public class GuionOleadas
    {
        LineaGuion[] lineas;
    }
}
