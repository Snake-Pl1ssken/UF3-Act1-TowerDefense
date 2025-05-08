using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    [SerializeField] float radioDeteccion;
    [SerializeField] float radioPerdidaObjetivo;
    [SerializeField] List<string> tagsObjetivos;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] float tiempoEntreProyectiles;
    [SerializeField] Transform origenProyectil;
    [SerializeField] float alturaSaltoProyectil;

    Transform objetivo;

    float tiempoParaSiguienteProyectil = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivo == null)
        {
            GestionAdquisicionObjetivo();
        }
        else
        {
            GestionPerdidaObjetivo();
        }

        tiempoParaSiguienteProyectil -= Time.deltaTime;
        //if (tiempoParaSiguienteProyectil < 0) { tiempoParaSiguienteProyectil = 0; }
        tiempoParaSiguienteProyectil = Mathf.Clamp(tiempoParaSiguienteProyectil, 0f, float.PositiveInfinity);

        if (objetivo != null && (tiempoParaSiguienteProyectil <= 0f))
        { RealizaDisparo(); }
    }

    private void RealizaDisparo()
    {
        GameObject nuevoProyectil = Instantiate(prefabProyectil);
        Proyectil proyectil = nuevoProyectil.GetComponent<Proyectil>();
        proyectil.Init(
            origenProyectil.position,
            objetivo.position,
            alturaSaltoProyectil
            );
        tiempoParaSiguienteProyectil = tiempoEntreProyectiles;
    }

    private void GestionPerdidaObjetivo()
    {
        if (Vector3.Distance(transform.position, objetivo.position) > radioPerdidaObjetivo)
        {
            objetivo = null;
        }
    }

    private void GestionAdquisicionObjetivo()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioDeteccion);
        float distanciaObjetivoMasCercano = 1000000f;
        Transform objetivoMasCercano = null;

        foreach (Collider c in colliders)
        {
            if (tagsObjetivos.Contains(c.tag))
            {
                float distance = Vector3.Distance(transform.position, c.transform.position);
                if (distance < distanciaObjetivoMasCercano)
                {
                    objetivoMasCercano = c.transform;
                    distanciaObjetivoMasCercano = distance;
                }
            }
        }

        objetivo = objetivoMasCercano;
    }
}
