# Dynamic Orientation Changes

Simple library for enabling orientation changes animation for Windows Phone 7 Applications. Originaly deveoped by [David Anson](http://blogs.msdn.com/b/delay/archive/2010/09/28/this-one-s-for-you-gregor-mendel-code-to-animate-and-fade-windows-phone-orientation-changes-now-supports-a-new-mode-hybrid.aspx) and merged with solution suggested by [Andy Wigley](http://mobileworld.appamundi.com/blogs/andywigley/archive/2010/11/24/best-of-breed-page-rotation-animations.aspx)

## Features

1. AnimateOrientationChanges
2. FadeOrientationChanges
3. HybridOrientationChanges
4. Working together with WP7 toolkit Transition Animation

## Using

Simplest way for using this libary with NuGet. Folow this steps:

1. Install [package](https://nuget.org/packages/DynamicOrientationChanges)
2. At the  App.xaml.cs file replace folowing line:

		RootFrame = new PhoneApplicationFrame();
   with

        RootFrame = new Delay.AnimateOrientationChangesFrame();
   or

   		RootFrame = new Delay.FadeOrientationChangesFrame();
   or

   		RootFrame = new Delay.HybridOrientationChangesFrame();
   depend on animation type.

Also you can setup animation Duration like this:

		((Delay.AnimateOrientationChangesFrame)RootFrame).Duration = TimeSpan.FromSeconds(0.6);