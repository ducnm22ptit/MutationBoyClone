using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoudResource", menuName = "SoundResource")]
public class SoundResource : ScriptableObject
{

    [Header("BackGroundMusic")]
    public AudioClip InGame;
    public AudioClip UIBackground;


    [Header("Beasts")]
    public AudioClip Dino;
    public AudioClip Dino0;
    public AudioClip Dino1;
    public AudioClip Dino2;
    public AudioClip Dragon;
    public AudioClip Gorilla;
    public AudioClip Lion;
    public AudioClip Rhino;
    public AudioClip Robot;
    public AudioClip Whale;


    [Header("Action")]
    public AudioClip Breathing;
    public AudioClip DinoWalk;
    public AudioClip Fly;
    public AudioClip Karate;
    public AudioClip Run1;
    public AudioClip Run2;
    public AudioClip Scream;
    public AudioClip Touch;
    public AudioClip Walk;


    [Header("Effect")]
    public AudioClip Door;
    public AudioClip EarthQuake;
    public AudioClip AirPlane;
    public AudioClip Electric;
    public AudioClip FailChoose1;
    public AudioClip FailChoose2;
    public AudioClip GameOver;
    public AudioClip Laser;
    public AudioClip Mountain;
    public AudioClip Pass;
    public AudioClip Trans;
    public AudioClip WallFall;
    public AudioClip Wind;
    public AudioClip WinPopup;
    public AudioClip WinPopupAdd;






}
