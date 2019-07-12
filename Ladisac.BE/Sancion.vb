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
<KnownType(GetType(UnidadesTransporte))>
<KnownType(GetType(SancionDetalle))>
Partial Public Class Sancion
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared SAN_ID As string = "SAN_ID"
				public shared SAN_FECHA As string = "SAN_FECHA"
				public shared PER_ID_TRABAJADOR As string = "PER_ID_TRABAJADOR"
				public shared PER_ID_TRABAJADOR_FALTA As string = "PER_ID_TRABAJADOR_FALTA"
				public shared SAN_DNI_FALTA As string = "SAN_DNI_FALTA"
				public shared SAN_NOMBRE_FALTA As string = "SAN_NOMBRE_FALTA"
				public shared PER_ID_PROVEEDOR As string = "PER_ID_PROVEEDOR"
				public shared UNT_ID As string = "UNT_ID"
				public shared SAN_OBSERVACION As string = "SAN_OBSERVACION"
				public shared USU_ID As string = "USU_ID"
				public shared SAN_FEC_GRAB As string = "SAN_FEC_GRAB"
				public shared SAN_ESTADO As string = "SAN_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property SAN_ID() As Integer
        Get
            Return _sAN_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_sAN_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'SAN_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _sAN_ID = value
                OnPropertyChanged("SAN_ID")
            End If
        End Set
    End Property

    Private _sAN_ID As Integer

    <DataMember()>
    Public Property SAN_FECHA() As Nullable(Of Date)
        Get
            Return _sAN_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_sAN_FECHA, value) Then
                _sAN_FECHA = value
                OnPropertyChanged("SAN_FECHA")
            End If
        End Set
    End Property

    Private _sAN_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property PER_ID_TRABAJADOR() As String
        Get
            Return _pER_ID_TRABAJADOR
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_TRABAJADOR, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_TRABAJADOR", _pER_ID_TRABAJADOR)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID_TRABAJADOR = value
                OnPropertyChanged("PER_ID_TRABAJADOR")
            End If
        End Set
    End Property

    Private _pER_ID_TRABAJADOR As String

    <DataMember()>
    Public Property PER_ID_TRABAJADOR_FALTA() As String
        Get
            Return _pER_ID_TRABAJADOR_FALTA
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_TRABAJADOR_FALTA, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_TRABAJADOR_FALTA", _pER_ID_TRABAJADOR_FALTA)
                If Not IsDeserializing Then
                    If Personas1 IsNot Nothing AndAlso Not Equals(Personas1.PER_ID, value) Then
                        Personas1 = Nothing
                    End If
                End If
                _pER_ID_TRABAJADOR_FALTA = value
                OnPropertyChanged("PER_ID_TRABAJADOR_FALTA")
            End If
        End Set
    End Property

    Private _pER_ID_TRABAJADOR_FALTA As String

    <DataMember()>
    Public Property SAN_DNI_FALTA() As String
        Get
            Return _sAN_DNI_FALTA
        End Get
        Set(ByVal value As String)
            If Not Equals(_sAN_DNI_FALTA, value) Then
                _sAN_DNI_FALTA = value
                OnPropertyChanged("SAN_DNI_FALTA")
            End If
        End Set
    End Property

    Private _sAN_DNI_FALTA As String

    <DataMember()>
    Public Property SAN_NOMBRE_FALTA() As String
        Get
            Return _sAN_NOMBRE_FALTA
        End Get
        Set(ByVal value As String)
            If Not Equals(_sAN_NOMBRE_FALTA, value) Then
                _sAN_NOMBRE_FALTA = value
                OnPropertyChanged("SAN_NOMBRE_FALTA")
            End If
        End Set
    End Property

    Private _sAN_NOMBRE_FALTA As String

    <DataMember()>
    Public Property PER_ID_PROVEEDOR() As String
        Get
            Return _pER_ID_PROVEEDOR
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_PROVEEDOR, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_PROVEEDOR", _pER_ID_PROVEEDOR)
                If Not IsDeserializing Then
                    If Personas2 IsNot Nothing AndAlso Not Equals(Personas2.PER_ID, value) Then
                        Personas2 = Nothing
                    End If
                End If
                _pER_ID_PROVEEDOR = value
                OnPropertyChanged("PER_ID_PROVEEDOR")
            End If
        End Set
    End Property

    Private _pER_ID_PROVEEDOR As String

    <DataMember()>
    Public Property UNT_ID() As String
        Get
            Return _uNT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uNT_ID, value) Then
                ChangeTracker.RecordOriginalValue("UNT_ID", _uNT_ID)
                If Not IsDeserializing Then
                    If UnidadesTransporte IsNot Nothing AndAlso Not Equals(UnidadesTransporte.UNT_ID, value) Then
                        UnidadesTransporte = Nothing
                    End If
                End If
                _uNT_ID = value
                OnPropertyChanged("UNT_ID")
            End If
        End Set
    End Property

    Private _uNT_ID As String

    <DataMember()>
    Public Property SAN_OBSERVACION() As String
        Get
            Return _sAN_OBSERVACION
        End Get
        Set(ByVal value As String)
            If Not Equals(_sAN_OBSERVACION, value) Then
                _sAN_OBSERVACION = value
                OnPropertyChanged("SAN_OBSERVACION")
            End If
        End Set
    End Property

    Private _sAN_OBSERVACION As String

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
    Public Property SAN_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _sAN_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_sAN_FEC_GRAB, value) Then
                _sAN_FEC_GRAB = value
                OnPropertyChanged("SAN_FEC_GRAB")
            End If
        End Set
    End Property

    Private _sAN_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property SAN_ESTADO() As Nullable(Of Boolean)
        Get
            Return _sAN_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_sAN_ESTADO, value) Then
                _sAN_ESTADO = value
                OnPropertyChanged("SAN_ESTADO")
            End If
        End Set
    End Property

    Private _sAN_ESTADO As Nullable(Of Boolean)

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
    Public Property Personas1() As Personas
        Get
            Return _personas1
        End Get
        Set(ByVal value As Personas)
            If _personas1 IsNot value Then
                Dim previousValue As Personas = _personas1
                _personas1 = value
                FixupPersonas1(previousValue)
                OnNavigationPropertyChanged("Personas1")
            End If
        End Set
    End Property

    Private _personas1 As Personas


    <DataMember()>
    Public Property Personas2() As Personas
        Get
            Return _personas2
        End Get
        Set(ByVal value As Personas)
            If _personas2 IsNot value Then
                Dim previousValue As Personas = _personas2
                _personas2 = value
                FixupPersonas2(previousValue)
                OnNavigationPropertyChanged("Personas2")
            End If
        End Set
    End Property

    Private _personas2 As Personas


    <DataMember()>
    Public Property UnidadesTransporte() As UnidadesTransporte
        Get
            Return _unidadesTransporte
        End Get
        Set(ByVal value As UnidadesTransporte)
            If _unidadesTransporte IsNot value Then
                Dim previousValue As UnidadesTransporte = _unidadesTransporte
                _unidadesTransporte = value
                FixupUnidadesTransporte(previousValue)
                OnNavigationPropertyChanged("UnidadesTransporte")
            End If
        End Set
    End Property

    Private _unidadesTransporte As UnidadesTransporte


    <DataMember()>
    Public Property SancionDetalle() As TrackableCollection(Of SancionDetalle)
        Get
            If _sancionDetalle Is Nothing Then
                _sancionDetalle = New TrackableCollection(Of SancionDetalle)
                AddHandler _sancionDetalle.CollectionChanged, AddressOf FixupSancionDetalle
            End If
            Return _sancionDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of SancionDetalle))
            If Not Object.ReferenceEquals(_sancionDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _sancionDetalle IsNot Nothing Then
                    RemoveHandler _sancionDetalle.CollectionChanged, AddressOf FixupSancionDetalle
                End If
                _sancionDetalle = value
                If _sancionDetalle IsNot Nothing Then
                    AddHandler _sancionDetalle.CollectionChanged, AddressOf FixupSancionDetalle
                End If
                OnNavigationPropertyChanged("SancionDetalle")
            End If
        End Set
    End Property

    Private _sancionDetalle As TrackableCollection(Of SancionDetalle)

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
        Personas1 = Nothing
        Personas2 = Nothing
        UnidadesTransporte = Nothing
        SancionDetalle.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPersonas(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Sancion.Contains(Me) Then
            previousValue.Sancion.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.Sancion.Contains(Me) Then
                Personas.Sancion.Add(Me)
            End If

            PER_ID_TRABAJADOR = Personas.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_TRABAJADOR = Nothing
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

    Private Sub FixupPersonas1(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Sancion1.Contains(Me) Then
            previousValue.Sancion1.Remove(Me)
        End If

        If Personas1 IsNot Nothing Then
            If Not Personas1.Sancion1.Contains(Me) Then
                Personas1.Sancion1.Add(Me)
            End If

            PER_ID_TRABAJADOR_FALTA = Personas1.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_TRABAJADOR_FALTA = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Personas1") AndAlso
                ChangeTracker.OriginalValues("Personas1") Is Personas1 Then
                ChangeTracker.OriginalValues.Remove("Personas1")
            Else
                ChangeTracker.RecordOriginalValue("Personas1", previousValue)
            End If
            If Personas1 IsNot Nothing AndAlso Not Personas1.ChangeTracker.ChangeTrackingEnabled Then
                Personas1.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPersonas2(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Sancion2.Contains(Me) Then
            previousValue.Sancion2.Remove(Me)
        End If

        If Personas2 IsNot Nothing Then
            If Not Personas2.Sancion2.Contains(Me) Then
                Personas2.Sancion2.Add(Me)
            End If

            PER_ID_PROVEEDOR = Personas2.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_PROVEEDOR = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Personas2") AndAlso
                ChangeTracker.OriginalValues("Personas2") Is Personas2 Then
                ChangeTracker.OriginalValues.Remove("Personas2")
            Else
                ChangeTracker.RecordOriginalValue("Personas2", previousValue)
            End If
            If Personas2 IsNot Nothing AndAlso Not Personas2.ChangeTracker.ChangeTrackingEnabled Then
                Personas2.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupUnidadesTransporte(ByVal previousValue As UnidadesTransporte, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Sancion.Contains(Me) Then
            previousValue.Sancion.Remove(Me)
        End If

        If UnidadesTransporte IsNot Nothing Then
            If Not UnidadesTransporte.Sancion.Contains(Me) Then
                UnidadesTransporte.Sancion.Add(Me)
            End If

            UNT_ID = UnidadesTransporte.UNT_ID
        ElseIf Not skipKeys Then
            UNT_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("UnidadesTransporte") AndAlso
                ChangeTracker.OriginalValues("UnidadesTransporte") Is UnidadesTransporte Then
                ChangeTracker.OriginalValues.Remove("UnidadesTransporte")
            Else
                ChangeTracker.RecordOriginalValue("UnidadesTransporte", previousValue)
            End If
            If UnidadesTransporte IsNot Nothing AndAlso Not UnidadesTransporte.ChangeTracker.ChangeTrackingEnabled Then
                UnidadesTransporte.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupSancionDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As SancionDetalle In e.NewItems
                item.Sancion = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("SancionDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As SancionDetalle In e.OldItems
                If ReferenceEquals(item.Sancion, Me) Then
                    item.Sancion = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("SancionDetalle", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
