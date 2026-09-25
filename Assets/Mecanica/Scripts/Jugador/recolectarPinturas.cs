using UnityEngine;

public class recolectarPinturas : MonoBehaviour
{
    [SerializeField] private int pinturasRecolectadas = 0;
    [SerializeField] private int pinturasTotales = 4;
    [SerializeField] private GameObject pantalla;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pinturasRecolectadas >= pinturasTotales)
        {
            //Pantalla de victoria
            pantalla.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pintura"))
        {
            pinturasRecolectadas++;
            Destroy(collision.gameObject);
        }
    }
}
