using System.Reflection.Metadata;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimientoJugador : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D jugadorRB;
    [SerializeField] private PlayerInput playerInput;

    [Header("Estadisticas del jugador")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float velocidadMovimiento;
    Vector2 direccionMovimiento;

    [Header("Flags")]

    [SerializeField] private bool yaSalto;

    void Start()
    {
        jugadorRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverJugador();
        Saltar();

        
    }

    private void MoverJugador()
    {
        direccionMovimiento = playerInput.actions["Movimiento"].ReadValue<Vector2>()*velocidadMovimiento;
        jugadorRB.linearVelocity = new Vector2(direccionMovimiento.x, jugadorRB.linearVelocity.y);

        if (direccionMovimiento.x < 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
        else if (direccionMovimiento.x > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    private void Saltar()
    {
        if (playerInput.actions["Saltar"].WasPressedThisFrame() && !yaSalto)
        {

            jugadorRB.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            yaSalto = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            yaSalto = false;
        }
    }
}
