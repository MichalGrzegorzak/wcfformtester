
using System.ComponentModel;

namespace WpfTestUI.Models.Customers
{
  public partial class EditViewModel  
  {
	

    private string _firstName = null;
    public static readonly string FirstNameProperty = "FirstName";
    public string FirstName
    {
	    get { return _firstName; }
	    set
	    {
			if (_firstName == value)
				return;
			_firstName = value;
        
			OnFirstNameChanged(value);
			NotifyChanged(FirstNameProperty);
	    }
    }
    
    /// <summary>
    /// Invoked when the value of FirstName changes
    /// </summary>
    partial void OnFirstNameChanged(string value);


    private string _borderColor = null;
    public static readonly string BorderColorProperty = "BorderColor";
    public string BorderColor
    {
	    get { return _borderColor; }
	    set
	    {
			if (_borderColor == value)
				return;
			_borderColor = value;
        
			OnBorderColorChanged(value);
			NotifyChanged(BorderColorProperty);
	    }
    }
    
    /// <summary>
    /// Invoked when the value of BorderColor changes
    /// </summary>
    partial void OnBorderColorChanged(string value);
  }
}
	