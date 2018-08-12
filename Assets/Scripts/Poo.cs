﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poo : MonoBehaviour {

    [SerializeField]
    private float _weight = 1.0f;
    public float GetWeight() {
        return _weight;
    }

    private bool _thrown = false;

    public HoldingPin Pin { get; set; }

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().mass = _weight / 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Throw() {
        _thrown = true;
    }
}
