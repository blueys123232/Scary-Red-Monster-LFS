using System;

[Serializable]
public class SaveData
{
    public int currentChapter;            // The current chapter the player is on
    public bool[] unlockedChapters;       // An array to track which chapters have been unlocked
    public DateTime lastSaveTime;         // The timestamp of when the game was last saved

    // Constructor to initialize default values
    public SaveData()
    {
        currentChapter = 1;
        unlockedChapters = new bool[10];  // Assuming there are 10 chapters in the game
        unlockedChapters[0] = true;       // The first chapter is unlocked by default
        lastSaveTime = DateTime.Now;      // Set the save time to now
    }

    // Method to unlock a new chapter
    public void UnlockChapter(int chapterIndex)
    {
        if (chapterIndex >= 0 && chapterIndex < unlockedChapters.Length)
        {
            unlockedChapters[chapterIndex] = true;
        }
    }

    // Method to update the current chapter
    public void UpdateCurrentChapter(int chapterIndex)
    {
        if (chapterIndex >= 0 && chapterIndex < unlockedChapters.Length)
        {
            currentChapter = chapterIndex;
        }
    }

    // Method to update the last save time
    public void UpdateLastSaveTime()
    {
        lastSaveTime = DateTime.Now;
    }
}
