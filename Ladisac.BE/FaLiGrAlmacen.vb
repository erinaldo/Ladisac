'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios en este archivo pueden ocasionar un comportamiento incorrecto y se perderán si
'     el código se vuelve a generar.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices

<DataContract(IsReference:=True)>
Partial Public Class FaLiGrAlmacen
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared FLG_ID As string = "FLG_ID"
				public shared FAM_ID As string = "FAM_ID"
				public shared LIN_ID As string = "LIN_ID"
				public shared GLI_ID As string = "GLI_ID"
				public shared ALM_ID As string = "ALM_ID"
		    End Structure
	



    <DataMember()>
    Public Property FLG_ID() As Integer
        Get
            Return _fLG_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_fLG_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'FLG_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _fLG_ID = value
                OnPropertyChanged("FLG_ID")
            End If
        End Set
    End Property

    Private _fLG_ID As Integer

    <DataMember()>
    Public Property FAM_ID() As String
        Get
            Return _fAM_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_fAM_ID, value) Then
                _fAM_ID = value
                OnPropertyChanged("FAM_ID")
            End If
        End Set
    End Property

    Private _fAM_ID As String

    <DataMember()>
    Public Property LIN_ID() As String
        Get
            Return _lIN_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_lIN_ID, value) Then
                _lIN_ID = value
                OnPropertyChanged("LIN_ID")
            End If
        End Set
    End Property

    Private _lIN_ID As String

    <DataMember()>
    Public Property GLI_ID() As String
        Get
            Return _gLI_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_gLI_ID, value) Then
                _gLI_ID = value
                OnPropertyChanged("GLI_ID")
            End If
        End Set
    End Property

    Private _gLI_ID As String

    <DataMember()>
    Public Property ALM_ID() As Nullable(Of Integer)
        Get
            Return _aLM_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aLM_ID, value) Then
                _aLM_ID = value
                OnPropertyChanged("ALM_ID")
            End If
        End Set
    End Property

    Private _aLM_ID As Nullable(Of Integer)

#End Region
#Region "ChangeTracking"

    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        If ChangeTracker.State <> ObjectState.Added AndAlso ChangeTracker.State <> ObjectState.Deleted Then
            ChangeTracker.State = ObjectState.Modified
        End If
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Protected Overridable Sub OnNavigationPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _changeTracker As ObjectChangeTracker

    <DataMember()>
    Public Property ChangeTracker() As ObjectChangeTracker Implements IObjectWithChangeTracker.ChangeTracker
        Get
            If _changeTracker Is Nothing Then
                _changeTracker = New ObjectChangeTracker()
                AddHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
            Return _changeTracker
        End Get
        Set(ByVal value As ObjectChangeTracker)
            If _changeTracker IsNot Nothing Then
                RemoveHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
            _changeTracker = value
            If _changeTracker IsNot Nothing Then
                AddHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
        End Set
    End Property

    Private Sub HandleObjectStateChanging(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.ClearNavigationProperties()
        End If
    End Sub

    Private _isDeserializing As Boolean
    Protected Property IsDeserializing() As Boolean
        Get
            Return _isDeserializing
        End Get
        Private Set(ByVal value As Boolean)
            _isDeserializing = value
        End Set
    End Property

    <OnDeserializing()>
    Public Sub OnDeserializingMethod(ByVal context As StreamingContext)
        IsDeserializing = True
    End Sub

    <OnDeserialized()>
    Public Sub OnDeserializedMethod(ByVal context As StreamingContext)
        IsDeserializing = False
        ChangeTracker.ChangeTrackingEnabled = True
    End Sub

    Protected Overridable Sub ClearNavigationProperties()
    End Sub

#End Region
End Class
