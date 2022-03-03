using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables para la velocidad y fuerza de salto
    public float speed = 5f;
    public float jumpForce =10f;
    //variable para saber si estamos en el suelo
    public bool isGrounded;
    //variable para almacenar el input de movimiento
    float dirx;

    //variables de componentes
    public SpriteRenderer renderer;
    public Animator _animator;
    Rigidbody2D _rBody;
    private GameManager gameManager;
    
    void Awake()
    {
        //asignamos los componentes a variables
        _animator = GetComponent<Animator>();
        _rBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");

        Debug.Log(dirx);

        //transform.position += new Vector3(dirx, 0, 0) * speed * Time.deltaTime;

          if(dirx == -1)
        {
            renderer.flipX = true;
            _animator.SetBool("run", true);
        }
        
        else if(dirx == 1)
        {
            renderer.flipX = false;
            _animator.SetBool("run", true);
        }
        else
        {
            _animator.SetBool("run", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Jumping",true);
        }
    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirx * speed, _rBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Si el objeto que entra en el trigger tiene el tag de Goombas
        if(collider.gameObject.CompareTag("Goombas"))
        {
            Debug.Log("Goomba muerto");
            //llamamos a la funcion DeathGoombas del script GameManager
            gameManager.DeathGoomba(collider.gameObject);
            
        }
        //Si el trigger entra en la DeadZone
        if(collider.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("Estoy muerto");
            gameManager.DeathMario();
        }
        
        
        //Si el objeto que entra en el trigger tiene el tag de Victoria
        if(collider.gameObject.CompareTag("Victoria"))
        {
            Debug.Log("Ganaste");
            //llamamos a la funcion Victoria del script GameManager
            gameManager.Victoria();
        }

    
        //Si el objeto que entra en el trigger tiene el tag de DestroyCoin
        if(collider.gameObject.CompareTag("DestroyCoin"))
        {
            Debug.Log("Tengo moneda");
            //llamamos a la funcion TengoMoneda del script GameManager
            gameManager.TengoMoneda(collider.gameObject);
            
        }
    }

    
}
