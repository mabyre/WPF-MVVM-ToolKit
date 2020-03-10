*** 24/05/2019
it's a bit of a mess I can't really say if I work with Prism or the other MvvM Framework
it is therefore more didactic than operational

*** 21/02/2017
I try to work on an example "static"

I end up with the missing Log4Net DLL and I don't want it managed by NuGet because they become really unmanageable so I created the "Assemblies" directory to put log4net.dll

*** Packages - Released - 27/10/2016
PM> Install-Package Unity -Version 2.1.505.2
PM> Install-Package Prism -Version 4.0.0
PM> Install-Package Prism.UnityExtensions -Version 4.1.0

***
v0.1 Project cleaning after delivery
WPF Real Time Application gives the possibility to change the theme I would like to do it too ...
SelectedDataItem stop me, I want to try to use a Prism object rather ...

Creation of the FrameworkMvvm project later renamed to MvvmFramework

Simple Wpf transformation in Prims
Unity bootstrapper added

**********************
*** How it works ? ***
**********************
Add an Item into : WPFPrismToolKit\Shell.xaml
<TreeView x:Name="TreeViewMain"
	<TreeViewItem Header="HelloWorld"/>
	
Simplest possible interface, add an example as quickly as possible:
A View and a ViewModel

Don't do in Shell.xaml :
<TreeViewItem Header="MySampleView" IsSelected="True"/>
L'objet n'est pas encore utilisable.

Better do into Shell.xaml.cs like this :
protected override void OnSourceInitialized( EventArgs e )
{
	ContentControlMain.Content = new HelloWorld();

    // Make TreeView Item Selected
    foreach (TreeViewItem tvi in TreeViewMain.Items)
    {
        if (tvi.Header.ToString() == "MySampleView")
        {
            tvi.IsSelected = true;
            break;
        }
    }

