using UnityEngine;

public class Torre : MonoBehaviour, IGolpeable
{
    [SerializeField] float resistencia;
    private barraDeVida _barraDeVida;
    private float resistenciaMax;

    private void Start()
    {
        resistenciaMax = resistencia;

        _barraDeVida = GetComponentInChildren<barraDeVida>();
        _barraDeVida.UpdateBarraDeVida(resistencia, resistenciaMax);
    }

    public void RecibeDanyo(float cantidad)
    {
        resistencia -= cantidad;
        _barraDeVida.UpdateBarraDeVida(resistencia, resistenciaMax);

        if (resistencia <= 0)
        { 
            Destroy(gameObject);
        }
    }

}
