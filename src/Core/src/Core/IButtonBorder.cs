﻿using Microsoft.Maui.Graphics;

namespace Microsoft.Maui
{
	/// <summary>
	/// Define how the Button border is painted.
	/// </summary>
	public interface IButtonBorder
	{
		/// <summary>
		///	Gets a color that describes the border stroke color of the button.
		/// </summary>
		Color BorderColor { get; }

		/// <summary>
		/// Gets or sets the width of the border.
		/// </summary>
		double BorderWidth { get; }

		/// <summary>
		/// Gets the corner radius for the button, in device-independent units.
		/// </summary>
		int CornerRadius { get; }
	}
}