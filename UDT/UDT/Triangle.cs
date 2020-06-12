using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
    IsByteOrdered = true, ValidationMethodName = "ValidateTriangle")]
public struct Triangle : INullable
{
    private double length;
    private double height;
    private double field;
    private bool m_Null;

    private bool ValidateTriangle()
    {
        return (length >= 0 && height >= 0);
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(length + " " + height + " :" + field);
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

    public static Triangle Null
    {
        get
        {
            Triangle h = new Triangle();
            h.m_Null = true;
            return h;
        }
    }

    public Triangle(double _length, double _height, double _field)
    {
        length = _length;
        height = _height;
        field = _field;
        m_Null = false;
    }

    public Triangle(bool val)
    {
        this.length = 0;
        this.height = 0;
        this.field = 0;
        this.m_Null = true;
    }

    public double Length
    {
        get { return this.length; }
        set { length = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { height = value; }
    }

    public double Field
    {
        get { return this.field; }
        set { field = value; }
    }

    [SqlMethod(OnNullCall = false)]
    public static Triangle Parse(SqlString s)
    {
        Triangle rv = new Triangle();
        string[] tmp = s.Value.Split(",".ToCharArray());
        rv.length = double.Parse(tmp[0]);
        rv.height = double.Parse(tmp[1]);
        rv.Field = rv.length * rv.height;

        if (rv.ValidateTriangle() == false)
            throw new ArgumentException("Invalid input values");
        if (s.IsNull)
            return Null;
        else
            return rv;
    }
}


