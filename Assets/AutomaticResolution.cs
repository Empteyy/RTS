using UnityEngine;
using System.Collections;

public class ScaleRepositionScript : MonoBehaviour
{
    public bool isScalableX;
    public bool isScalableY;
    public bool isRepositionableX;
    public bool isRepositionableY;
    public float ratio = 1.76f;

    void Start()
    {
        float scaleFactor = Camera.main.aspect / ratio;

        if (isScalableX)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * scaleFactor, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        }
        if (isScalableY)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y * scaleFactor, this.gameObject.transform.localScale.z);
        }

        if (isRepositionableX)
        {
            if (isRepositionableY)
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x * scaleFactor, this.gameObject.transform.position.y * scaleFactor, this.gameObject.transform.position.z);
            else
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x * scaleFactor, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }
}
