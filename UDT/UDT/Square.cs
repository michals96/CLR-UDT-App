using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
    IsByteOrdered = true, ValidationMethodName = "ValidateSquare")]
public struct Square : INullable
{
    private Int32 size;
    private Int32 field;
    private bool m_Null;

    private bool ValidateSquare()
    {
        return size >= 0;
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(size + " :" + field);
        if (!this.IsNull)
            return str.ToString();
        else
            return "NULL";
    }

    public bool IsNull
    {
        get
        {
            return m_Null;
        }
    }

    public static Square Null
    {
        get
        {
            Square h = new Square();
            h.m_Null = true;
            return h;
        }
    }

    public Square(Int32 _size, Int32 _field)
    {
        size = _size;
        field = _field;
        m_Null = false;
    }

    public Square(bool val)
    {
        this.size = 0;
        this.field = 0;
        this.m_Null = true;
    }

    public Int32 Size
    {
        get { return this.size; }
        set { size = value; }
    }

    public Int32 Field
    {
        get { return this.field; }
        set { field = value; }
    }

    [SqlMethod(OnNullCall = false)]
    public static Square Parse(SqlString s)
    {
        Square rv = new Square();
        string tmp = s.Value;
        rv.size = Int32.Parse(tmp);
        rv.Field = rv.size * rv.size;

        if (rv.ValidateSquare() == false)
            throw new ArgumentException("Invalid input values");
        if (s.IsNull)
            return Null;
        else
            return rv;
    }
}


