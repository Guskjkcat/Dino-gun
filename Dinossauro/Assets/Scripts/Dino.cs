using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.Mathematics;
using UnityEngine;

public class dino : MonoBehaviour
{
    //variavel para a velocidade do personagem.
    Vector2 yVelocity;

    //altura maxima do personagem, tempo para atingir essa altura maxima.
    float maxHeight = 0.8f;
    float timeToPeak = 0.3f;

    //velocidade do pulo, "força" da gravidade.
    float jumpSpeed;
    float gravity;

    //verificar se o personagem ta no chao para poder pular.
    float groundPosition = 0;
    bool isGrounded = false;
    

    void Start()
    {
        //equação da cinemática para o movimento uniformemente acelerado.
        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);
        jumpSpeed = gravity * timeToPeak;

        groundPosition = transform.position.y;

    }

    
    void Update()
    {
        //
        yVelocity += gravity * Time.deltaTime * Vector2.down;

        //verifica se a prosiçao y e menor ou igual a posiçao do chao
        if (transform.position.y <= groundPosition)
        {
            transform.position = new Vector3(transform.position.x, groundPosition, transform.position.z);
            yVelocity = Vector3.zero;
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }

        //verifica se o botao espaço foi precionado se sim, ele pula e verifica tambem se estou no ar.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //velocidade so pulo
            yVelocity = jumpSpeed * Vector2.up;
        }

        //movimento do personagem para as novas posiçao.
        transform.position += (Vector3)yVelocity * Time.deltaTime;

    }
}
