# Auth Demo

This is a simple demo app that shows how to use authentication in .Net Core. When the user tries to access the Secret page, they get redirected to a login page. There's also a signup page at /account/signup.

A few things to look out for:

When referencing BCrypt in the data class library, make sure to reference BCrypt.Net-Next from Nuget:

<img width="1144" alt="image" src="https://github.com/LITW11/AuthDemo/assets/159099703/9259f1a9-52d0-45fe-a9c0-b328d3c85c2e">

Here are the relevant pieces of code needed to make this work. First, you need to set up Authentication in the `Program.cs` file:

https://github.com/LITW11/AuthDemo/blob/master/AuthDemo.Web/Program.cs#L5
https://github.com/LITW11/AuthDemo/blob/master/AuthDemo.Web/Program.cs#L11-L17
https://github.com/LITW11/AuthDemo/blob/master/AuthDemo.Web/Program.cs#L37-L38

Then, to actually log a user in, here's the code needed for that (in the `AccountController.cs`):

https://github.com/LITW11/AuthDemo/blob/master/AuthDemo.Web/Controllers/AccountController.cs#L46-L54

To check if a user is logged in, you can use the `User.Identity.IsAuthenticated` property, and to get the currently logged in users email, you can do `User.Identity.Name`. This can be done either in the controller or in the view.

To log out a user, do the following:

https://github.com/LITW11/AuthDemo/blob/master/AuthDemo.Web/Controllers/AccountController.cs#L59-L63

To only give logged in users access to a specific page, use the `[Authorize]` attribute:

https://github.com/LITW11/AuthDemo/blob/master/AuthDemo.Web/Controllers/HomeController.cs#L30
