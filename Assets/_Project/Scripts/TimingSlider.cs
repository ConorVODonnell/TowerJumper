using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TimingGrade { Good, Ok, Poor, Miss }
public class TimingSlider : MonoBehaviour
{
    [SerializeField] TimingRange[] sliderRanges;
    [SerializeField] TimingRange missRange;

    [SerializeField] RectTransform handle;

    public void OnJump() {
        print(GetCurrentRange().name);
    }

    TimingRange GetCurrentRange() {
        float handlePos = handle.localPosition.x;
        foreach (TimingRange range in sliderRanges) {
            if (range.HandleIsInRange(handlePos))
                return range;
        }
        return missRange;
    }
}