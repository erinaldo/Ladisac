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
<KnownType(GetType(DetalleTipoDocumentos))>
<KnownType(GetType(TipoArticulos))>
Partial Public Class RolDetalleTipoDocumentoTipoArticulos
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DTD_ID As string = "DTD_ID"
				public shared TIP_ID As string = "TIP_ID"
				public shared USU_ID As string = "USU_ID"
				public shared RTA_FEC_GRAB As string = "RTA_FEC_GRAB"
				public shared RTA_ESTADO As string = "RTA_ESTADO"
				public shared RTA_CONTROL As string = "RTA_CONTROL"
		    End Structure
	



    <DataMember()>
    Public Property DTD_ID() As String
        Get
            Return _dTD_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DTD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If DetalleTipoDocumentos IsNot Nothing AndAlso Not Equals(DetalleTipoDocumentos.DTD_ID, value) Then
                        DetalleTipoDocumentos = Nothing
                    End If
                End If
                _dTD_ID = value
                OnPropertyChanged("DTD_ID")
            End If
        End Set
    End Property

    Private _dTD_ID As String

    <DataMember()>
    Public Property TIP_ID() As String
        Get
            Return _tIP_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tIP_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TIP_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If TipoArticulos IsNot Nothing AndAlso Not Equals(TipoArticulos.TIP_ID, value) Then
                        TipoArticulos = Nothing
                    End If
                End If
                _tIP_ID = value
                OnPropertyChanged("TIP_ID")
            End If
        End Set
    End Property

    Private _tIP_ID As String

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
    Public Property RTA_FEC_GRAB() As Date
        Get
            Return _rTA_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_rTA_FEC_GRAB, value) Then
                _rTA_FEC_GRAB = value
                OnPropertyChanged("RTA_FEC_GRAB")
            End If
        End Set
    End Property

    Private _rTA_FEC_GRAB As Date

    <DataMember()>
    Public Property RTA_ESTADO() As Boolean
        Get
            Return _rTA_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_rTA_ESTADO, value) Then
                _rTA_ESTADO = value
                OnPropertyChanged("RTA_ESTADO")
            End If
        End Set
    End Property

    Private _rTA_ESTADO As Boolean

    <DataMember()>
    Public Property RTA_CONTROL() As Boolean
        Get
            Return _rTA_CONTROL
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_rTA_CONTROL, value) Then
                _rTA_CONTROL = value
                OnPropertyChanged("RTA_CONTROL")
            End If
        End Set
    End Property

    Private _rTA_CONTROL As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DetalleTipoDocumentos() As DetalleTipoDocumentos
        Get
            Return _detalleTipoDocumentos
        End Get
        Set(ByVal value As DetalleTipoDocumentos)
            If _detalleTipoDocumentos IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(DTD_ID, value.DTD_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As DetalleTipoDocumentos = _detalleTipoDocumentos
                _detalleTipoDocumentos = value
                FixupDetalleTipoDocumentos(previousValue)
                OnNavigationPropertyChanged("DetalleTipoDocumentos")
            End If
        End Set
    End Property

    Private _detalleTipoDocumentos As DetalleTipoDocumentos


    <DataMember()>
    Public Property TipoArticulos() As TipoArticulos
        Get
            Return _tipoArticulos
        End Get
        Set(ByVal value As TipoArticulos)
            If _tipoArticulos IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(TIP_ID, value.TIP_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As TipoArticulos = _tipoArticulos
                _tipoArticulos = value
                FixupTipoArticulos(previousValue)
                OnNavigationPropertyChanged("TipoArticulos")
            End If
        End Set
    End Property

    Private _tipoArticulos As TipoArticulos


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

    ' Este tipo de entidad es el extremo dependiente en al menos una asociación que realiza eliminaciones en cascada.
    ' Este controlador de eventos procesará notificaciones que tienen lugar cuando se elimina el extremo principal.
    Friend Sub HandleCascadeDelete(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.MarkAsDeleted()
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
        DetalleTipoDocumentos = Nothing
        TipoArticulos = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupDetalleTipoDocumentos(ByVal previousValue As DetalleTipoDocumentos)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.RolDetalleTipoDocumentoTipoArticulos.Contains(Me) Then
            previousValue.RolDetalleTipoDocumentoTipoArticulos.Remove(Me)
        End If

        If DetalleTipoDocumentos IsNot Nothing Then
            If Not DetalleTipoDocumentos.RolDetalleTipoDocumentoTipoArticulos.Contains(Me) Then
                DetalleTipoDocumentos.RolDetalleTipoDocumentoTipoArticulos.Add(Me)
            End If

            DTD_ID = DetalleTipoDocumentos.DTD_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DetalleTipoDocumentos") AndAlso
                ChangeTracker.OriginalValues("DetalleTipoDocumentos") Is DetalleTipoDocumentos Then
                ChangeTracker.OriginalValues.Remove("DetalleTipoDocumentos")
            Else
                ChangeTracker.RecordOriginalValue("DetalleTipoDocumentos", previousValue)
            End If
            If DetalleTipoDocumentos IsNot Nothing AndAlso Not DetalleTipoDocumentos.ChangeTracker.ChangeTrackingEnabled Then
                DetalleTipoDocumentos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupTipoArticulos(ByVal previousValue As TipoArticulos)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.RolDetalleTipoDocumentoTipoArticulos.Contains(Me) Then
            previousValue.RolDetalleTipoDocumentoTipoArticulos.Remove(Me)
        End If

        If TipoArticulos IsNot Nothing Then
            If Not TipoArticulos.RolDetalleTipoDocumentoTipoArticulos.Contains(Me) Then
                TipoArticulos.RolDetalleTipoDocumentoTipoArticulos.Add(Me)
            End If

            TIP_ID = TipoArticulos.TIP_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("TipoArticulos") AndAlso
                ChangeTracker.OriginalValues("TipoArticulos") Is TipoArticulos Then
                ChangeTracker.OriginalValues.Remove("TipoArticulos")
            Else
                ChangeTracker.RecordOriginalValue("TipoArticulos", previousValue)
            End If
            If TipoArticulos IsNot Nothing AndAlso Not TipoArticulos.ChangeTracker.ChangeTrackingEnabled Then
                TipoArticulos.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
