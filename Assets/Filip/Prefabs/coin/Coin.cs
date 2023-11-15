using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        _audioSource.Play();
        _spriteRenderer.enabled = false;
        Destroy(gameObject, _audioSource.clip.length);
        GameManager.PickUpCoin();
    }
}
