using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSelect : MonoBehaviour
{
    // No need for Button references

    public void LoadChapter1()
    {
        SceneManager.LoadScene("Chapter 1");
        // No need to unlock the next chapter
    }

    public void LoadChapter2()
    {
        SceneManager.LoadScene("Chapter 2");
    }

    public void LoadChapter3()
    {
        SceneManager.LoadScene("Chapter 3");
    }

    public void LoadChapter4()
    {
        SceneManager.LoadScene("Chapter 4");
    }

    public void LoadChapter5()
    {
        SceneManager.LoadScene("Chapter 5");
    }
}
