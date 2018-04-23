Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace DataContextWpfSample
	Public Class DataStoreModel
		Private privateConnectionString As String
		Public Property ConnectionString() As String
			Get
				Return privateConnectionString
			End Get
			Set(ByVal value As String)
				privateConnectionString = value
			End Set
		End Property

		Public Sub New(ByVal connection As String)
			ConnectionString = connection
		End Sub
	End Class
End Namespace
