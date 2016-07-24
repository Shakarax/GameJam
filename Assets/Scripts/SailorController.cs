﻿using UnityEngine;
using System.Collections;

public class SailorController : MonoBehaviour {
    private LevelController _levelController;
    public int drownCountdown = 0;
    public Material Drowned;
    public Renderer Renderer;
    public SailorState _SailorState;

    public enum SailorState {
        Dead,
        Alive
        }

    // Use this for initialization
    void Start () {
        _levelController = GameObject.Find("Main Camera").GetComponent<LevelController>();
        Renderer = GetComponent<Renderer>();
        _SailorState = SailorState.Alive;
    }
	
	// Update is called once per frame
	void Update () {
        if (_levelController.CurrentState == LevelController.TurnState.Victim)
        {
            StillAlive();
        }
	}

    void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "Water")
        {
            if (_levelController.CurrentState == LevelController.TurnState.Victim)
            {
                drownCountdown++;
                StillAlive();
            }
        }
    }

    void StillAlive()
    {
        if (drownCountdown >= 2)
        {
            _SailorState = SailorState.Dead;
            Renderer.material = Drowned;
        }
    }
}