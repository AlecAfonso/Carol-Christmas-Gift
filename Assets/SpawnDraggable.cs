using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDraggable : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 position;
    public int letterCount;
    private int currentCount;

    private GameManager gm;

    public Canvas canvas;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    public void spawnPrefab() {

        Vector2 viewportPosition = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, this.transform.position);
        Vector3 worldPosition;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), viewportPosition, canvas.worldCamera, out worldPosition);

        // Instantiate the GameObject at the calculated world position
        Instantiate(prefab, worldPosition + new Vector3(40f, 0, 0), Quaternion.identity);

        gm.addLetter();
        currentCount++;
        if (currentCount >= letterCount) {
            Button button = GetComponent<Button>();
            button.interactable = false;

        }
    }


}
