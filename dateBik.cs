// Opens an android date picker dialog and grabs the result using a callback.
using UnityEngine;
using System;

class dateBik : MonoBehaviour
{

	//эти значения нам пригодятся для выставления данных на выведенном меню
	private static DateTime selectedDate = DateTime.Now;
	private static int minutes = selectedDate.Minute;
	private static int hours = selectedDate.Hour;
	
	
	//для ввода даты	
	class DateCallback : AndroidJavaProxy
	{
		//тут мы вызываем интерфейс, ссылка на доки по андройду
		//https://developer.android.com/reference/android/app/DatePickerDialog
		//интерфейс выглядит так:
		//public static interface DatePickerDialog.OnDateSetListener
		//меняем в нем "." на "$"		
		public DateCallback() : base("android.app.DatePickerDialog$OnDateSetListener") {}
		
		//эта строка возвращает нам введенное значение от метода onDateSet(DatePicker view, int year, int month, int dayOfMonth)
		void onDateSet(AndroidJavaObject view, int year, int monthOfYear, int dayOfMonth)
		{
			//записываем в нашу дату
			selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
		}
	}
	
	//для ввода времени	
	class TimeCallback : AndroidJavaProxy
	{
		//тут мы вызываем интерфейс, ссылка на доки по андройду
		//https://developer.android.com/reference/android/app/TimePickerDialog
		//интерфейс выглядит так:
		//public static interface DatePickerDialog.OnTimeSetListener
		//меняем в нем "." на "$"	
		public TimeCallback() : base("android.app.TimePickerDialog$OnTimeSetListener") {}
		
		//эта строка возвращает нам введенное значение от метода onTimeSet(TimePicker view, int hourOfDay, int minute)
		void onTimeSet(AndroidJavaObject view, int hourOfDay, int minute)
		{
			//тут можно будет использовать и переменную даты
			minutes = minute;
			hours = hourOfDay;
		}
	}
	
	
	//вызов меню
	public static void ShowDatePickerDialog()
	{
		//тут делаем системный вызов
		AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
		activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
		{
			// вызываем "android.app.DatePickerDialog" - системный диалог 
			//new DateCallback() - то куда данные отправятсся по итогу
			//selectedDate.Year, selectedDate.Month - 1, selectedDate.Day - данные которые мы увидем в меню
			// конструктор можно взять любой из тех, что нам предлагают https://developer.android.com/reference/android/app/DatePickerDialog
		new AndroidJavaObject("android.app.DatePickerDialog", activity, new DateCallback(), selectedDate.Year, selectedDate.Month - 1, selectedDate.Day).Call("show");
		}));
	}
	
	public static void ShowTimePickerDialog()
	{
		
		AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
		activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
		{
			
		// вызываем "android.app.DatePickerDialog" - системный диалог 
		//new DateCallback() - то куда данные отправятсся по итогу
		//hours, minutes, true - данные которые мы увидем в меню
		//конструктор можно взять любой из тех, что нам предлагают https://developer.android.com/reference/android/app/TimePickerDialog
		new AndroidJavaObject("android.app.TimePickerDialog", activity, new TimeCallback(), hours, minutes, true).Call("show");
		}));
	}
	
		
	public void getTime()
	{
	}
	public void getDate()
	{
	}
	
}