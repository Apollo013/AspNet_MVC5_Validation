# AspNet_MVC5_Validation

An MVC5 app demonstrating various validation implementations using remote, custom & builtin attributes, along with jQuery unobtrusive validation

---

Developed with Visual Studio 2015 Community

---

###Techs
|Tech|
|----|
|C#|
|MVC5|
|jQuery|
|Bootstrap|

---

#### REMOTE VALIDATION
This example uses the 'Remote' attribute to check if an email already exists. A list of pre-defined emails has been specified, so using either "Henry@gmail.com", "Mary@gmail.com", "Philip@gmail.com" or "John@gmail.com" will display an error.

This example also uses built-in MVC validation attributes & jQuery unobtrusive validation.

Navigate to 'http://localhost:[YOUR_PORT_HERE]/User/Register', and enter a name and one of the above emails.

##### CODE FILES: 'RegisterVM', 'UserController' & 'Register.cshtml'

---

#### CUSTOM PHONE MASK VALIDATION

This example shows how to create a custom validator that derives from 'ValidationAttribute' and implements 'IClientValidatable'. It's purpose is to ensure that a provided phone number matches a specified pattern.

jQuery unobtrusive validation also demonstrated.

Navigate to 'http://localhost:[YOUR_PORT_HERE]/User'.

##### CODE FILES: 'User', 'UserController', 'PhoneMaskValidationAttribute' & 'Index.cshtml'

---

#### CUSTOM PHONE MASK VALIDATION

This example shows how to create a custom validator that derives from 'ValidationAttribute' and implements 'IClientValidatable'. It's purpose is to ensure that a specified date is within a certain range.

jQuery unobtrusive validation also demonstrated.

Navigate to 'http://localhost:[YOUR_PORT_HERE]/User'.

##### CODE FILES: 'User', 'UserController', 'DateRangeAttribute' & 'Index.cshtml'

---

###Resources
|Title|Author|Website|
|-----|------|-------|
|[Remote Validation In ASP.NET MVC](http://www.c-sharpcorner.com/article/remote-validation-in-asp-net-mvc/)|Vithal Wadje|C# Corner|
|[The Complete Guide To Validation In ASP.NET MVC](http://www.devtrends.co.uk/blog/the-complete-guide-to-validation-in-asp.net-mvc-3-part-1)||DevTrends|
