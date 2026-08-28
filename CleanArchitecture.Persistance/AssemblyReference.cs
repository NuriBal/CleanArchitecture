using System.Reflection;

namespace CleanArchitecture.Persistance;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
