using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBallController : MonoBehaviour {
    AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    public void PlayerKickSound() {
        source.Play();
    }
}
