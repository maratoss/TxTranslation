﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Globalization;
using TxLib;
using System.Windows.Media;

namespace TxEditor.ViewModel
{
	class CultureTextViewModel : ViewModelBase
	{
		public TextKeyViewModel TextKeyVM { get; private set; }

		private string cultureName;
		public string CultureName
		{
			get { return cultureName; }
		}

		private string cultureNativeName;
		public string CultureNativeName
		{
			get { return cultureNativeName; }
		}

		private string text;
		public string Text
		{
			get { return text; }
			set
			{
				if (value != text)
				{
					text = value;
					OnPropertyChanged("Text");
				}
			}
		}

		public string CursorChar
		{
			get { return null; }
			set
			{
				TextKeyVM.MainWindowVM.CursorChar = value;
			}
		}

		private bool lastOfLanguage;
		public bool LastOfLanguage
		{
			get { return lastOfLanguage; }
			set
			{
				if (value != lastOfLanguage)
				{
					lastOfLanguage = value;
					OnPropertyChanged("LastOfLanguage");
					if (lastOfLanguage)
					{
						SeparatorBrush = new SolidColorBrush(Color.FromArgb(0x40, 0, 0, 0));
					}
					else
					{
						SeparatorBrush = new SolidColorBrush(Color.FromArgb(0x18, 0, 0, 0));
					}
				}
			}
		}

		private Brush separatorBrush;
		public Brush SeparatorBrush
		{
			get { return separatorBrush; }
			set
			{
				if (value != separatorBrush)
				{
					separatorBrush = value;
					OnPropertyChanged("SeparatorBrush");
				}
			}
		}

		private ObservableCollection<QuantifiedTextViewModel> quantifiedTextVMs;
		public ObservableCollection<QuantifiedTextViewModel> QuantifiedTextVMs
		{
			get
			{
				if (quantifiedTextVMs == null)
				{
					quantifiedTextVMs = new ObservableCollection<QuantifiedTextViewModel>();
				}
				return quantifiedTextVMs;
			}
		}

		public CultureTextViewModel(string cultureName, TextKeyViewModel textKeyVM)
		{
			this.cultureName = cultureName;

			TextKeyVM = textKeyVM;
			LastOfLanguage = true;   // Change value once to set the brush value

			cultureNativeName = Tx.U(CultureInfo.GetCultureInfo(cultureName).NativeName);
		}

		public int CompareTo(CultureTextViewModel other)
		{
			string otherName = other.CultureName;
			if (CultureName.Length >= 2 && otherName.Length >= 2)
			{
				if (string.Compare(CultureName.Substring(0, 2), otherName.Substring(0, 2), StringComparison.InvariantCultureIgnoreCase) == 0)
				{
					// Same language, prefer shorter names (without region)
					if (CultureName.Length != otherName.Length)
					{
						return CultureName.Length - otherName.Length;
						// If this.length < other.length, then the result is negative and this comes before other
					}
				}
			}
			return string.Compare(CultureName, otherName, StringComparison.InvariantCultureIgnoreCase);
		}
	}
}