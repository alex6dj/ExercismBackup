using System;
using System.Linq;
using System.Text;

public static class Identifier
{
    private static readonly CleanupExpression[] _expresions = {
        new SpaceCleanup(),
        new ControlCleanup(),
        new ToCamelCaseCleanup(),
        new OnlyLettersCleanup(),
        new GreeksCleanup(),
    };

    public static string Clean(string identifier)
    {
        if (identifier == string.Empty)
        {
            return string.Empty;
        }
        
        var context = new Context(identifier);
        
        foreach (var cleanupExpression in _expresions)
        {
            cleanupExpression.Clean(context);
        }

        return context.Value;
    }
}

public class Context
{
    public Context(string value)
    {
        Value = value;
    }

    public  string Value { get; set; }
}

public abstract class CleanupExpression
{
    public abstract void Clean(Context context);
}

public class SpaceCleanup : CleanupExpression
{
    public override void Clean(Context context)
    {
        var value = context.Value;

        var sb = new StringBuilder();

        foreach (var c in value)
        {
            sb.Append(char.IsWhiteSpace(c) ? '_' : c);
        }

        context.Value = sb.ToString();
    }
}

public class ControlCleanup : CleanupExpression
{
    public override void Clean(Context context)
    {
        var value = context.Value;

        var sb = new StringBuilder();

        foreach (var c in value)
        {
            sb.Append(char.IsControl(c) ? "CTRL" : c);
        }

        context.Value = sb.ToString();
    }
}

public class ToCamelCaseCleanup : CleanupExpression
{
    public override void Clean(Context context)
    {
        var value = context.Value;

        var sb = new StringBuilder();
        var caseFlag = false;
        foreach (var c in value)
        {
            if (c == '-')
            {
                caseFlag = true;
            }
            else if (caseFlag)
            {
                sb.Append(char.ToUpper(c));
                caseFlag = false;
            }
            else
            {
                sb.Append(c);
            }
        }
        context.Value = sb.ToString();
    }
}

public class OnlyLettersCleanup : CleanupExpression
{
    public override void Clean(Context context)
    {
        var value = context.Value;

        var sb = new StringBuilder();

        foreach (var c in value.Where(x => char.IsLetter(x) || x=='_'))
        {
            sb.Append(c);
        }

        context.Value = sb.ToString();
    }
}

public class GreeksCleanup : CleanupExpression
{
    public override void Clean(Context context)
    {
        const string lowerGreeks = "αβγδεζηθικλμνξοπρστυφχψω";
        
        var value = context.Value;

        var sb = new StringBuilder();

        foreach (var c in value.Where(x => !lowerGreeks.Contains(x)))
        {
            sb.Append(c);
        }

        context.Value = sb.ToString();
    }
}