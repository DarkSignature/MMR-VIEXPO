using UnityEngine;
using TMPro;
public class SoundController : MonoBehaviour
{

    public TextMeshProUGUI myText;
    public SoundController otherText1;
    public SoundController otherText2;

    public int songIndex;
    public Transform cameraTransform;
    public GameObject desc;
    public GameObject moveObj;
    Renderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        desc.SetActive(false);
        rend = GetComponent<Renderer>();
        if (songIndex == 0)
        {
            SoundManager.singleton.PlaySound(songIndex);
            rend.material.color = Color.blue;
            myText.fontStyle = FontStyles.Bold;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPointerEnter()
    {
        if (Vector3.Distance(cameraTransform.position, transform.position) < 3f){
            desc.SetActive(true);
            moveObj.SetActive(false);
            SoundManager.singleton.PlaySound(songIndex);
            rend.material.color = Color.blue;
            myText.fontStyle = FontStyles.Bold;
            TurnOff();
        }
    }

    void OnPointerExit()
    {
        desc.SetActive(false);
        moveObj.SetActive(true);
    }

    void TurnOff()
    {
        otherText1.rend.material.color = Color.black;
        otherText2.rend.material.color = Color.black;
        otherText1.myText.fontStyle = FontStyles.Normal;
        otherText2.myText.fontStyle = FontStyles.Normal;
    }
}
