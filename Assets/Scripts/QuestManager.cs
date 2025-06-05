using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public int picCounter = 0;
    private bool firstDone = false;
    private bool secondDone = false;
    private bool finalDone = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void addCount()
    {
        picCounter++;
        if (!firstDone)
        {
            firstDone = true;
        }
        if (picCounter == 11)
        {
            secondDone = true;
        }
    }

    public void setFinal()
    {
        if (firstDone && secondDone)
        {
            finalDone = true;
        }
    }
}
