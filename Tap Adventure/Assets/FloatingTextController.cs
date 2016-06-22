using UnityEngine;
using System.Collections;

public class FloatingTextController : MonoBehaviour {
    public enum FloatTextType
    {
        ForceRight,
        ForceLeft,
        Random,
        Up
    }
    TextMesh text;
    Rigidbody rb;
    FloatTextType textType;
    Color endColor;
    bool init = false;
    float t = 0f;
	// Use this for initialization
	void Awake () {
        text = GetComponent<TextMesh>();
        rb = GetComponent<Rigidbody>();
        endColor = new Color();
        
	}
    public void InitText(Color color, string value, FloatTextType type)
    {
        Debug.Log("new text: " + value);
        text.text = value;
        text.color = color;
        textType = type;
        endColor = color;
        endColor.a = 0f;
        switch (type)
        {
            case FloatTextType.ForceLeft:
                rb.AddForce(new Vector3(10, 20, 0) * Random.Range(10, 15));
                rb.useGravity = true;
                break;
            case FloatTextType.ForceRight:
                rb.AddForce(new Vector3(-10, 20, 0) * Random.Range(10, 15));
                rb.useGravity = true;
                break;
            case FloatTextType.Random:
                rb.AddForce(new Vector3(10, 20, 0) * Random.Range(-15, 15));
                rb.useGravity = true;
                break;
            case FloatTextType.Up:
                rb.AddForce(new Vector3(0, 20, 0)* 10);
                rb.useGravity = false;
                break;
        }
        t = -1f;
        init = true;
    }
	// Update is called once per frame
	void Update () {
        if (init)
        {
            t += Time.deltaTime;
            text.color = Color.Lerp(text.color, endColor, t);
            if (t >= 1f)
            {
                t = 0;
                init = false;
                Destroy(gameObject);
                //gameObject.SetActive(false);
            }
        }
	
	}
}

