using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScreen : MonoBehaviour
{
    public Camera cameraObj;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        SetScreenRes();
    }

    private void SetScreenRes()
    {
        print(Screen.height);
        print(Screen.width);

        float height = Screen.height;
        float width = Screen.width;
        float ratio = width / height;

        //cameraObj.aspect = ratio;
        float camHeight = 100.0f * cameraObj.orthographicSize * 2.0f;
        float camWidth = camHeight * ratio;

        SpriteRenderer backgroundImage = background.GetComponent<SpriteRenderer>();
        float backgroundHeight = backgroundImage.sprite.rect.height;
        float backgroundWidth = backgroundImage.sprite.rect.width;


        float ratioHeight = camHeight / backgroundHeight;
        float ratioWidth = camWidth / backgroundWidth;

        background.transform.localScale = new Vector3(ratioWidth, ratioHeight, 1);

        RectTransform backgroundRen = background.GetComponent<RectTransform>();
        background.transform.position = new Vector3(backgroundRen.position.x, backgroundRen.position.y + 1, backgroundRen.position.z);

    }

}
