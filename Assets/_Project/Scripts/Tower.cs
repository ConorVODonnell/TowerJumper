using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] List<Room> ActiveRooms;
    List<Vector3> RoomPositions = new List<Vector3>();
    Queue<Room> RoomQueue = new Queue<Room>();

    Room playerRoom;

    void Awake() {
        SetupTower();
    }

    void SetupTower() {
        playerRoom = ActiveRooms[0];
        foreach (var room in ActiveRooms) {
            RoomQueue.Enqueue(room);
            RoomPositions.Add(room.transform.position);
        }
    }

    public void OnJump() {
        CycleRooms();
    }

    void CycleRooms() {
        //Send PlayerRoom to back of the queue
        RoomQueue.Enqueue(RoomQueue.Dequeue());

        //Convert Queue to array, to iterate through it and RoomPositions together
        var roomArray = RoomQueue.ToArray();
        for (int i = 0; i < roomArray.Length; i++)
            roomArray[i].MoveRoom(RoomPositions[i]);
    }
}