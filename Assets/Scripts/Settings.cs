public class Settings
{
    private static string SOUND_ENABLED_KEY = "Sound.Enabled";
    private static string MUSIC_ENABLED_KEY = "Music.Enabled";

    // ========================================

    public static bool SoundEnabled;
    public static bool MusicEnabled;

    // ----------------------------------------

    public static float SoundVolume
    {
        get
        {
            return SoundEnabled ? 1 : 0;
        }
    }

    public static float MusicVolume
    {
        get
        {
            return MusicEnabled ? 1 : 0;
        }
    }

    // ========================================

    // Load settings
    static Settings()
    {
        IniFile ini = new IniFile("Settings");

        SoundEnabled = ini.get(SOUND_ENABLED_KEY, true);
        MusicEnabled = ini.get(MUSIC_ENABLED_KEY, true);
    }

    // Save settings
    public static void save()
    {
        IniFile ini = new IniFile();

        ini.set(SOUND_ENABLED_KEY, SoundEnabled);
        ini.set(MUSIC_ENABLED_KEY, MusicEnabled);

        ini.save("Settings");
    }
}
