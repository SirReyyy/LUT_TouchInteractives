using UnityEngine;

public class CoinScript : MonoBehaviour
{
    
    public Material[] materialsList; // List of materials for random color change
    private float originalDelay = 15.0f, triggerDelay;
    private bool isTriggered = false;
    private Renderer coinRenderer;

    void Awake()
    {
        coinRenderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        if (isTriggered)
        {
            //
        }
        else
        {
            triggerDelay += Time.deltaTime;
            if (triggerDelay > originalDelay)
            {
                RevertColor();
                triggerDelay = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        ChangeColor();

    }

    void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }

    void ChangeColor()
    {
        if (materialsList.Length > 0)
        {
            coinRenderer.material = materialsList[1];
        }
    }

    void RevertColor()
    {
        coinRenderer.material = materialsList[0];
    }
}
