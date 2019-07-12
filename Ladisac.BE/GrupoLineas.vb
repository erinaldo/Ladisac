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
<KnownType(GetType(Articulos))>
<KnownType(GetType(LineasFamilia))>
<KnownType(GetType(Usuarios))>
Partial Public Class GrupoLineas
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared GLI_ID As string = "GLI_ID"
				public shared GLI_DESCRIPCION As string = "GLI_DESCRIPCION"
				public shared LIN_ID As string = "LIN_ID"
				public shared USU_ID As string = "USU_ID"
				public shared GLI_FEC_GRAB As string = "GLI_FEC_GRAB"
				public shared GLI_ESTADO As string = "GLI_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property GLI_ID() As String
        Get
            Return _gLI_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_gLI_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'GLI_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _gLI_ID = value
                OnPropertyChanged("GLI_ID")
            End If
        End Set
    End Property

    Private _gLI_ID As String

    <DataMember()>
    Public Property GLI_DESCRIPCION() As String
        Get
            Return _gLI_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_gLI_DESCRIPCION, value) Then
                _gLI_DESCRIPCION = value
                OnPropertyChanged("GLI_DESCRIPCION")
            End If
        End Set
    End Property

    Private _gLI_DESCRIPCION As String

    <DataMember()>
    Public Property LIN_ID() As String
        Get
            Return _lIN_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_lIN_ID, value) Then
                ChangeTracker.RecordOriginalValue("LIN_ID", _lIN_ID)
                If Not IsDeserializing Then
                    If LineasFamilia IsNot Nothing AndAlso Not Equals(LineasFamilia.LIN_ID, value) Then
                        LineasFamilia = Nothing
                    End If
                End If
                _lIN_ID = value
                OnPropertyChanged("LIN_ID")
            End If
        End Set
    End Property

    Private _lIN_ID As String

    <DataMember()>
    Public Property USU_ID() As String
        Get
            Return _uSU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID, value) Then
                ChangeTracker.RecordOriginalValue("USU_ID", _uSU_ID)
                If Not IsDeserializing Then
                    If Usuarios IsNot Nothing AndAlso Not Equals(Usuarios.USU_ID, value) Then
                        Usuarios = Nothing
                    End If
                End If
                _uSU_ID = value
                OnPropertyChanged("USU_ID")
            End If
        End Set
    End Property

    Private _uSU_ID As String

    <DataMember()>
    Public Property GLI_FEC_GRAB() As Date
        Get
            Return _gLI_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_gLI_FEC_GRAB, value) Then
                _gLI_FEC_GRAB = value
                OnPropertyChanged("GLI_FEC_GRAB")
            End If
        End Set
    End Property

    Private _gLI_FEC_GRAB As Date

    <DataMember()>
    Public Property GLI_ESTADO() As Boolean
        Get
            Return _gLI_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_gLI_ESTADO, value) Then
                _gLI_ESTADO = value
                OnPropertyChanged("GLI_ESTADO")
            End If
        End Set
    End Property

    Private _gLI_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Articulos() As TrackableCollection(Of Articulos)
        Get
            If _articulos Is Nothing Then
                _articulos = New TrackableCollection(Of Articulos)
                AddHandler _articulos.CollectionChanged, AddressOf FixupArticulos
            End If
            Return _articulos
        End Get
        Set(ByVal value As TrackableCollection(Of Articulos))
            If Not Object.ReferenceEquals(_articulos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _articulos IsNot Nothing Then
                    RemoveHandler _articulos.CollectionChanged, AddressOf FixupArticulos
                End If
                _articulos = value
                If _articulos IsNot Nothing Then
                    AddHandler _articulos.CollectionChanged, AddressOf FixupArticulos
                End If
                OnNavigationPropertyChanged("Articulos")
            End If
        End Set
    End Property

    Private _articulos As TrackableCollection(Of Articulos)

    <DataMember()>
    Public Property LineasFamilia() As LineasFamilia
        Get
            Return _lineasFamilia
        End Get
        Set(ByVal value As LineasFamilia)
            If _lineasFamilia IsNot value Then
                Dim previousValue As LineasFamilia = _lineasFamilia
                _lineasFamilia = value
                FixupLineasFamilia(previousValue)
                OnNavigationPropertyChanged("LineasFamilia")
            End If
        End Set
    End Property

    Private _lineasFamilia As LineasFamilia


    <DataMember()>
    Public Property Usuarios() As Usuarios
        Get
            Return _usuarios
        End Get
        Set(ByVal value As Usuarios)
            If _usuarios IsNot value Then
                Dim previousValue As Usuarios = _usuarios
                _usuarios = value
                FixupUsuarios(previousValue)
                OnNavigationPropertyChanged("Usuarios")
            End If
        End Set
    End Property

    Private _usuarios As Usuarios


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
        Articulos.Clear()
        LineasFamilia = Nothing
        Usuarios = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupLineasFamilia(ByVal previousValue As LineasFamilia)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.GrupoLineas.Contains(Me) Then
            previousValue.GrupoLineas.Remove(Me)
        End If

        If LineasFamilia IsNot Nothing Then
            If Not LineasFamilia.GrupoLineas.Contains(Me) Then
                LineasFamilia.GrupoLineas.Add(Me)
            End If

            LIN_ID = LineasFamilia.LIN_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("LineasFamilia") AndAlso
                ChangeTracker.OriginalValues("LineasFamilia") Is LineasFamilia Then
                ChangeTracker.OriginalValues.Remove("LineasFamilia")
            Else
                ChangeTracker.RecordOriginalValue("LineasFamilia", previousValue)
            End If
            If LineasFamilia IsNot Nothing AndAlso Not LineasFamilia.ChangeTracker.ChangeTrackingEnabled Then
                LineasFamilia.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios)
        If IsDeserializing Then
            Return
        End If

        If Usuarios IsNot Nothing Then
            USU_ID = Usuarios.USU_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Usuarios") AndAlso
                ChangeTracker.OriginalValues("Usuarios") Is Usuarios Then
                ChangeTracker.OriginalValues.Remove("Usuarios")
            Else
                ChangeTracker.RecordOriginalValue("Usuarios", previousValue)
            End If
            If Usuarios IsNot Nothing AndAlso Not Usuarios.ChangeTracker.ChangeTrackingEnabled Then
                Usuarios.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupArticulos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Articulos In e.NewItems
                item.GrupoLineas = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Articulos", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Articulos In e.OldItems
                If ReferenceEquals(item.GrupoLineas, Me) Then
                    item.GrupoLineas = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Articulos", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
