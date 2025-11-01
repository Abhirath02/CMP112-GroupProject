using UnityEngine;
using TMPro;



public class gun1Script : MonoBehaviour
{
    [SerializeField] private TMP_Text textMesh;
    void Start()
    {
        // hide text at start
        if (textMesh != null)
        {
            textMesh.gameObject.SetActive(false);
        }
    }

//problem in here
    //check if player overlaping gun to show text
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("text should show!");
            textMesh.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("text shouldnt show");
            textMesh.gameObject.SetActive(false);
        }
    }
}
