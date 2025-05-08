using UnityEngine;

public class Torre : MonoBehaviour, IGolpeable
{
    [SerializeField] float resistencia;

    public void RecibeDanyo(float danyo)
    {
        resistencia -= danyo;
        if (resistencia <= 0)
            { Destroy(gameObject); }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
