using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スコアエリア
public class ScoreArea : MonoBehaviour
{
    public GameManager gameManager;
    public int agentId;

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        gameManager.EndEpisode(agentId);
    }
}
