using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using AutoMapper;
using CODE.Framework.Wpf.Mvvm;
using Core.DAL;
using Core.Entity;
using FluentValidation;
using FormsFrameworkTest.Logic;
using Magellan.Framework;
using Snippets;

namespace WpfTestUI.Models.Customers
{
    public class EditViewModelValidator : AbstractValidator<EditViewModel>
    {
        public EditViewModelValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 200).WithMessage(
                "Name can`t be empty");
        }
    }

    [SnippetPropertyINPC(field = "_firstName", property = "FirstName")]
    [SnippetPropertyINPC(field = "_borderColor", property = "BorderColor")]
    public partial class EditViewModel : ViewModel, IDataErrorInfo, IStoreValidationMessages
    {
        private CustomerRepo _repo;
        public bool IsLoaded { get; set; }
        public string Title { get; set; }

        public EditViewModel()
        {
            Actions.Add(new ViewAction("Save", execute: (a, o) => Save(), category: "Customer"));
            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true, category: "Customer"));
            //Actions.Add(new ViewAction("Save", execute: (a, o) => Save()));
            //Actions.Add(new CloseCurrentViewAction(this, beginGroup: true));
            
            _repo = new CustomerRepo();
            BorderColor = Colors.Green.ToString();
            Title = "HIHI";

            AttachingEvents();
        }

        private void AttachingEvents()
        {
            this.Opened += (sender, args) => IsLoaded = true;

            this.PropertyChanged += (sender, args) =>
            {
                if (!IsLoaded) return;
                BorderColor = Colors.Red.ToString();
            };
        }

        public void LoadData(int id)
        {
            var customer = _repo.GetById(id);
            //FirstName = "Markus";
            //LastName = "Egger";
            //Company = "EPS/CODE";
            //SearchName = "Markus Egger";

            //Web = "www.codemag.com";
            //Email = "info@codemag.com";
        }

        public void Save()
        {
            //MessageBox.Show("Prentending to saving...");
            Customer c = Mapper.Map<Customer>(this);
            _repo.AddOrUpdate(c);

            Mediator.Instance.NotifyColleagues(ViewModelMessages.DataChanged, c);
        }

        public int Id { get; set; }
        //public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string SearchName { get; set; }

        public string Web { get; set; }
        public string Email { get; set; }

        public string SomeOtherField1 { get; set; }
        public string SomeOtherField2 { get; set; }
        public string SomeOtherField3 { get; set; }
        public string SomeOtherField4 { get; set; }
        public string SomeOtherField5 { get; set; }

        public static EditViewModel Create(int id)
        {
            var repo = new CustomerRepo();
            var customer = repo.GetById(id);
            return Mapper.Map<EditViewModel>(customer);
        }

        private readonly ValidationMessageDictionary validationMessages = new ValidationMessageDictionary();

        /// <summary>
        /// Gets the validation messages associated with this object.
        /// </summary>
        /// <value>The validation messages.</value>
        public virtual ValidationMessageDictionary ValidationMessages
        {
            get { return validationMessages; }
        }

        /// <summary>
        /// Gets a string containing the validation messages for a particular key (usually a property name), with each message seperated
        /// </summary>
        public virtual string this[string columnName]
        {
            get
            {
                Validate(this);
                return string.Join(Environment.NewLine, ValidationMessages[columnName].ToArray());
            }
        }

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        if (columnName == FirstNameProperty)
        //        {
        //            if (this.FirstName.Length < 10)
        //                return "The first name must be < 10";
        //        }
        //        return string.Empty;
        //    }
        //}

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public virtual string Error
        {
            get { return string.Join(Environment.NewLine, ValidationMessages.AllMessages()); }
        }

        protected virtual IValidator CreateValidator()
        {
            return (IValidator)Activator.CreateInstance(typeof(EditViewModelValidator));
        }

        public void Validate(IStoreValidationMessages model)
        {
            var validator = CreateValidator();

            var result = validator.Validate(model);

            var store = model as IStoreValidationMessages;
            if (store != null)
            {
                store.ValidationMessages.Clear();
                foreach (var error in result.Errors)
                {
                    store.ValidationMessages.Add(error.PropertyName, error.ErrorMessage);
                }
            }

            //if (!result.IsValid)
            //{
            //    var flasher = model as IFlasher;
            //    if (flasher != null)
            //    {
            //        flasher.ClearFlashes();
            //        flasher.Flash("Please ensure all fields have been entered correctly.");
            //    }

            //    context.OverrideResult = new DoNothingResult();
            //}
        }
    }

    public interface IStoreValidationMessages
    {
        /// <summary>
        /// Gets the validation messages associated with this object.
        /// </summary>
        /// <value>The validation messages.</value>
        ValidationMessageDictionary ValidationMessages { get; }
    }
}
