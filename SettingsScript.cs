using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class SettingsScript : MonoBehaviour
{

	public static int screenResolution = 3;
	// defaultowy wybór rozdzielczości ekranu
	public bool isFullScreen = false;
	// bool czy wybieramy w oknie, czy full screen

	public static int qualityLevel = 0;
	//pomocniczy int, dzięki, któremu łatwiej się odnieść do poizomu grafiki

	public AudioMixer audioMixer;

	UnityStandardAssets.ImageEffects.MotionBlur motionBlur;
	UnityStandardAssets.ImageEffects.Antialiasing antialiansing;

	public Toggle toggleAntialiasing, toggleMotionBlur;
	//klikacz od efektów na kamerze

	void Awake ()
	{
		motionBlur = FindObjectOfType<UnityStandardAssets.ImageEffects.MotionBlur> ().gameObject.GetComponent<MotionBlur> ();
		antialiansing = FindObjectOfType<UnityStandardAssets.ImageEffects.Antialiasing> ().gameObject.GetComponent<Antialiasing> ();
	
	}

	public void ChangeAntialiansing () // metoda od klikania, czy chcemy anti aliasing, czy nie.
	{

		antialiansing.enabled = toggleAntialiasing.isOn;
	}

	public void ChangeToggleMotionBlur () // metoda od klikania, czy chcemy motion blur, czy nie.
	{
		motionBlur.enabled = toggleMotionBlur.isOn;
	}

	public void SetSoundsLevel (float sfxlevel) //ustawienie poziomu "Sounds" w opcjach. W mixerach musza być użyte TAKIE SAME NAZWY STRINGÓW
	{
		audioMixer.SetFloat ("VolumeOfSounds", sfxlevel); //nazwa stringu bardzo ważna!
	}

	public void SetMusicLevel (float musiclevel) //ustawienie poziomu "Music" w opcjach. W mixerach musza być użyte TAKIE SAME NAZWY STRINGÓW
	{
		audioMixer.SetFloat ("VolumeOfMusic", musiclevel); //nazwa stringu bardzo ważna!
	}


	public void ChangeGraphics (int o) //Zmiana grafiki. Low, Mid, High. "Int" zależny od wyboru grafiki
	{
		switch (o) {
		case 0: 
			QualitySettings.SetQualityLevel (0, true);
			qualityLevel = 0; // pomocniczy int, łatwiej się odnieść.
			motionBlur.enabled = false;
			break;
		case 1: 
			QualitySettings.SetQualityLevel (3, true);
			qualityLevel = 1;
			motionBlur.enabled = true;
			break;
		case 2:
			QualitySettings.SetQualityLevel (5, true);
			qualityLevel = 2;
			motionBlur.enabled = true;
			break;
		default:
			break;
		}
	}

	public void ChangeResolution (int i) // Zmiana rozdzielczości ekranów. Wybieramy z dropdownów "int" odpowiedzialny za rozdzielczość.
	{
		switch (i) {
		case 0:
			Screen.SetResolution (640, 480, isWindowed ());
			screenResolution = 0;
			break;
		case 1:
			Screen.SetResolution (800, 600, isWindowed ());
			screenResolution = 1;
			break;
		case 2:
			Screen.SetResolution (1366, 768, isWindowed ());
			screenResolution = 2;
			break;
		case 3:
			Screen.SetResolution (1600, 900, isWindowed ());
			screenResolution = 3;
			break;
		case 4: 
			Screen.SetResolution (1920, 1080, isWindowed ());
			screenResolution = 4;
			break;

		default:
			break;
		}
	}

	private bool isWindowed ()
	{
		return isFullScreen;
	}


	public void ChangeWindow () //metoda odpowiedzialna za full screen i "w oknie".
	{
		isFullScreen = !isFullScreen;
		ChangeResolution (screenResolution);
	}


	

}

/* Dobra, no to tak: 
 * Potrzebujesz na pewno, aby efekty na kamerze były "Togglem". UI -> TOGGLE. Jak wolisz to zrobić na sukawu, możesz w każdej chwili zmienić sobie i dawać wartość po float, ale tak chyba jest spoko.
 * Potrzebujesz stworzyć "AudioMixer". Nazwij go master mixer. Potem dodajesz drugi, nazywasz go "Sounds". W mixerze o nazwie "Master" (klikasz na niego 2x) tworzysz w dziale "Groups" - "Music" i "Sounds.
 * Nastepnie klikasz na Sounds (audio mixera, kliknij na mixera) i przeciągasz go do Mixera zwanego "Master" i upuszczasz. Pojawi się okno, gdzie chcesz go zaaplikować, połączyć. Klikasz dwukrotnie na "sounds". Dzieki temu masz już mixery połączone w łatwy sposób.
 * Potem: We wszystkich audiosourcach grupujesz, czy dany dzwięk jest "Music", czy "Sound". "Klikasz na "Output" i dodajesz wedle uznania.
 * Na prawie koniec: Kliknij na "Master" mixera i potem na grupę "Music". Po prawej stronie w Inspektorze masz "Pitch" i "Volume" i wartość floatową. Klikasz prawym na "Volume" i klikasz "Expose "Volume to script"".
 * Nagle na dole po lewo pojawi się w nawiasie (1) w opcji "Exposed Parameters". Nazwij ją tak jak nazywa się string w skrypcie: "VolumeOfMusic". Nie inaczej! ZRÓB TO SAMO Z GRUPĄ SOUNDS.
 * Skrypt podłaczasz do Canvasu, czy co tam chcesz od opcji. Dodajesz master mixera do Inspectora, gdzie jest "None".
 * Tam gdzie stworzyłeś Slidery klikasz w ich opcje "OnClick" (jak buttony) i dodajesz obiekt z tym skryptem, po czym "No function" zmieniasz na string SetMusicLevel (To samo robisz z SetSoundsLevel).
 * Kurwa się rozpisałem, jak nie czaisz daj znac, filmik nagram :P
 * /*
