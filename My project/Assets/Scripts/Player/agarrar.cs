using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class agarrar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform mao;
    public bool aGarrar = false;
    public bool impulse = false;
    public float timeimpulse = 0f;
    public float tempoimpulse = 0.3f;
    [SerializeField] private Rigidbody2D rb2;
    public InputAction GrabInput;
    public Transform Grab;
    public float forceGrab = 10f;
    private Vector2 direcaoGrab;
    public bool firstGrabbool = false;
    public int segundos=500;
    
    

    void Start()
    {
        //segurança para se eu esquecer de atribuir no inspetor
        GrabInput.Enable();
        
        if (rb2 == null)
            rb2 = GetComponent<Rigidbody2D>();
    }
    
    void GrabFunction()
    {
        if (Grab == null || rb2 == null) return;

        direcaoGrab = ((Vector2)Grab.position - (Vector2)transform.position).normalized;
        aGarrar = true;

        rb2.gravityScale = 0f;
        rb2.linearVelocity = Vector2.zero;
    }
    void SoltarGrab()
    {
        aGarrar = false;
        impulse = true;
        timeimpulse = tempoimpulse;
        rb2.gravityScale = 2f;
        rb2.linearVelocity = direcaoGrab * forceGrab;
    }
    // Update is called once per frame
    async void Update()
    {

        if(impulse)
        {
            timeimpulse -= Time.deltaTime;
            if (timeimpulse <= 0f)
            {
                await Task.Delay(segundos);
                impulse = false;
                rb2.gravityScale = 1f;
            }
        }


        if (GrabInput.WasPressedThisFrame())
            GrabFunction();

        if (aGarrar)
        {
            if (Grab==null)
            {
                SoltarGrab();
                return;
            }

            rb2.linearVelocity = direcaoGrab * forceGrab;

            // chegou ao objeto → para
            float distancia = Vector2.Distance(transform.position, Grab.position);
            if (distancia < 0.5f)
            {
                SoltarGrab();
            }
        }

    }
    
    
}


