using UnityEngine;
using TMPro;

public class RandomText : MonoBehaviour
{
    [TextArea]
    public string[] possibleTexts;

    private TMP_Text textComponent;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();

        if (possibleTexts.Length > 0)
        {
            int index = Random.Range(0, possibleTexts.Length);
            textComponent.text = possibleTexts[index];
        }
    }
}