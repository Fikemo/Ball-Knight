using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZone : MonoBehaviour
{
    public GameObject player;
    public CameraScroll cameraScroll;

    public GameObject backgroundPanel;
    public GameObject winText;

    public GameObject restartButton;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == player) {
            // initiate win condition
            cameraScroll.scrollEnabled = false;

            backgroundPanel.SetActive(true);
            winText.SetActive(true);
            restartButton.SetActive(true);
        }
    }
}
