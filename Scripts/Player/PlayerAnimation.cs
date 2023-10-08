using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer _playerSprite;
    private Animator _anim;
    private Animator _swordAnim;
    private SpriteRenderer _swordArcSprite;

    private PlayerInput playerInput;
    private PlayerAutoGenerated playerInputActions;

    private GameObject Player;




    void Start()
    {
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _anim = transform.GetChild(0).GetComponent<Animator>();  //GetComponentInChildren<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Player = GameObject.FindWithTag("Player");

        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerAutoGenerated();

        playerInputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        RunAnim();
        if (GameManager.Instance.hasFireSword)
        {
            _anim.SetBool("FireAttack", true);
        }
    }

    void RunAnim()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        float move = inputVector.x;
        _anim.SetFloat("Move", Mathf.Abs(move));
        if (move > 0)
        {
            Player.transform.localScale = new Vector3(1,1,1);
            //_playerSprite.flipX = false;
            //_swordArcSprite.flipX = false;
            //_swordArcSprite.flipY = false;
        }
        else if (move < 0)
        {
            Player.transform.localScale = new Vector3(-1, 1, 1);
            //_playerSprite.flipX = true;
            //_swordArcSprite.flipX = true;
            //_swordArcSprite.flipY = true;
        }
    }

    public void JumpAnim(int jumping)
    {
        if(jumping == 1)
        {
            _anim.SetBool("Jumping", true);
        }
        else if(jumping == 0)
        {
            _anim.SetBool("Jumping", false);
        }
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnimation");
    }

    public void Death()
    {
        _anim.SetTrigger("Death");
    }
}