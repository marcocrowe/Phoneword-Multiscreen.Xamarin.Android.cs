namespace Phoneword
{
	using Android.App;
	using Android.OS;
	using Android.Widget;
	using System;
	using System.Collections.Generic;
	[Activity(Label = "@string/TranslationHistoryButton_Text")]
	public class TranslationHistoryActivity : ListActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			IList<String> phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new String[0];
			this.ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);
		}
	}
}