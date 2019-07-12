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
<KnownType(GetType(Personas))>
<KnownType(GetType(Rubro))>
Partial Public Class RubroPersona
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared RUP_ID As string = "RUP_ID"
				public shared PER_ID As string = "PER_ID"
				public shared RUB_ID As string = "RUB_ID"
				public shared USU_ID As string = "USU_ID"
				public shared RUP_FEC_GRAB As string = "RUP_FEC_GRAB"
				public shared RUP_ESTADO As string = "RUP_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property RUP_ID() As Integer
        Get
            Return _rUP_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_rUP_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'RUP_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _rUP_ID = value
                OnPropertyChanged("RUP_ID")
            End If
        End Set
    End Property

    Private _rUP_ID As Integer

    <DataMember()>
    Public Property PER_ID() As String
        Get
            Return _pER_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID", _pER_ID)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID = value
                OnPropertyChanged("PER_ID")
            End If
        End Set
    End Property

    Private _pER_ID As String

    <DataMember()>
    Public Property RUB_ID() As Integer
        Get
            Return _rUB_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_rUB_ID, value) Then
                ChangeTracker.RecordOriginalValue("RUB_ID", _rUB_ID)
                If Not IsDeserializing Then
                    If Rubro IsNot Nothing AndAlso Not Equals(Rubro.RUB_ID, value) Then
                        Rubro = Nothing
                    End If
                End If
                _rUB_ID = value
                OnPropertyChanged("RUB_ID")
            End If
        End Set
    End Property

    Private _rUB_ID As Integer

    <DataMember()>
    Public Property USU_ID() As String
        Get
            Return _uSU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID, value) Then
                _uSU_ID = value
                OnPropertyChanged("USU_ID")
            End If
        End Set
    End Property

    Private _uSU_ID As String

    <DataMember()>
    Public Property RUP_FEC_GRAB() As Date
        Get
            Return _rUP_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_rUP_FEC_GRAB, value) Then
                _rUP_FEC_GRAB = value
                OnPropertyChanged("RUP_FEC_GRAB")
            End If
        End Set
    End Property

    Private _rUP_FEC_GRAB As Date

    <DataMember()>
    Public Property RUP_ESTADO() As Boolean
        Get
            Return _rUP_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_rUP_ESTADO, value) Then
                _rUP_ESTADO = value
                OnPropertyChanged("RUP_ESTADO")
            End If
        End Set
    End Property

    Private _rUP_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Personas() As Personas
        Get
            Return _personas
        End Get
        Set(ByVal value As Personas)
            If _personas IsNot value Then
                Dim previousValue As Personas = _personas
                _personas = value
                FixupPersonas(previousValue)
                OnNavigationPropertyChanged("Personas")
            End If
        End Set
    End Property

    Private _personas As Personas


    <DataMember()>
    Public Property Rubro() As Rubro
        Get
            Return _rubro
        End Get
        Set(ByVal value As Rubro)
            If _rubro IsNot value Then
                Dim previousValue As Rubro = _rubro
                _rubro = value
                FixupRubro(previousValue)
                OnNavigationPropertyChanged("Rubro")
            End If
        End Set
    End Property

    Private _rubro As Rubro


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
        Personas = Nothing
        Rubro = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPersonas(ByVal previousValue As Personas)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.RubroPersona.Contains(Me) Then
            previousValue.RubroPersona.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.RubroPersona.Contains(Me) Then
                Personas.RubroPersona.Add(Me)
            End If

            PER_ID = Personas.PER_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Personas") AndAlso
                ChangeTracker.OriginalValues("Personas") Is Personas Then
                ChangeTracker.OriginalValues.Remove("Personas")
            Else
                ChangeTracker.RecordOriginalValue("Personas", previousValue)
            End If
            If Personas IsNot Nothing AndAlso Not Personas.ChangeTracker.ChangeTrackingEnabled Then
                Personas.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupRubro(ByVal previousValue As Rubro)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.RubroPersona.Contains(Me) Then
            previousValue.RubroPersona.Remove(Me)
        End If

        If Rubro IsNot Nothing Then
            If Not Rubro.RubroPersona.Contains(Me) Then
                Rubro.RubroPersona.Add(Me)
            End If

            RUB_ID = Rubro.RUB_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Rubro") AndAlso
                ChangeTracker.OriginalValues("Rubro") Is Rubro Then
                ChangeTracker.OriginalValues.Remove("Rubro")
            Else
                ChangeTracker.RecordOriginalValue("Rubro", previousValue)
            End If
            If Rubro IsNot Nothing AndAlso Not Rubro.ChangeTracker.ChangeTrackingEnabled Then
                Rubro.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
