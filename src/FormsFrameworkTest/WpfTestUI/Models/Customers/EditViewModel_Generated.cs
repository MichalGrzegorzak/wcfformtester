
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
  }
}
	