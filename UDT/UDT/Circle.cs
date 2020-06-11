using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
    IsByteOrdered = true, ValidationMethodName = "ValidateCircle")]
public struct Circle : INullable
{
    private double radius;
    private double circuit;
    private double field;
    private bool m_Null;

    private bool ValidateCircle()
    {
        return (radius >= 0 && circuit >= 0);
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(radius + " " + circuit + " :" + field);
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

    public static Circle Null
    {
        get
        {
            Circle h = new Circle();
            h.m_Null = true;
            return h;
        }
    }

    public Circle(Int32 _radius, Int32 _circuit, Int32 _field)
    {
        radius = _radius;
        circuit = _circuit;
        field = _field;
        m_Null = false;
    }

    public Circle(bool val)
    {
        this.radius = 0;
        this.circuit = 0;
        this.field = 0;
        this.m_Null = true;
    }

    public double Radius
    {
        get { return this.radius; }
        set { radius = value; }
    }

    public double Circuit
    {
        get { return this.circuit; }
        set { circuit = value; }
    }

    public double Field
    {
        get { return this.field; }
        set { field = value; }
    }

    [SqlMethod(OnNullCall = false)]
    public static Circle Parse(SqlString s)
    {
        Circle rv = new Circle();
        string tmp = s.Value;
        rv.radius = double.Parse(tmp);
        rv.circuit = 2 * 3.14 * rv.radius;
        rv.Field = 3.14 * rv.radius * rv.radius;

        if (rv.ValidateCircle() == false)
            throw new ArgumentException("Invalid input values");
        if (s.IsNull)
            return Null;
        else
            return rv;
    }
}


