Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Namespace DataContextWpfSample

	Public Class DataStoreViewModel
		Private dataStore As DataStoreModel

		Public Sub New(ByVal dataStore As DataStoreModel)
			If dataStore Is Nothing Then
				Throw New ArgumentNullException("dataStore")
			End If
			Me.dataStore = dataStore
		End Sub
		Public ReadOnly Property ModelConnectionString() As String
			Get
				Return dataStore.ConnectionString
			End Get
		End Property
	End Class
End Namespace
