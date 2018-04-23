Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows

Namespace DataContextWpfSample

	Public Class DataStore
		Inherits FrameworkElement
		Public Shared ReadOnly ConnectionStringProperty As DependencyProperty = DependencyProperty.Register("ConnectionString", GetType(String), GetType(DataStore), New PropertyMetadata(String.Empty))

		Public Property ConnectionString() As String
			Get
				Return CStr(GetValue(ConnectionStringProperty))
			End Get
			Set(ByVal value As String)
				SetValue(ConnectionStringProperty, value)
			End Set
		End Property
	End Class
End Namespace
