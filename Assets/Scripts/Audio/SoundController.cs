﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour {

    private bool _fart1() { return (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Joystick1Button5)); }
    private bool _fart2() { return (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Joystick1Button7)); }
    private bool _fart3() { return (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Joystick1Button6)); }
    private bool _fart4() { return (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Joystick1Button3)); }
    private bool _fart5() { return (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Joystick1Button0)); }




    public AudioSource ambience;
    public static AudioSource jump;
    public static AudioSource pickup;
    public static AudioSource toss;
    public static AudioSource animalDeath;
    public AudioSource poop1;
    public AudioSource poop2;
    public AudioSource poop3;
    public AudioSource poop4;
    public AudioSource poop5;
    public AudioSource poop6;
    public AudioSource poop7;
    public AudioSource poop8;

    private int randomPoop = 0;
    private float randomTime = 10.0f;
    private float timeCounter = 0.0f;

    //public AudioLowPassFilter lowPass;
    float startVolume = .7f;
    float sfxVolume = .6f;
    float poopVolume = .5f;
    float cutOff = 500;

    // Use this for initialization
    void Start () {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if ((sceneName == "JoshScene") && (GameObject.Find("StoryController")))

        {
            Destroy(GameObject.Find("StoryController"));
        }

        InitAudio();            
	}
	
	// Update is called once per frame
	void Update () {

        if (timeCounter > randomTime)
        {
            randomTime = Random.Range(7.0f, 15.0f);
            timeCounter = 0.0f;
            ChoosePoop();

        }

        FartButtons();



        timeCounter += Time.deltaTime;




	}

    private void InitAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        ambience = audio[0];
        jump = audio[1];
        pickup = audio[2];
        toss = audio[3];
        animalDeath = audio[4];
        poop1 = audio[5];
        poop2 = audio[6];
        poop3 = audio[7];
        poop4 = audio[8];
        poop5 = audio[9];
        poop6 = audio[10];
        poop7 = audio[11];
        poop8 = audio[12];

        //ambience.mute = true;
        ambience.loop = true;
        ambience.volume = startVolume;
        ambience.Play();
        pickup.volume = sfxVolume;
        poop1.volume = poopVolume;
        poop2.volume = poopVolume;
        poop3.volume = poopVolume;
        poop4.volume = poopVolume;
        poop5.volume = poopVolume;
        poop6.volume = poopVolume;
        poop7.volume = poopVolume;
        poop8.volume = poopVolume;
    }

    private void FartButtons()
    {
        if (_fart1())
        {
            poop7.Play();
        }
        if (_fart2())
        {
            poop3.Play();
        }
        if (_fart3())
        {
            poop1.Play();
        }
        if (_fart4())
        {
            poop8.Play();
        }
        if (_fart5())
        {
            poop5.Play();
        }

    }

    private void ChoosePoop()
    {
        randomPoop = Random.Range(0, 7);

        switch (randomPoop)
        {
            case 0:
                poop1.Play();
                break;
            case 1:
                poop2.Play();
                break;
            case 2:
                poop3.Play();
                break;
            case 3:
                poop4.Play();
                break;
            case 4:
                poop5.Play();
                break;
            case 5:
                poop6.Play();
                break;
            case 6:
                poop7.Play();
                break;
            case 7:
                poop8.Play();
                break;
            default:
                break;
        }

    }
}
