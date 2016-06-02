﻿using NUnit.Framework;

using Xamarin.UITest;

namespace SimpleUITestApp.UITests
{
	public class Tests : AbstractSetup
	{
		public Tests(Platform platform) : base(platform)
		{
			this.platform = platform;
		}

		[Test]
		public void EnterText()
		{
			var textInput = "Hello World";

			FirstPage.EnterText(textInput);
			FirstPage.ClickGo();
			FirstPage.WaitForNoActivityIndicator();

			Assert.AreEqual(FirstPage.GetEntryFieldText(), textInput);
		}

		[Test]
		public void EnterTextByID()
		{
			var textInput = "I used IDs to Enter this Text!";

			FirstPage.EnterTextByID(textInput);
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();

			Assert.AreEqual(FirstPage.GetEntryFieldTextByID(), textInput);
		}

		[Test]
		public void SelectItemOnListView()
		{
			FirstPage.ClickListViewButton();
			ListViewPage.TapListItemNumber(9);
		}

		[Test]
		public void SelectItemOnListViewByID()
		{
			FirstPage.ClickListViewButtonByID();
			ListViewPage.TapListItemNumber(9);
		}

		[Test]
		public void RotateScreenAndEnterTextByID()
		{
			var entryTextLandcape = "The Screen Orientation Is Landscape";
			var entryTextPortrait = "The Screen Orientation Is Portrait";

			FirstPage.RotateScreenToLandscape();
			FirstPage.EnterText(entryTextLandcape);
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();

			Assert.AreEqual(FirstPage.GetEntryFieldTextByID(), entryTextLandcape);

			FirstPage.RotateScreenToPortrait();
			FirstPage.EnterText(entryTextPortrait);
			FirstPage.ClickGoByID();
			FirstPage.WaitForNoActivityIndicator();

			Assert.AreEqual(FirstPage.GetEntryFieldTextByID(), entryTextPortrait);
		}
	}
}

