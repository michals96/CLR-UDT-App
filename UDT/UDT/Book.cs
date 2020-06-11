using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Book : INullable
{
    public string author;
    public string title;
    public int yearOfPublication;
    public override string ToString()
    {
        // Replace the following code with your code
        return "";
    }

    public bool IsNull
    {
        get
        {
            return m_Null;
        }
    }

    public static Book Null
    {
        get
        {
            Book h = new Book();
            h.m_Null = true;
            return h;
        }
    }

    public Book(string _author, string _title, int _year)
    {
        author = _author;
        title = _title;
        yearOfPublication = _year;
        m_Null = false;
    }
    public static Book Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        Book u = new Book();
        // Put your code here
        return u;
    }
    // Private member
    private bool m_Null;
}


