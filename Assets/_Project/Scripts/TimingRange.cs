using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingRange : MonoBehaviour
{
    public TimingGrade Grade { get; private set; }
    public float StartPosition { get; private set; }
    public float EndPosition { get; private set; }

    [SerializeField] public  RectTransform rectTF;

    void Awake() {
        StartPosition = rectTF.localPosition.x - (rectTF.rect.width / 2);
        EndPosition = rectTF.localPosition.x + (rectTF.rect.width / 2);
    }

    public bool HandleIsInRange(float handlePos) {
        return (handlePos >= StartPosition) && (handlePos < EndPosition);
    }
}