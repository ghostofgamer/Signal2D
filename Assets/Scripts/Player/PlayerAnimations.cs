using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator; 

    private readonly string Run = "Run";
    private readonly string Jump = "Jump";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunAnimation(bool flag)
    {
        _animator.SetBool(Run,flag);
    }

    public void JumpAnimation(bool flag)
    {
        _animator.SetBool(Jump, flag);
    }
}
