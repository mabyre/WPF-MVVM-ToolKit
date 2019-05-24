*** 21/02/2017
J'essaye de travaillé sur un exemple "static"

Je me retrouve avec la DLL de Log4Net maquante et je ne souhaite pas le faire gérer par NuGet car ils deviennent véritablement ingérables aussi je créé le répertoire "Assemblies" pour y mettre log4net.dll

*** Packages - Miseà jour - 27/10/2016
PM> Install-Package Unity -Version 2.1.505.2
PM> Install-Package Prism -Version 4.0.0
PM> Install-Package Prism.UnityExtensions -Version 4.1.0

***
v0.1 Nettoyage du projet suite à livraison
WPF Real Time Application donne la possiblité de changer le thème je voudrais le faire aussi ...
SelectedDataItem me stop, je veux tenter d'utiliser plutot un objet de Prism ...

Création du projet FrameworkMvvm renommé par la suite en MvvmFramework

Transformation Wpf simple en Prims
Ajout du bootstrapper de Unity

***************************
*** Comment ça marche ? ***
***************************
Ajouter un Item dans : WPFPrismToolKit\Shell.xaml
<TreeView x:Name="TreeViewMain"
	<TreeViewItem Header="HelloWorld"/>

Interface le plus simple possible, ajouter un exemple le plus rapidement possible :
Une View et un ViewModel

Ne pas faire dans Shell.xaml :
<TreeViewItem Header="MySampleView" IsSelected="True"/>
L'objet n'est pas encore utilisable.

Faire plutôt dans Shell.xaml.cs :
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

