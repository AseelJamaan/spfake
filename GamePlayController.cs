using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    // Singleton instance
    public static GamePlayController instance;

    // Prefabs for spawning pickups
    public GameObject fruit_PickUp;
    public GameObject bomb_PickUp;

    // Spawn boundaries for X and Y axis
    private float min_X = -4.25f, max_X = 4.25f;
    private float min_Y = -2.26f, max_Y = 2.26f;

    // Z-position where pickups will appear
    private float z_Pos = 5.8f;

    // Score system
    private Text score_Text;
    private int scoreCount;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        // Find the score text in the scene
        score_Text = GameObject.Find("Score").GetComponent<Text>();

        // Start spawning pickups after a short delay
        Invoke("StartSpawning", 0.5f);
    }

    // Create singleton instance
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    // Start the spawn coroutine
    void StartSpawning()
    {
        StartCoroutine(SpawnPickUps());
    }

    // Stop spawning pickups
    public void CancelSpawning()
    {
        CancelInvoke("StartSpawning");
    }

    // Coroutine responsible for spawning fruit and bombs
    IEnumerator SpawnPickUps()
    {
        // Wait between 1 and 1.5 seconds before spawning next item
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));

        // 80% chance fruit, 20% chance bomb
        if (Random.Range(0, 10) >= 2)
        {
            Instantiate(
                fruit_PickUp,
                new Vector3(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), z_Pos),
                Quaternion.identity
            );
        }
        else
        {
            Instantiate(
                bomb_PickUp,
                new Vector3(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), z_Pos),
                Quaternion.identity
            );
        }

        // Call StartSpawning again immediately
        Invoke("StartSpawning", 0f);
    }

    // Increase the player's score
    public void IncreaseScore()
    {
        scoreCount++;
        score_Text.text = "Score: " + scoreCount;
    }
}
