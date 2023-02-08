using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Adicionando as Variaveis Necessarias para o Player Movimentar
    // Velocidade = Speed
    // Rigidbody para pegar a fisica do personagem
    // e Vector2 para pegar as direções ao qual o personagem está indo, X e Y
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;


    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Vector2 _direction;

    public Vector2 direction 
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }


    private void Start()
    {
        // Referenciando o Rigidbody para a variavel
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate()
    {
        OnMove();
    }


    #region Moviment

    void OnInput()
    {
        //Direção recebe os Inputs e consegue pegar a direção do personagem
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        //Calculando as movimentação do personagem atraves da Fisica,
        //pegando a posição dele e adicionando o movimento
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))    
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRolling = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isRolling = false;
        }
    }


    #endregion

}
