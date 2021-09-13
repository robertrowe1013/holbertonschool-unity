using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzle : MonoBehaviour
{
    public int pieceCount = 0;
    public GameObject projector;

    public void OnTriggerEnter(Collider piece)
    {
        if (piece.gameObject.CompareTag("ChessPiece"))
        {
            pieceCount += 1;
        }
    }

    public void OnTriggerExit(Collider piece)
    {
        if (piece.gameObject.CompareTag("ChessPiece"))
        {
            pieceCount -= 1;
        }
    }

    public void UnlockProjector()
    {
        if (pieceCount == 4)
        {
            projector.SetActive(true);
        }
    }
}
