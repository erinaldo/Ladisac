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
Partial Public Class CondicionesVentaPersonas
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared PER_ID As string = "PER_ID"
				public shared DOC_ORDEN_COMPRA As string = "DOC_ORDEN_COMPRA"
				public shared USU_ID As string = "USU_ID"
				public shared CVP_FEC_GRAB As string = "CVP_FEC_GRAB"
				public shared CVP_ESTADO As string = "CVP_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property PER_ID() As String
        Get
            Return _pER_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PER_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pER_ID = value
                OnPropertyChanged("PER_ID")
            End If
        End Set
    End Property

    Private _pER_ID As String

    <DataMember()>
    Public Property DOC_ORDEN_COMPRA() As Boolean
        Get
            Return _dOC_ORDEN_COMPRA
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dOC_ORDEN_COMPRA, value) Then
                _dOC_ORDEN_COMPRA = value
                OnPropertyChanged("DOC_ORDEN_COMPRA")
            End If
        End Set
    End Property

    Private _dOC_ORDEN_COMPRA As Boolean

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
    Public Property CVP_FEC_GRAB() As Date
        Get
            Return _cVP_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_cVP_FEC_GRAB, value) Then
                _cVP_FEC_GRAB = value
                OnPropertyChanged("CVP_FEC_GRAB")
            End If
        End Set
    End Property

    Private _cVP_FEC_GRAB As Date

    <DataMember()>
    Public Property CVP_ESTADO() As Boolean
        Get
            Return _cVP_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_cVP_ESTADO, value) Then
                _cVP_ESTADO = value
                OnPropertyChanged("CVP_ESTADO")
            End If
        End Set
    End Property

    Private _cVP_ESTADO As Boolean

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
