﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Animal : MonoBehaviour {
    
    public enum ANIMAL_TYPE {
        BAT = 0,
        CAT = 1,
        DOG = 2,
        DRAGON = 3,
        GOOSE = 4,
        GRIFFIN = 5,
        LLAMA = 6,
        PENGUIN = 7,
        PHOENIX = 8,
        RABBIT = 9,
        SABERTOOTH = 10,
        UNICORN = 11,
        COUNT,
    };

    [SerializeField]
    private float _pooRate = 1.0f;
    private float _pooTimer = 0.0f;

    [SerializeField]
    private GameObject _pooPrefab = null;
    [SerializeField]
    private GameObject[] _pooPrefabs = null;

    [SerializeField]
    private uint _keepAliveScore = 10;

    [SerializeField]
    private float _cinematicScale = 1.5f;
    [SerializeField]
    private bool _isCinematic = false;
    public void SetCinematic()
    {
        _isCinematic = true;
        SetScale(_cinematicScale * Vector3.one);
    }
    public Vector3 GetScale() {
        return this.transform.localScale;
    }
    public void SetScale(Vector3 scale)
    {
        this.transform.localScale = scale;
    }

    private HoldingPin _holdingPin = null;
    public void SetHoldingPin(HoldingPin pin) {
        _holdingPin = pin;
    }

    private bool _isDead = false;
    public bool IsDead() {
        return _isDead;
    }
    public bool IsAlive()
    {
        return !_isDead;
    }

	// Use this for initialization
	void Start () {
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        sprite.color = new Color(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), 1.0f);
        Vector3 scale = transform.localScale;
        scale.x *= ((Random.Range(-1.0f, 1.0f) > 0.0f) ? 1f : -1f);
        transform.localScale = scale;

        //@NOTE: Random anim start time
        this.GetComponent<Animator>().Play(0, -1, Random.Range(0.0f, 1.0f));
        //Random.Range(0.0f, 1.0f);
        //thisAnim.Play("Smoke", -1, Random.Range(0.0f, 1.0f));
	}
	
	// Update is called once per frame
	virtual public void Update () {
        if(IsAlive() && !_isCinematic) {
            //@TODO: Do alive behavior.
            UpdatePoo();
        } else {
            //@TODO: Do dead behavior.
        }
	}

    private void UpdatePoo() {
        if(_pooTimer >= _pooRate) {
            TakeADump();
            _pooTimer = 0.0f;
        }
        _pooTimer += Time.deltaTime;
    }

    private void TakeADump() {
        //@TODO: Generate a new poo prefab based on the animal's individual properties (weight, etc.)
        if(_pooPrefabs.Length > 0) {
            int index = (int)Random.Range(0, _pooPrefabs.Length);
            const float pooRandomRange = 0.3f;
            Vector3 pooPos = this.transform.position;
            pooPos += Vector3.right * Random.Range(-pooRandomRange, pooRandomRange);
            GameObject pooGO = Instantiate(_pooPrefabs[index], pooPos, this.transform.rotation);
            Poo poo = pooGO.GetComponent<Poo>();
            _holdingPin.AddPoo(poo);
            poo.Pin = _holdingPin;
        }
    }

    public void Kill() {
        //@TODO: Kill the animal, set animation to death state, etc.
        _isDead = true;
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
        sprite.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        SoundController.animalDeath.Play();
        this.GetComponent<Animator>().speed = 0.0f;
    }
}

[System.Serializable]
public class DictionaryOfAnimalPrefabs : SerializableDictionary<Animal.ANIMAL_TYPE, GameObject> { }
[System.Serializable]
public class DictionaryOfAnimalNames : SerializableDictionary<Animal.ANIMAL_TYPE, string> { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(DictionaryOfAnimalPrefabs))]
public class MyDictionaryDrawer2 : DictionaryDrawer<Animal.ANIMAL_TYPE, GameObject> { }
[CustomPropertyDrawer(typeof(DictionaryOfAnimalNames))]
public class MyDictionaryDrawer3 : DictionaryDrawer<Animal.ANIMAL_TYPE, string> { }
#endif
