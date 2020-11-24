Public Class LogEntry
    Private _timestamp As DateTime
    Private _type As LogEntryType
    Private _message As String
    Private _fromFile As String
    Private _toFile As String
    Private _fromRating As Integer
    Private _toRating As Integer

    Public ReadOnly Property Timestamp As Date
        Get
            Return _timestamp
        End Get
    End Property

    Public Property Type As LogEntryType
        Get
            Return _type
        End Get
        Set(value As LogEntryType)
            _type = value
        End Set
    End Property

    Public Property Message As String
        Get
            Return _message
        End Get
        Set(value As String)
            _message = value
        End Set
    End Property

    Public Property FromFile As String
        Get
            Return _fromFile
        End Get
        Set(value As String)
            _fromFile = value
        End Set
    End Property

    Public Property ToFile As String
        Get
            Return _toFile
        End Get
        Set(value As String)
            _toFile = value
        End Set
    End Property

    Public Property FromRating As Integer
        Get
            Return _fromRating
        End Get
        Set(value As Integer)
            _fromRating = value
        End Set
    End Property

    Public Property ToRating As Integer
        Get
            Return _toRating
        End Get
        Set(value As Integer)
            _toRating = value
        End Set
    End Property


    Public Enum LogEntryType
        INFO = 0
        SyncFiles = 1
        SyncRatings = 2
    End Enum

    Public Sub New()
    End Sub

    Public Sub New(type As LogEntryType, message As String)
        Me._timestamp = DateTime.Now
        Me.Type = type
        Me.Message = message
    End Sub

    Public Sub New(type As LogEntryType, message As String, fromFile As String, tofile As String)
        Me._timestamp = DateTime.Now
        Me.Type = type
        Me.Message = message
        Me.FromFile = fromFile
        Me.ToFile = tofile
    End Sub

    Public Sub New(type As LogEntryType, message As String, fromFile As String, tofile As String, fromRating As Integer, toRating As Integer)
        Me._timestamp = DateTime.Now
        Me.Type = type
        Me.Message = message
        Me.FromFile = fromFile
        Me.ToFile = tofile
        Me.FromRating = fromRating
        Me.ToRating = toRating
    End Sub
End Class
