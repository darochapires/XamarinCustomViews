using System;
using Foundation;
using UIKit;

[Register("PlaceholderTextView")]
public class PlaceholderTextView : UITextView
{
    public string Placeholder { get; set; }
    public UIColor PlaceholderColor { get; set; }
    public UIColor DefaultTextColor { get; set; }

    public PlaceholderTextView(IntPtr handle) : base(handle)
    {
        DefinePlaceholder();
    }

    protected void DefinePlaceholder()
    {
        Placeholder = "Insert text";

        //iOS default colors for text and placeholders
        PlaceholderColor = UIColor.FromRGB(199f / 255f, 199f / 255f, 205f / 255f);
        DefaultTextColor = UIColor.Black;

        ShouldBeginEditing = (textView) =>
        {
            if (Text.Equals(Placeholder))
            {
                Text = string.Empty;
                TextColor = DefaultTextColor;
            }
            return true;
        };

        ShouldEndEditing = (textView) =>
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                Text = Placeholder;
                TextColor = PlaceholderColor;
            }
            return true;
        };
    }

    /// <summary>
    /// Defines the placeholder.
    /// Call this method if you want to change the placeholder text and/or color
    /// </summary>
    /// <param name="placeholder">Placeholder text</param>
    /// <param name="placeholderColor">Placeholder color</param>
    public void DefinePlaceholder(string placeholder, UIColor defaultTextColor = null, UIColor placeholderColor = null)
    {
        Placeholder = placeholder;
        if (placeholderColor != null)
        {
            PlaceholderColor = placeholderColor;
        }
        if (defaultTextColor != null)
        {
            DefaultTextColor = defaultTextColor;
        }
        if (string.IsNullOrWhiteSpace(Text))
        {
            Text = Placeholder;
            TextColor = PlaceholderColor;
        }
    }
}