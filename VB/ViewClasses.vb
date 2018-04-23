Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Controls
Imports System.Windows
Imports System.Windows.Data

Namespace DataContextWpfSample

	Public Class SomeVisualControl
		Inherits Control
		Implements IDataContextOwner
		Private dataContextBinder As DataContextBinder

		Public Sub New()
			Me.dataContextBinder = New DataContextBinder(Me)
			'this.DataContextChanged += new DependencyPropertyChangedEventHandler(SomeVisualControl_DataContextChanged);
		End Sub
		Private Sub SomeVisualControl_DataContextChanged(ByVal sender As Object, ByVal e As DependencyPropertyChangedEventArgs)
			 'InnerDataStore.DataContext = e.NewValue;
		End Sub
		Public Shared ReadOnly InnerDataStoreProperty As DependencyProperty = DependencyProperty.Register("InnerDataStore", GetType(DataStore), GetType(SomeVisualControl), New PropertyMetadata(Nothing))

		Public Property InnerDataStore() As DataStore
			Get
				Return CType(GetValue(InnerDataStoreProperty), DataStore)
			End Get
			Set(ByVal value As DataStore)
				SetValue(InnerDataStoreProperty, value)
			End Set
		End Property


		Private ReadOnly Property IDataContextOwner_DataContext() As Object Implements IDataContextOwner.DataContext
			Get
				Return DataContext
			End Get
		End Property
		Private Sub UpdateInnerDataContext(ByVal dataContext As Object) Implements IDataContextOwner.UpdateInnerDataContext
			If InnerDataStore IsNot Nothing Then
				InnerDataStore.DataContext = dataContext
			End If
		End Sub
	End Class

End Namespace
