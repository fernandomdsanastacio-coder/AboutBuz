using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public float jumpforce=7f;
    private bool jump;
    private Rigidbody2D rb2d;
    public InputAction Moveaction;
    public InputAction Jump;

    [SerializeField] private LayerMask chaolayer;
    [SerializeField] private Transform pes;
    [SerializeField] private float groundcheckradius = 0.1f;

    private agarrar agarrar;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Ativar os inputs
        Moveaction.Enable();
        Jump.Enable();
        agarrar = GetComponent<agarrar>();
    }
    bool isGround()
    {
        return Physics2D.OverlapCircle(pes.position, groundcheckradius, chaolayer);
    }

    void Update()
    {

        if (!agarrar.aGarrar&& !agarrar.impulse)
        {
            Vector2 move = Moveaction.ReadValue<Vector2>();// valor de quando clica e quando não clica

            rb2d.linearVelocity = new Vector2(move.x * speed, rb2d.linearVelocity.y);
            /*=======================================
            move.x * speed => horizontal
            rb2d.linearVelocity.y => manter a gravidade
            =========================================*/
            //Sistema de Jump
            float JumpAction = Jump.ReadValue<float>();// button float 1 ou 0
            if (isGround() && JumpAction > 0)
            {
                rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpforce);
            }
        }
        
    }


}
