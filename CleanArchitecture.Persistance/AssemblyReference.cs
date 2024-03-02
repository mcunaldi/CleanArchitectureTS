using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance;
public static class AssemblyReference
{
    public static readonly Assembly Assembyle = typeof(Assembly).Assembly;
}
