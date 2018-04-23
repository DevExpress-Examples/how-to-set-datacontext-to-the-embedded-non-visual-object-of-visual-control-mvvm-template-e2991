Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Data

Namespace DataContextWpfSample

	Public Interface IDataContextOwner
		ReadOnly Property DataContext() As Object
		Sub UpdateInnerDataContext(ByVal dataContext As Object)
	End Interface

	Public Class DataContextBinder
		Inherits DependencyObject
		Private owner As IDataContextOwner
		Public Sub New(ByVal owner As IDataContextOwner)
			If owner Is Nothing Then
				Throw New ArgumentNullException("owner")
			End If
			Me.owner = owner

			InitializeBinding()
		End Sub
		Protected Overridable Sub InitializeBinding()
			Dim binding As New Binding("DataContext")
			binding.Source = owner
			binding.Mode = BindingMode.OneWay

			BindingOperations.SetBinding(Me, DataContextProperty, binding)
		End Sub
		Public Property DataContext() As Object
			Get
				Return CObj(GetValue(DataContextProperty))
			End Get
			Set(ByVal value As Object)
				SetValue(DataContextProperty, value)
			End Set
		End Property
		Public Shared ReadOnly DataContextProperty As DependencyProperty = DependencyProperty.Register("DataContext", GetType(Object), GetType(DataContextBinder), New PropertyMetadata(Nothing, New PropertyChangedCallback(AddressOf OnDataContextChanged)))

		Public Shared Sub OnDataContextChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			CType(d, DataContextBinder).OnDataContextChanged(e.OldValue, e.NewValue)
		End Sub
		Private Sub OnDataContextChanged(ByVal oldValue As Object, ByVal newValue As Object)
			owner.UpdateInnerDataContext(newValue)
		End Sub
	End Class

End Namespace
