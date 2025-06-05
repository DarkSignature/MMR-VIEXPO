using UnityEngine;
using TMPro;
public class QuestController : MonoBehaviour
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
            questManager.addCount();
            done = true;
            if (questManager.picCounter == 1)
            {
                myText.text =
                    "Main Objectives:\n" +
                    "- <color=green>Go towards the first picture (1/1)</color>\n" +
                    "- See all the pictures (1/11)\n" +
                    "- Reach the end! (0/1)\n" +
                    "Optional Objectives:\n" +
                    "- Change the music on the jukebox";

            }
            else if (questManager.picCounter == 11)
            {
                myText.text =
                    "Main Objectives:\n" +
                    "- <color=green>Go towards the first picture (1/1)</color>\n" +
                    "- <color=green>See all the pictures (" + questManager.picCounter + "/11)</color>\n" +
                    "- Reach the end! (0/1)\n" +
                    "Optional Objectives:\n" +
                    "- Change the music on the jukebox";
            }
            else if (questManager.picCounter > 1)
            { // Example: <color=red>red</color>
                myText.text =
                    "Main Objectives:\n" +
                    "- <color=green>Go towards the first picture (1/1)</color>\n" +
                    "- See all the pictures (" + questManager.picCounter + "/11)\n" +
                    "- Reach the end! (0/1)\n" +
                    "Optional Objectives:\n" +
                    "- Change the music on the jukebox";

            }
        }
    }
}
