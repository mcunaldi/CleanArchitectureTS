using System.Reflection;

namespace CleanArchitecture.Presentation;
public static class AssemblyReference
{
    public static readonly Assembly assembly = typeof(Assembly).Assembly;
}
