using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
    IsByteOrdered = true, ValidationMethodName = "ValidateTrapezium")]
public struct Trapezium : INullable
{
    private double upper_base;
    private double lower_base;
    private double height;
    private double field;
    private bool m_Null;

    private bool ValidateTrapezium()
    {
        return (upper_base >= 0 && lower_base >= 0 && height >= 0);
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(upper_base + " " + lower_base + " " + height + " :" + field);
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

    public static Trapezium Null
    {
        get
        {
            Trapezium h = new Trapezium();
            h.m_Null = true;
            return h;
        }
    }

    public Trapezium(double _upper_base, double _lower_base, double _height, double _field)
    {
        upper_base = _upper_base;
        lower_base = _lower_base;
        height = _height;
        field = _field;
        m_Null = false;
    }

    public Trapezium(bool val)
    {
        this.upper_base = 0;
        this.lower_base = 0;
        this.height = 0;
        this.field = 0;
        this.m_Null = true;
    }

    public double Upper_base
    {
        get { return this.upper_base; }
        set { upper_base = value; }
    }

    public double Lower_base
    {
        get { return this.lower_base; }
        set { lower_base = value; }
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
    public static Trapezium Parse(SqlString s)
    {
        Trapezium rv = new Trapezium();
        string[] tmp = s.Value.Split(",".ToCharArray());
        rv.upper_base = double.Parse(tmp[0]);
        rv.lower_base = double.Parse(tmp[1]);
        rv.height = double.Parse(tmp[2]);
        rv.Field = 0.5*(rv.upper_base + rv.lower_base)*rv.height;

        if (rv.ValidateTrapezium() == false)
            throw new ArgumentException("Invalid input values");
        if (s.IsNull)
            return Null;
        else
            return rv;
    }
}


