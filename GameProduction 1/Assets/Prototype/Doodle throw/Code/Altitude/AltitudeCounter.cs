using UnityEngine;
using TMPro;

public class AltitudeCounter : MonoBehaviour
{
    public Transform HeightReference;
    public float heightAboveGround;

    public TMP_Text AltitudeNum;

    void Update()
    {
        heightAboveGround = HeightReference.position.y;
        //Debug.Log(heightAboveGround.ToString("F1"));

        AltitudeNum.text = "Altitude: " + heightAboveGround.ToString("F1");
    }
}
