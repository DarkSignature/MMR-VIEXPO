using UnityEngine;
using TMPro;
public class FinishController : MonoBehaviour
{

    public TextMeshProUGUI myText;
    public QuestManager questManager;
    public Transform cameraTransform;
    public bool done = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnPointerEnter()
    {
        if (!done && (Vector3.Distance(cameraTransform.position, transform.position) < 3f))
        {
            questManager.setFinal();
            done = true;
            myText.text =
                    "Main Objectives:\n" +
                    "- <color=green>Go towards the first picture (1/1)</color>\n" +
                    "- <color=green>See all the pictures (" + questManager.picCounter + "/11)</color>\n" +
                    "- <color=green>Reach the end! (1/1)</color>\n" +
                    "Optional Objectives:\n" +
                    "- Change the music on the jukebox";
        }
    }

}
