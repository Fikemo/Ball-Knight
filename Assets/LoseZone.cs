using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    public GameObject player;
    public CameraScroll cameraScroll;

    public GameObject backgroundPanel;
    public GameObject loseText;

    public GameObject restartButton;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == player) {
            // initiate win condition
            // cameraScroll.scrollEnabled = false;

            backgroundPanel.SetActive(true);
            loseText.SetActive(true);
            restartButton.SetActive(true);
        }
    }
}
