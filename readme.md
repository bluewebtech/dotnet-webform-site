## Simple Web Site Built With ASP.NET C# Web Forms 

This project is solely for personal learning, nothing more. The purpose of this project is to create a simple web site that consists of real world needs using the web form paradigm available to ASP.NET. Not only that but develop a class library that will later be utilied within another project of my own called Freeway, which is an MVC framework.

## Class Library

Below is a list of helpers that I have begun writing in order to make certain actions less tedious to accomplish. All classes available are obviously being worked on and you can expect much more logic and functionality to be added.

- Format.cs : Contains many methods to help with formatting strings.
- Mail.cs : So far this class contains a single method to send email notifications in either plain text or HTML. It is also possible to use a very basic email template.
- Path.cs : Nothing but a pathing class.
- Strings.cs : Nothing to gloat about yet.
- Template.cs : So far this is a very super simple templating system with the very basics. The goal here is to try and mimic the Blade templating system from the Laravel framework.
- View.cs : An alias of the Template class.