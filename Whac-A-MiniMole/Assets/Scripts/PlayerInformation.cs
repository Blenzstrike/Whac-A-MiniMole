/// <summary>
/// Static class that holds all relefant information to the player. Allows all script to use this information.
/// </summary>
public static class PlayerInformation
{
    /// <summary>
    /// Name selected by the player.
    /// </summary>
    public static string Name;
    /// <summary>
    /// Score player got.
    /// </summary>
    public static int Score;
    /// <summary>
    /// Selected difficulty class.
    /// </summary>
    public static DifficultyClass SelectedDifficulty;
    /// <summary>
    /// Information that is saved when the player leaves the application.
    /// </summary>
    public static SaveGameInformation SaveGameInformation;
}
