using UnityEngine.Localization.Settings;

public static class Localization {
	public static string GetString(string table, string key, params object[] args) {
		return LocalizationSettings.StringDatabase.GetLocalizedString(table, key, arguments: args);
	}

	public static string FishName(int id) {
		return LocalizationSettings.StringDatabase.GetLocalizedString("Fishes", id.ToString());
	}

	public static string LocName(int id) {
		return LocalizationSettings.StringDatabase.GetLocalizedString("Location", "location_" + id.ToString());
	}
}
