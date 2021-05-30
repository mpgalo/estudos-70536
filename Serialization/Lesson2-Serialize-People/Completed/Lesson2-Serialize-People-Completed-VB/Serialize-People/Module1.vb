Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

Module Module1

    ' A simple program that accepts a name, year, month date,
    ' creates a Person object from that information, 
    ' and then displays that person's age on the console.
    Sub Main(ByVal args() As String)
        If (args.Length = 0) Then
            ' If they provide no arguments, display the last person
            Dim p As Person = Deserialize()
            Console.WriteLine(p.ToString)
        Else
            Try
                If (args.Length <> 4) Then
                    Throw New ArgumentException("You must provide four arguments.")
                End If
                Dim dob As DateTime = New DateTime(Int32.Parse(args(1)), Int32.Parse(args(2)), Int32.Parse(args(3)))
                Dim p As Person = New Person(args(0), dob)
                Console.WriteLine(p.ToString)
                Serialize(p)
            Catch ex As Exception
                DisplayUsageInformation(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DisplayUsageInformation(ByVal message As String)
        Console.WriteLine(("ERROR: Invalid parameters. " + message))
        Console.WriteLine()
        Console.WriteLine("Serialize_People ""Name"" Year Month Date")
        Console.WriteLine()
        Console.WriteLine("For example:")
        Console.WriteLine("Serialize_People ""Tony"" 1922 11 22")
        Console.WriteLine()
        Console.WriteLine("Or, run the command with no arguments to display that previous person.")
    End Sub

    Private Sub Serialize(ByVal sp As Person)
        ' Create file to save the data to
        Dim fs As FileStream = New FileStream("Person.XML", FileMode.Create)

        ' Create an XmlSerializer object to perform the serialization
        Dim xs As XmlSerializer = New XmlSerializer(GetType(Person))

        ' Use the XmlSerializer object to serialize the data to the file
        xs.Serialize(fs, sp)

        ' Close the file
        fs.Close()
    End Sub

    Private Function Deserialize() As Person
        Dim dsp As Person = New Person

        ' Create file to save the data to
        Dim fs As FileStream = New FileStream("Person.XML", FileMode.Open)

        ' Create an XmlSerializer object to perform the serialization
        Dim xs As XmlSerializer = New XmlSerializer(GetType(Person))

        ' Use the XmlSerializer object to serialize the data to the file
        dsp = CType(xs.Deserialize(fs), Person)

        ' Close the file
        fs.Close()
        Return dsp
    End Function

End Module
