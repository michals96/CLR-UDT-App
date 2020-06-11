using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
    IsByteOrdered = true, ValidationMethodName = "ValidateRectangle")]
public struct Rectangle : INullable
{
    private Int32 height;
    private Int32 width;
    private Int32 field;
    private bool m_Null;

    private bool ValidateRectangle()
    {
        return (height >= 0 && width >= 0);
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(height+" "+width+" :"+field);
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

    public static Rectangle Null
    {
        get
        {
            Rectangle h = new Rectangle();
            h.m_Null = true;
            return h;
        }
    }

    public Rectangle(Int32 _height, Int32 _width, Int32 _field)
    {
        height = _height;
        width  = _width;
        field  = _field;
        m_Null = false;
    }

    public Rectangle(bool val)
    {
        this.height = 0;
        this.width  = 0;
        this.field  = 0;
        this.m_Null = true;
    }

    public Int32 Height
    {
        get { return this.height; }
        set { height = value; }
    }

    public Int32 Width
    {
        get { return this.width; }
        set { width = value; }
    }

    public Int32 Field
    {
        get { return this.field; }
        set { field = value; }
    }

    [SqlMethod(OnNullCall = false)]
    public static Rectangle Parse(SqlString s)
    {
        Rectangle rv = new Rectangle();
        string[] tmp = s.Value.Split(",".ToCharArray());
        rv.Height = Int32.Parse(tmp[0]);
        rv.Width = Int32.Parse(tmp[1]);
        rv.Field = rv.Height * rv.Width;

        if (rv.ValidateRectangle() == false)
            throw new ArgumentException("Invalid input values");
        if (s.IsNull)
            return Null;
        else
            return rv;
    }
}


