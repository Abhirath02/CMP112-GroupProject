using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;



public class gun1Script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GameObject.Find("pickUpText").GetComponent<TextMeshProUGUI>();
        textMesh.gameObject.SetActive(false);
    }
    
    //check if player overlaping gun to show text
    void OnTriggerEnter2D(Collider2D gun1)
    {
        if (gun1.CompareTag("Player"))
        {
            textMesh.gameObject.SetActive(true);
            RectTransform rectTransform = textMesh.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(100f, -180f);
        }
    }
    void OnTriggerExit2D(Collider2D gun1)
    {
        if (gun1.CompareTag("Player"))
        {
            textMesh.gameObject.SetActive(false);
        }
    }
}