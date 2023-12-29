using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{

    private bool dragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    private Vector3 minPosition;
    private Vector3 maxPosition;
    private float limitOffset = 0.5f;

    private void Start() {
        mainCamera = Camera.main;

        // Define the boundaries of your app
        float minX = mainCamera.ScreenToWorldPoint(Vector3.zero).x + limitOffset;
        float maxX = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - limitOffset;
        float minY = mainCamera.ScreenToWorldPoint(Vector3.zero).y + limitOffset;
        float maxY = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - limitOffset;

        // Calculate the minimum and maximum positions
        minPosition = new Vector3(minX, minY, transform.position.z);
        maxPosition = new Vector3(maxX, maxY, transform.position.z);
    }

    private void Update() {
        if (dragging) {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offset;

            // Clamp the object's position within the defined boundaries
            transform.position = new Vector3(
                Mathf.Clamp(mousePosition.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(mousePosition.y, minPosition.y, maxPosition.y),
                transform.position.z
            );
        }
    }

    private void OnMouseDown() {
        offset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp() {
        dragging = false;
    }
}
