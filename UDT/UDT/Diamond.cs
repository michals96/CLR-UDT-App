using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
    IsByteOrdered = true, ValidationMethodName = "ValidateDiamond")]
public struct Diamond : INullable
{
    private double first_diagonal;
    private double second_diagonal;
    private double field;
    private bool m_Null;

    private bool ValidateDiamond()
    {
        return (first_diagonal >= 0 && second_diagonal >= 0);
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(first_diagonal + " " + second_diagonal + " :" + field);
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

    public static Diamond Null
    {
        get
        {
            Diamond h = new Diamond();
            h.m_Null = true;
            return h;
        }
    }

    public Diamond(Int32 _first_diagonal, Int32 _second_diagonal, Int32 _field)
    {
        first_diagonal = _first_diagonal;
        second_diagonal = _second_diagonal;
        field = _field;
        m_Null = false;
    }

    public Diamond(bool val)
    {
        this.first_diagonal = 0;
        this.second_diagonal = 0;
        this.field = 0;
        this.m_Null = true;
    }

    public double First_diagonal
    {
        get { return this.first_diagonal; }
        set { first_diagonal = value; }
    }

    public double Second_diagonal
    {
        get { return this.second_diagonal; }
        set { second_diagonal = value; }
    }

    public double Field
    {
        get { return this.field; }
        set { field = value; }
    }

    [SqlMethod(OnNullCall = false)]
    public static Diamond Parse(SqlString s)
    {
        Diamond rv = new Diamond();
        string[] tmp = s.Value.Split(",".ToCharArray());
        rv.first_diagonal = Int32.Parse(tmp[0]);
        rv.second_diagonal = Int32.Parse(tmp[1]);
        rv.Field = 0.5 * rv.first_diagonal * rv.second_diagonal;

        if (rv.ValidateDiamond() == false)
            throw new ArgumentException("Invalid input values");
        if (s.IsNull)
            return Null;
        else
            return rv;
    }
}


