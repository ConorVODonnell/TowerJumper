using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    Transform m_RoomTransform;

    void Awake() {
        m_RoomTransform = transform;
    }

    public void MoveRoom(Vector3 newPos) {
        m_RoomTransform.position = newPos;
    }

    public Room SetupRoom() {
        return this;
    }
}