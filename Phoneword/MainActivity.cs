namespace Phoneword
{
	using Android.App;
	using Android.Content;
	using Android.OS;
	using Android.Widget;
	using Core;
	using System;
	using System.Collections.Generic;
	[Activity(Label = "Phoneword", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceStateBundle)
		{
			base.OnCreate(savedInstanceStateBundle);

			SetContentView(Resource.Layout.Main);

			Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
			Button translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);

			translateButton.Click += new EventHandler(this.TranslateButton_Click);
			translationHistoryButton.Click += new EventHandler(this.TranslationHistoryButton_Click);
		}
		private void TranslateButton_Click(Object sender, EventArgs eventArgs)
		{
			EditText phoneNumberInputEditText = FindViewById<EditText>(Resource.Id.PhoneNumberInputEditText);
			String translatedNumber = PhonewordTranslator.ToNumber(phoneNumberInputEditText.Text);

			TextView translatedPhoneWordTextView = FindViewById<TextView>(Resource.Id.TranslatedPhoneWordTextView);
			if (string.IsNullOrWhiteSpace(translatedNumber))
			{
				translatedPhoneWordTextView.Text = String.Empty;
			}
			else
			{
				translatedPhoneWordTextView.Text = translatedNumber;
				phoneNumbers.Add(translatedNumber);
			}
		}
		private void TranslationHistoryButton_Click(Object sender, EventArgs eventArgs)
		{
			Intent translationHistoryIntent = new Intent(this, typeof(TranslationHistoryActivity));
			translationHistoryIntent.PutStringArrayListExtra(phoneNumbersKey, phoneNumbers);
			StartActivity(translationHistoryIntent);
		}
		#region Fields
		#endregion
		internal readonly static String phoneNumbersKey = "phoneNumbers";
		static readonly List<String> phoneNumbers = new List<String>();
	}
}