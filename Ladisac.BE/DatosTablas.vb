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
Partial Public Class DatosTablas
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DTA_NOMBRE_TABLA As string = "DTA_NOMBRE_TABLA"
				public shared DTA_CAMPO_TABLA As string = "DTA_CAMPO_TABLA"
				public shared DTA_VALOR_TABLA As string = "DTA_VALOR_TABLA"
				public shared DTA_VALOR_VISTA As string = "DTA_VALOR_VISTA"
				public shared DTA_PRINCIPAL As string = "DTA_PRINCIPAL"
				public shared DTA_ESTADO As string = "DTA_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property DTA_NOMBRE_TABLA() As String
        Get
            Return _dTA_NOMBRE_TABLA
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTA_NOMBRE_TABLA, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DTA_NOMBRE_TABLA' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dTA_NOMBRE_TABLA = value
                OnPropertyChanged("DTA_NOMBRE_TABLA")
            End If
        End Set
    End Property

    Private _dTA_NOMBRE_TABLA As String

    <DataMember()>
    Public Property DTA_CAMPO_TABLA() As String
        Get
            Return _dTA_CAMPO_TABLA
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTA_CAMPO_TABLA, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DTA_CAMPO_TABLA' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dTA_CAMPO_TABLA = value
                OnPropertyChanged("DTA_CAMPO_TABLA")
            End If
        End Set
    End Property

    Private _dTA_CAMPO_TABLA As String

    <DataMember()>
    Public Property DTA_VALOR_TABLA() As Integer
        Get
            Return _dTA_VALOR_TABLA
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dTA_VALOR_TABLA, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DTA_VALOR_TABLA' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dTA_VALOR_TABLA = value
                OnPropertyChanged("DTA_VALOR_TABLA")
            End If
        End Set
    End Property

    Private _dTA_VALOR_TABLA As Integer

    <DataMember()>
    Public Property DTA_VALOR_VISTA() As String
        Get
            Return _dTA_VALOR_VISTA
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTA_VALOR_VISTA, value) Then
                _dTA_VALOR_VISTA = value
                OnPropertyChanged("DTA_VALOR_VISTA")
            End If
        End Set
    End Property

    Private _dTA_VALOR_VISTA As String

    <DataMember()>
    Public Property DTA_PRINCIPAL() As Boolean
        Get
            Return _dTA_PRINCIPAL
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dTA_PRINCIPAL, value) Then
                _dTA_PRINCIPAL = value
                OnPropertyChanged("DTA_PRINCIPAL")
            End If
        End Set
    End Property

    Private _dTA_PRINCIPAL As Boolean

    <DataMember()>
    Public Property DTA_ESTADO() As Boolean
        Get
            Return _dTA_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dTA_ESTADO, value) Then
                _dTA_ESTADO = value
                OnPropertyChanged("DTA_ESTADO")
            End If
        End Set
    End Property

    Private _dTA_ESTADO As Boolean

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
