using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace Rishabh_Assignment.Behaviour
{
    class EmailValidation: Behavior<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        public EmailValidation()
        {
        }
       

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += HandleTextChanged;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= HandleTextChanged;
        }
        void HandleTextChanged(Object sender, TextChangedEventArgs args)
        {
            bool IsValid = false;
            IsValid = Regex.IsMatch(args.NewTextValue, emailRegex,
                RegexOptions.IgnoreCase, TimeSpan.FromSeconds(250));
            ((Entry)sender).TextColor = IsValid ? Color.Black : Color.Red;
        }
    }
}
