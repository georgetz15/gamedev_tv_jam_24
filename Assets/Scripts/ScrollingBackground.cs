using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private float backgroundBoundLength = 60.0f;
    [SerializeField] private float scrollSpeed = 1.0f;

    private GameObject secondBackground;

    // Start is called before the first frame update
    void Awake()
    {
        secondBackground = Instantiate(background,
            background.transform.position + 0.5f * backgroundBoundLength * Vector3.right,
            background.transform.rotation,
            transform);
    }

    // Update is called once per frame
    void Update()
    {
        // Scroll both BGs
        background.transform.position += scrollSpeed * Time.deltaTime * Vector3.left;
        secondBackground.transform.position += scrollSpeed * Time.deltaTime * Vector3.left;

        // If the left BG is out of camera => swap
        if (background.transform.position.x < -0.5f * backgroundBoundLength)
        {
            (background, secondBackground) = (secondBackground, background);
            secondBackground.transform.position =
                background.transform.position + 0.5f * backgroundBoundLength * Vector3.right;
        }
    }
}