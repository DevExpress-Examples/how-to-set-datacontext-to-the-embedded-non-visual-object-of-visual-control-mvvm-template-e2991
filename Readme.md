<!-- default file list -->
*Files to look at*:

* [DataContextBinder.cs](./CS/DataContextBinder.cs) (VB: [DataContextBinder.vb](./VB/DataContextBinder.vb))
* [InnerClasses.cs](./CS/InnerClasses.cs) (VB: [InnerClasses.vb](./VB/InnerClasses.vb))
* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [Model.cs](./CS/Model.cs) (VB: [Model.vb](./VB/Model.vb))
* [ViewClasses.cs](./CS/ViewClasses.cs) (VB: [ViewClasses.vb](./VB/ViewClasses.vb))
* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))
<!-- default file list end -->
# How to set DataContext to the embedded non-visual object of visual control (MVVM template)


<p>This example presents a technique used to set the DataContext to an internal non-visual object if the application is built upon MVVM template. <br />
To accomplish this task, a new class DataContextBinder is implemented. It tracks changes of the owner context and notifies the owner that the new context settings should be applied to inner objects. An instance of this class is created in the visual control constructor. The visual control itself implements the IDataContextOwner interface providing the ability for the DataContext setting to propagate to the objects not contained in the visual tree.<br />
</p>

<br/>


