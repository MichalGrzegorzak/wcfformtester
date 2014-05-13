
using System.ComponentModel;
using CODE.Framework.Wpf.Mvvm;

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


    private bool _isValid = false;
    public static readonly string IsValidProperty = "IsValid";
    public bool IsValid
    {
	    get { return _isValid; }
	    set
	    {
			if (_isValid == value)
				return;
			_isValid = value;
        
			OnIsValidChanged(value);
			NotifyChanged(IsValidProperty);
	    }
    }
    
    /// <summary>
    /// Invoked when the value of IsValid changes
    /// </summary>
    partial void OnIsValidChanged(bool value);


    private ViewAction _actionSave = null;
    public static readonly string ActionSaveProperty = "ActionSave";
    public ViewAction ActionSave
    {
	    get { return _actionSave; }
	    set
	    {
			if (_actionSave == value)
				return;
			_actionSave = value;
        
			OnActionSaveChanged(value);
			NotifyChanged(ActionSaveProperty);
	    }
    }
    
    /// <summary>
    /// Invoked when the value of ActionSave changes
    /// </summary>
    partial void OnActionSaveChanged(ViewAction value);
  }
}
	