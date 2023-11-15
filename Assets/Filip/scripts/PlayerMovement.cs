using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _itemSpriteRenderer;
    [SerializeField] private Sprite _item1;
    [SerializeField] private Sprite _item2;
    [SerializeField] private Color _item1Color;
    [SerializeField] private Color _item2Color;
    [SerializeField] private float _moveSpeed = 5f;
    private Animator _animator;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _itemSpriteRenderer.sprite = _item1;
        _itemSpriteRenderer.color = _item1Color;
    }

    private void Update() {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement.Normalize();
        _animator.SetFloat("horizontal", _movement.x);
        _animator.SetFloat("vertical", _movement.y);
        _animator.SetBool("moving", _movement.sqrMagnitude != 0);

        if (Input.GetButtonDown("Jump"))
        {
            if (_itemSpriteRenderer.sprite == _item1)
            {
                ChangeItem(_item2, _item2Color);
            }
            else
            {
                ChangeItem(_item1, _item1Color);
            }
        }
    }

    private void FixedUpdate() {
        _rigidbody.MovePosition(_rigidbody.position + _movement * (_moveSpeed * Time.fixedDeltaTime));
    }

    private void ChangeItem(Sprite sprite, Color color)
    {
        _itemSpriteRenderer.sprite = sprite;
        _itemSpriteRenderer.color = color;
    }
}
