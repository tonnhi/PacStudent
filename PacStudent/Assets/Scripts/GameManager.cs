using UnityEngine;

public class GameManager : MonoBehaviour
{


    public GameObject[] ghosts;
    public Transform pellets;
    public Pacstudent pacstudent;


    public int lives { get; private set; }
    public int score { get; private set; }


    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }
    }


    private void ResetState()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
            this.ghosts[i].gameObject.SetActive(true);
        {
            this.pacstudent.gameObject.SetActive(true);
        }

    }

    private void GameOver()
    {
        //gameOverText.enabled = true;

        for (int i = 0; i < ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        pacstudent.gameObject.SetActive(false);
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        //livesText.text = "x" + lives.ToString();
    }

    private void SetScore(int score)
    {
        this.score = score;
        //scoreText.text = score.ToString().PadLeft(2, '0');
    }

    public void PacstudentEaten()
    {
        this.pacstudent.gameObject.SetActive(false);
        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }
    }

    public void GhostEaten()
    {
        //SetScore(this.score + points);

    }

    

    

}