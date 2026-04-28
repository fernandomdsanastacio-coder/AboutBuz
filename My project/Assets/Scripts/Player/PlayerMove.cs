using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public float jumpforce=7f;
    private Rigidbody2D rb2d;
    public InputAction Moveaction;
    public InputAction Jump;

    //direção -1(diretita), 1 (esquerda)
    private float paredenormal = 0f;

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

    private void OnCollisionStay2D(Collision2D collision)//vê se está a colidir a cada frame
    {
        if (collision.collider.CompareTag("parede"))
        {
            //collision.contacts é um array (lista) de pontos de contacto
            //foreach percorre esse array, um a um, e guarda cada ponto na variável contacts
            foreach (ContactPoint2D contact in collision.contacts)
            {
                //Mathf.Abs serve para devolver um valor absoluto, serve para filtrar colissões laterais de verticais
                //0.5f é o meio termo, se a normal for mais horizontal do que vertical, é lateral
                if(Mathf.Abs(contact.normal.x)>0.5f)
                {
                    paredenormal=contact.normal.x;
                    return;
                    //return serve para que assim que encontrar um ponto lateral válido, sai logo do foreach. porque não é preciso mais que isso
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("parede"))
        {
            paredenormal = 0f; 
        }
    }

    void Update()
    {

        if (!agarrar.aGarrar && !agarrar.impulse)
        {
            Vector2 move = Moveaction.ReadValue<Vector2>();// valor de quando clica e quando não clica
            float velocidadeX = move.x * speed;


            if(paredenormal!=0f && Mathf.Sign(move.x)!= Mathf.Sign(paredenormal))
            {
                velocidadeX = 0f;
            }
            rb2d.linearVelocity = new Vector2(velocidadeX, rb2d.linearVelocity.y);
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
