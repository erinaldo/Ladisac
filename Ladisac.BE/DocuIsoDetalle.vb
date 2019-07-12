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
<KnownType(GetType(DocuIso))>
Partial Public Class DocuIsoDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DID_ID As string = "DID_ID"
				public shared DIS_ID As string = "DIS_ID"
				public shared DID_DESCRIPCION As string = "DID_DESCRIPCION"
				public shared DID_MARCA As string = "DID_MARCA"
		    End Structure
	



    <DataMember()>
    Public Property DID_ID() As Integer
        Get
            Return _dID_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dID_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DID_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dID_ID = value
                OnPropertyChanged("DID_ID")
            End If
        End Set
    End Property

    Private _dID_ID As Integer

    <DataMember()>
    Public Property DIS_ID() As Nullable(Of Integer)
        Get
            Return _dIS_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dIS_ID, value) Then
                ChangeTracker.RecordOriginalValue("DIS_ID", _dIS_ID)
                If Not IsDeserializing Then
                    If DocuIso IsNot Nothing AndAlso Not Equals(DocuIso.DIS_ID, value) Then
                        DocuIso = Nothing
                    End If
                End If
                _dIS_ID = value
                OnPropertyChanged("DIS_ID")
            End If
        End Set
    End Property

    Private _dIS_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DID_DESCRIPCION() As String
        Get
            Return _dID_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_dID_DESCRIPCION, value) Then
                _dID_DESCRIPCION = value
                OnPropertyChanged("DID_DESCRIPCION")
            End If
        End Set
    End Property

    Private _dID_DESCRIPCION As String

    <DataMember()>
    Public Property DID_MARCA() As String
        Get
            Return _dID_MARCA
        End Get
        Set(ByVal value As String)
            If Not Equals(_dID_MARCA, value) Then
                _dID_MARCA = value
                OnPropertyChanged("DID_MARCA")
            End If
        End Set
    End Property

    Private _dID_MARCA As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DocuIso() As DocuIso
        Get
            Return _docuIso
        End Get
        Set(ByVal value As DocuIso)
            If _docuIso IsNot value Then
                Dim previousValue As DocuIso = _docuIso
                _docuIso = value
                FixupDocuIso(previousValue)
                OnNavigationPropertyChanged("DocuIso")
            End If
        End Set
    End Property

    Private _docuIso As DocuIso


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
        DocuIso = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupDocuIso(ByVal previousValue As DocuIso, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DocuIsoDetalle.Contains(Me) Then
            previousValue.DocuIsoDetalle.Remove(Me)
        End If

        If DocuIso IsNot Nothing Then
            If Not DocuIso.DocuIsoDetalle.Contains(Me) Then
                DocuIso.DocuIsoDetalle.Add(Me)
            End If

            DIS_ID = DocuIso.DIS_ID
        ElseIf Not skipKeys Then
            DIS_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DocuIso") AndAlso
                ChangeTracker.OriginalValues("DocuIso") Is DocuIso Then
                ChangeTracker.OriginalValues.Remove("DocuIso")
            Else
                ChangeTracker.RecordOriginalValue("DocuIso", previousValue)
            End If
            If DocuIso IsNot Nothing AndAlso Not DocuIso.ChangeTracker.ChangeTrackingEnabled Then
                DocuIso.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class