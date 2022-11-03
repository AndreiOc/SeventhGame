using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class AnimationController : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer {get; private set;}
    public Sprite [] _sprites;
    public float _animationTime = 0.25f;
    public int _animationFrame {get; private set;}
    public bool _loop = true;
    private void Awake()
    {
        this._spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() 
    {
        InvokeRepeating(nameof(Advance),this._animationTime,this._animationTime);    
    }
    private void Advance()
    {

    }
}
